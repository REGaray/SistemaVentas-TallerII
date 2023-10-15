

-- Esta es la definición de un procedimiento almacenado llamado SP_REGISTRARUSUARIO
CREATE PROC SP_REGISTRARUSUARIO(
	@Documento VARCHAR(50),                -- Parámetro de entrada: Documento del usuario
	@NombreCompleto VARCHAR(100),          -- Parámetro de entrada: Nombre completo del usuario
	@Correo VARCHAR(100),                 -- Parámetro de entrada: Correo del usuario
	@Clave VARCHAR(100),                  -- Parámetro de entrada: Clave del usuario
	@IdRol INT,                           -- Parámetro de entrada: Identificador del rol del usuario
	@Estado BIT,                          -- Parámetro de entrada: Estado del usuario (activo/inactivo)
	@IdUsuarioResultado INT OUTPUT,        -- Parámetro de salida: Identificador del usuario registrado
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

CREATE PROC SP_ELIMINARUSUARIO(
	@IdUsuario INT,                         
	@Respuesta BIT OUTPUT,       
	@Mensaje VARCHAR(500) OUTPUT          
)

AS
BEGIN

	SET @Respuesta = 0
	SET @Mensaje = ''
	DECLARE @Pasoreglas BIT = 1

	IF EXISTS (SELECT * FROM COMPRA C
	INNER JOIN USUARIO U ON U.IdUsuario = C.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		SET @Pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA\n'
	END


	IF EXISTS (SELECT * FROM VENTA V
	INNER JOIN USUARIO U ON U.IdUsuario = V.IdUsuario
	WHERE U.IdUsuario = @IdUsuario
	)
	BEGIN
		SET @Pasoreglas = 0
		SET @Respuesta = 0
		SET @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA\n'
	END


	IF (@Pasoreglas = 1)
	BEGIN
		DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario
		SET @Respuesta = 1
	END

END

GO

/*----------------------------- PREOCEDIMIENTOS PARA CATEGORIA -----------------------------*/

-- PROCEDIMIENTO PARA GUARDAR CATEGORIA --
CREATE PROC SP_RregistrarCategoria(
	@Descripcion VARCHAR(50),
	@Resultado INT OUTPUT,
	@Mensaje VARCHAR(500) OUTPUT
)AS

BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
		BEGIN
			INSERT INTO CATEGORIA(Descripcion)
			VALUES(@Descripcion)
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
	@Resultado INT OUTPUT,
	@Mensaje VARCHAR(500) OUTPUT
)AS

BEGIN
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria)
		UPDATE CATEGORIA SET
		Descripcion = @Descripcion WHERE IdCategoria = @IdCategoria
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