
/*----------------------------- PREOCEDIMIENTOS PARA CATEGORIA -----------------------------*/

-- Esta es la definici�n de un procedimiento almacenado llamado SP_REGISTRARUSUARIO
-- PROCEDIMIENTO PARA GUARDAR USUARIO --
CREATE PROC SP_REGISTRARUSUARIO(
	@Documento VARCHAR(50),               -- Par�metro de entrada: Documento del usuario
	@NombreCompleto VARCHAR(100),         -- Par�metro de entrada: Nombre completo del usuario
	@Correo VARCHAR(100),                 -- Par�metro de entrada: Correo del usuario
	@Clave VARCHAR(100),                  -- Par�metro de entrada: Clave del usuario
	@IdRol INT,                           -- Par�metro de entrada: Identificador del rol del usuario
	@Estado BIT,                          -- Par�metro de entrada: Estado del usuario (activo/inactivo)
	@IdUsuarioResultado INT OUTPUT,       -- Par�metro de salida: Identificador del usuario registrado
	@Mensaje VARCHAR(500) OUTPUT          -- Par�metro de salida: Mensaje de resultado
)

AS
BEGIN

	-- Inicializamos las variables de salida
	SET @IdUsuarioResultado = 0
	SET @Mensaje = ''  

	-- Verificamos si ya existe un usuario con el mismo documento
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Documento = @Documento)
		BEGIN
			-- Si no existe, insertamos un nuevo registro en la tabla USUARIO
			INSERT INTO USUARIO(Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
			VALUES(@Documento, @NombreCompleto, @Correo, @Clave, @IdRol, @Estado)

			-- Obtenemos el identificador del usuario reci�n insertado
			SET @IdUsuarioResultado = SCOPE_IDENTITY()
		END
	ELSE
		-- Si ya existe un usuario con el mismo documento, asignamos un mensaje de error
		SET @Mensaje = 'No se puede repetir el documento para m�s de un usuario'  

END

GO

-- Definici�n de un procedimiento almacenado llamado SP_EDITARUSUARIO
-- PROCEDIMIENTO PARA MODIFICAR USUARIO --
CREATE PROC SP_EDITARUSUARIO(
	@IdUsuario INT,                    -- Par�metro de entrada: Identificador del usuario a editar
	@Documento VARCHAR(50),            -- Par�metro de entrada: Nuevo documento del usuario
	@NombreCompleto VARCHAR(100),      -- Par�metro de entrada: Nuevo nombre completo del usuario
	@Correo VARCHAR(100),              -- Par�metro de entrada: Nuevo correo del usuario
	@Clave VARCHAR(100),               -- Par�metro de entrada: Nueva clave del usuario
	@IdRol INT,                        -- Par�metro de entrada: Nuevo identificador del rol del usuario
	@Estado BIT,                       -- Par�metro de entrada: Nuevo estado del usuario (activo/inactivo)
	@Respuesta BIT OUTPUT,             -- Par�metro de salida: Indicador de respuesta (0 = No se edit�, 1 = Se edit�)
	@Mensaje VARCHAR(500) OUTPUT       -- Par�metro de salida: Mensaje de resultado
)

AS
BEGIN

	-- Inicializamos las variables de salida
	SET @Respuesta = 0
	SET @Mensaje = ''  

	-- Verificamos si ya existe otro usuario con el mismo documento (excluyendo el usuario actual)
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Documento = @Documento AND IdUsuario != @IdUsuario)
		BEGIN
			-- Si no existe otro usuario con el mismo documento, actualizamos el registro del usuario
			UPDATE USUARIO SET
				Documento = @Documento,
				NombreCompleto = @NombreCompleto,
				Correo = @Correo,
				Clave = @Clave,
				IdRol = @IdRol,
				Estado = @Estado
			WHERE IdUsuario = @IdUsuario

			-- Indicamos que se realiz� la edici�n
			SET @Respuesta = 1
		END
	ELSE
		-- Si ya existe otro usuario con el mismo documento, establecemos un mensaje de error
		SET @Mensaje = 'No se puede repetir el documento para m�s de un usuario'  

END

GO


