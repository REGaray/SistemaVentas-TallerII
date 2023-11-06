
/*----------------------------- PREOCEDIMIENTOS PARA CATEGORIA -----------------------------*/

-- Esta es la definición de un procedimiento almacenado llamado SP_REGISTRARUSUARIO
-- PROCEDIMIENTO PARA GUARDAR USUARIO --
CREATE PROC SP_REGISTRARUSUARIO(
	@Documento VARCHAR(50),               -- Parámetro de entrada: Documento del usuario
	@NombreCompleto VARCHAR(100),         -- Parámetro de entrada: Nombre completo del usuario
	@Correo VARCHAR(100),                 -- Parámetro de entrada: Correo del usuario
	@Clave VARCHAR(100),                  -- Parámetro de entrada: Clave del usuario
	@IdRol INT,                           -- Parámetro de entrada: Identificador del rol del usuario
	@Estado BIT,                          -- Parámetro de entrada: Estado del usuario (activo/inactivo)
	@IdUsuarioResultado INT OUTPUT,       -- Parámetro de salida: Identificador del usuario registrado
	@Mensaje VARCHAR(500) OUTPUT          -- Parámetro de salida: Mensaje de resultado
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

			-- Obtenemos el identificador del usuario recién insertado
			SET @IdUsuarioResultado = SCOPE_IDENTITY()
		END
	ELSE
		-- Si ya existe un usuario con el mismo documento, asignamos un mensaje de error
		SET @Mensaje = 'No se puede repetir el documento para más de un usuario'  

END

GO

-- Definición de un procedimiento almacenado llamado SP_EDITARUSUARIO
-- PROCEDIMIENTO PARA MODIFICAR USUARIO --
CREATE PROC SP_EDITARUSUARIO(
	@IdUsuario INT,                    -- Parámetro de entrada: Identificador del usuario a editar
	@Documento VARCHAR(50),            -- Parámetro de entrada: Nuevo documento del usuario
	@NombreCompleto VARCHAR(100),      -- Parámetro de entrada: Nuevo nombre completo del usuario
	@Correo VARCHAR(100),              -- Parámetro de entrada: Nuevo correo del usuario
	@Clave VARCHAR(100),               -- Parámetro de entrada: Nueva clave del usuario
	@IdRol INT,                        -- Parámetro de entrada: Nuevo identificador del rol del usuario
	@Estado BIT,                       -- Parámetro de entrada: Nuevo estado del usuario (activo/inactivo)
	@Respuesta BIT OUTPUT,             -- Parámetro de salida: Indicador de respuesta (0 = No se editó, 1 = Se editó)
	@Mensaje VARCHAR(500) OUTPUT       -- Parámetro de salida: Mensaje de resultado
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

			-- Indicamos que se realizó la edición
			SET @Respuesta = 1
		END
	ELSE
		-- Si ya existe otro usuario con el mismo documento, establecemos un mensaje de error
		SET @Mensaje = 'No se puede repetir el documento para más de un usuario'  

END

GO


-- Este procedimiento almacenado SP_ELIMINARUSUARIO se utiliza para eliminar un usuario de la base de datos.
-- Toma como entrada el ID del usuario a eliminar (@IdUsuario) y devuelve una respuesta (@Respuesta) que indica si se realizó la eliminación y un mensaje de texto (@Mensaje) que proporciona información sobre el proceso.

-- Definición de los parámetros de entrada y salida:
-- @IdUsuario: El ID del usuario que se desea eliminar.
-- @Respuesta: Una variable de salida que indica si se realizó la eliminación (1 para éxito, 0 para fallo).
-- @Mensaje: Una variable de salida que contiene mensajes descriptivos sobre el resultado de la operación.

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
	
	-- Declarar una variable para controlar el paso de las reglas de eliminación.
	DECLARE @Pasoreglas BIT = 1
	
	-- Verificar si el usuario está relacionado con alguna compra.
	IF EXISTS (SELECT * FROM COMPRA C
	INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		-- Si el usuario está relacionado con una compra, no se puede eliminar.
		SET @Pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA\n'
	END

	-- Verificar si el usuario está relacionado con alguna venta.
	IF EXISTS (SELECT * FROM VENTA V
	INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		-- Si el usuario está relacionado con una venta, no se puede eliminar.
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
		SET @Respuesta = 1  -- Indicar que la eliminación se realizó con éxito.
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