-- Este procedimiento almacenado SP_ELIMINARUSUARIO se utiliza para eliminar un usuario de la base de datos.
-- Toma como entrada el ID del usuario a eliminar (@IdUsuario) y devuelve una respuesta (@Respuesta) que indica si se realiz� la eliminaci�n y un mensaje de texto (@Mensaje) que proporciona informaci�n sobre el proceso.

-- Definici�n de los par�metros de entrada y salida:
-- @IdUsuario: El ID del usuario que se desea eliminar.
-- @Respuesta: Una variable de salida que indica si se realiz� la eliminaci�n (1 para �xito, 0 para fallo).
-- @Mensaje: Una variable de salida que contiene mensajes descriptivos sobre el resultado de la operaci�n.

-- PROCEDIMIENTO PARA ELIMINAR USUARIO --
CREATE PROC SP_ELIMINARUSUARIO(
	@IdUsuario INT,                         
	@Respuesta BIT OUTPUT,       
	@Mensaje VARCHAR(500) OUTPUT          
)

AS
BEGIN
	-- Inicializar las variables de respuesta y mensaje.
	SET @Respuesta = 0
	SET @Mensaje = ''
	
	-- Declarar una variable para controlar el paso de las reglas de eliminaci�n.
	DECLARE @Pasoreglas BIT = 1
	
	-- Verificar si el usuario est� relacionado con alguna compra.
	IF EXISTS (SELECT * FROM COMPRA C
	INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		-- Si el usuario est� relacionado con una compra, no se puede eliminar.
		SET @Pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA\n'
	END

	-- Verificar si el usuario est� relacionado con alguna venta.
	IF EXISTS (SELECT * FROM VENTA V
	INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		-- Si el usuario est� relacionado con una venta, no se puede eliminar.
		SET @Pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA\n'
	END

	-- Si todas las reglas se han cumplido (no hay compras ni ventas relacionadas),
	-- se procede a eliminar al usuario.
	IF (@Pasoreglas = 1)
	BEGIN
		-- Eliminar el usuario de la tabla USUARIO.
		DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario
		SET @Respuesta = 1  -- Indicar que la eliminaci�n se realiz� con �xito.
	END

END


GO

/*----------------------------- PREOCEDIMIENTOS PARA CATEGORIA -----------------------------*/

-- PROCEDIMIENTO PARA GUARDAR CATEGORIA --
CREATE PROC SP_RregistrarCategoria(
	@Descripcion VARCHAR(50),
	@Estado BIT,
	@Resultado INT OUTPUT,
	@Mensaje VARCHAR(500) OUTPUT
)AS

BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
		BEGIN
			INSERT INTO CATEGORIA(Descripcion, Estado)
			VALUES(@Descripcion, @Estado)
			SET @Resultado = SCOPE_IDENTITY()
		END
	ELSE
		SET @Mensaje = 'No se puede repetir la descripcion de una categoria\n'
END

GO

-- PROCEDIMIENTO PARA MODIFICAR CATEGORIA --
CREATE PROC SP_EditarCategoria(
	@IdCategoria INT,
	@Descripcion VARCHAR(50),
	@Estado BIT,
	@Resultado INT OUTPUT,
	@Mensaje VARCHAR(500) OUTPUT
)AS

BEGIN
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria)
		UPDATE CATEGORIA SET
		Descripcion = @Descripcion,
		Estado = @Estado 
		WHERE IdCategoria = @IdCategoria
	ELSE

	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'No se puede repetir la descripcion de una categoria\n'
	END
END

GO

-- PROCEDIMIENTO PARA ELIMINAR CATEGORIA --
CREATE PROC SP_EliminarCategoria(
	@IdCategoria INT,
	@Resultado INT OUTPUT,
	@Mensaje VARCHAR(500) OUTPUT
)AS

BEGIN
	SET @Resultado = 1
	IF NOT EXISTS (
		SELECT * FROM CATEGORIA c
		INNER JOIN PRODUCTO p on p.IdCategoria = c.IdCategoria
		WHERE c.IdCategoria = @IdCategoria
	)
	BEGIN
		DELETE TOP(1) FROM CATEGORIA WHERE IdCategoria = @IdCategoria
	END
		
	ELSE
	BEGIN
		SET @Resultado = 0
		SET @Mensaje = 'La categoria se encuentra relacionada a un producto\n'
	END
END