
/*------------------------------------------------- PREOCEDIMIENTOS PARA USUARIOS -------------------------------------------------*/

-- PROCEDIMIENTO PARA GUARDAR USUARIO --
-- Descripci�n: Este procedimiento permite registrar un nuevo usuario en la base de datos, asegur�ndose de que no se duplique el n�mero de documento.
-- Par�metros de entrada:
--   @Documento (VARCHAR): Documento del usuario que se desea registrar.
--   @NombreCompleto (VARCHAR): Nombre completo del usuario.
--   @Correo (VARCHAR): Correo del usuario.
--   @Clave (VARCHAR): Clave del usuario.
--   @IdRol (INT): Identificador del rol del usuario.
--   @Estado (BIT): Estado del usuario (activo/inactivo).
-- Par�metros de salida:
--   @IdUsuarioResultado (INT OUTPUT): Identificador del usuario registrado.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de resultado.

CREATE PROC SP_REGISTRARUSUARIO(
    @Documento VARCHAR(50),
    @NombreCompleto VARCHAR(100),
    @Correo VARCHAR(100),
    @Clave VARCHAR(100),
    @IdRol INT,
    @Estado BIT,
    @IdUsuarioResultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
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
        SET @Mensaje = 'No se puede repetir el n�mero de documento para m�s de un usuario'  
END


GO

-- PROCEDIMIENTO PARA MODIFICAR USUARIO --
-- Descripci�n: Este procedimiento permite la edici�n de un usuario en la base de datos, excluyendo la posibilidad de duplicar el n�mero de documento.
-- Par�metros de entrada:
--   @IdUsuario (INT): Identificador del usuario que se desea editar.
--   @Documento (VARCHAR): Nuevo n�mero de documento del usuario.
--   @NombreCompleto (VARCHAR): Nuevo nombre completo del usuario.
--   @Correo (VARCHAR): Nuevo correo del usuario.
--   @Clave (VARCHAR): Nueva clave del usuario.
--   @IdRol (INT): Nuevo identificador del rol del usuario.
--   @Estado (BIT): Nuevo estado del usuario (activo/inactivo).
-- Par�metros de salida:
--   @Respuesta (BIT OUTPUT): Indicador de respuesta (0 = No se edit�, 1 = Se edit�).
--   @Mensaje (VARCHAR OUTPUT): Mensaje de resultado.

CREATE PROC SP_EDITARUSUARIO(
    @IdUsuario INT,
    @Documento VARCHAR(50),
    @NombreCompleto VARCHAR(100),
    @Correo VARCHAR(100),
    @Clave VARCHAR(100),
    @IdRol INT,
    @Estado BIT,
    @Respuesta BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
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
        SET @Mensaje = 'No se puede repetir el n�mero de documento para m�s de un usuario'  
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

/*------------------------------------------------- PREOCEDIMIENTOS PARA CATEGORIA -------------------------------------------------*/

-- PROCEDIMIENTO PARA GUARDAR CATEGORIA --
-- Descripci�n: Este procedimiento almacena una nueva categor�a en la base de datos.
-- Par�metros:
--   @Descripcion (VARCHAR): Descripci�n de la categor�a que se desea guardar.
--   @Estado (BIT): Estado de la categor�a (activo o inactivo).
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operaci�n.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de salida para informar sobre el resultado.

CREATE PROC SP_RregistrarCategoria(
    @Descripcion VARCHAR(50),
    @Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS

BEGIN
    -- Inicializar el resultado como 0
    SET @Resultado = 0

    -- Verificar si ya existe una categor�a con la misma descripci�n
    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
        BEGIN
            -- Si no existe, insertar la nueva categor�a en la tabla CATEGORIA
            INSERT INTO CATEGORIA(Descripcion, Estado)
            VALUES(@Descripcion, @Estado)

            -- Asignar el ID de la nueva categor�a al resultado
            SET @Resultado = SCOPE_IDENTITY()
        END
    ELSE
        -- Mensaje en caso de duplicado
        SET @Mensaje = 'No se puede repetir la descripci�n de una categor�a\n'
END

GO

-- PROCEDIMIENTO PARA MODIFICAR CATEGORIA --
-- Descripci�n: Este procedimiento modifica una categor�a existente en la base de datos.
-- Par�metros:
--   @IdCategoria (INT): ID de la categor�a que se desea modificar.
--   @Descripcion (VARCHAR): Nueva descripci�n de la categor�a.
--   @Estado (BIT): Nuevo estado de la categor�a.
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operaci�n.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de salida para informar sobre el resultado.

CREATE PROC SP_EditarCategoria(
    @IdCategoria INT,
    @Descripcion VARCHAR(50),
    @Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS

BEGIN
    -- Inicializar el resultado como 1 (�xito)
    SET @Resultado = 1

    -- Verificar si ya existe otra categor�a con la misma descripci�n, excluyendo la categor�a actual
    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria)
        BEGIN
            -- Si no existe una categor�a con la misma descripci�n, actualizar la categor�a
            UPDATE CATEGORIA SET
            Descripcion = @Descripcion,
            Estado = @Estado 
            WHERE IdCategoria = @IdCategoria
        END
    ELSE
        BEGIN
            SET @Resultado = 0
            -- Mensaje en caso de duplicado
            SET @Mensaje = 'No se puede repetir la descripci�n de una categor�a\n'
        END
END

GO

-- PROCEDIMIENTO PARA ELIMINAR CATEGORIA --
-- Descripci�n: Este procedimiento elimina una categor�a de la base de datos, siempre que no est� relacionada a productos.
-- Par�metros:
--   @IdCategoria (INT): ID de la categor�a que se desea eliminar.
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operaci�n.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de salida para informar sobre el resultado.

CREATE PROC SP_EliminarCategoria(
    @IdCategoria INT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS

BEGIN
    -- Inicializar el resultado como 1 (�xito)
    SET @Resultado = 1

    -- Verificar si la categor�a est� relacionada a alg�n producto
    IF NOT EXISTS (
        SELECT * FROM CATEGORIA c
        INNER JOIN PRODUCTO p on p.IdCategoria = c.IdCategoria
        WHERE c.IdCategoria = @IdCategoria
    )
    BEGIN
        -- Si la categor�a no est� relacionada a ning�n producto, eliminarla
        DELETE TOP(1) FROM CATEGORIA WHERE IdCategoria = @IdCategoria
    END
        
    ELSE
    BEGIN
        SET @Resultado = 0
        -- Mensaje en caso de relaci�n a productos
        SET @Mensaje = 'La categor�a se encuentra relacionada a un producto\n'
    END
END

/*------------------------------------------------- PREOCEDIMIENTOS PARA PRODUCTO -------------------------------------------------*/

-- PROCEDIMIENTO PARA REGISTRAR UN PRODUCTO --
-- Descripci�n: Este procedimiento permite registrar un nuevo producto en la base de datos, asegur�ndose de que no se duplique el c�digo del producto.
-- Par�metros de entrada:
--   @Codigo (VARCHAR): C�digo del producto que se desea registrar.
--   @Nombre (VARCHAR): Nombre del producto.
--   @Descripcion (VARCHAR): Descripci�n del producto.
--   @IdCategoria (INT): Identificador de la categor�a del producto.
--   @Estado (BIT): Estado del producto (activo/inactivo).
-- Par�metros de salida:
--   @Resultado (INT OUTPUT): Identificador del producto registrado.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de resultado.

CREATE PROC sp_RegistrarProducto(
    @Codigo VARCHAR(20),
    @Nombre VARCHAR(30),
    @Descripcion VARCHAR(30),
    @IdCategoria INT,
    @Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS
BEGIN
    -- Inicializamos las variables de salida
    SET @Resultado = 0
    SET @Mensaje = ''

    -- Verificamos si ya existe un producto con el mismo c�digo
    IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
    BEGIN
        -- Si no existe, insertamos un nuevo registro en la tabla PRODUCTO
        INSERT INTO producto(Codigo, Nombre, Descripcion, IdCategoria, Estado)
        VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Estado)
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
        SET @Mensaje = 'Ya existe un producto con el mismo c�digo'
END

GO

-- PROCEDIMIENTO PARA MODIFICAR UN PRODUCTO --
-- Descripci�n: Este procedimiento permite modificar un producto existente en la base de datos, asegur�ndose de que no se duplique el c�digo del producto.
-- Par�metros de entrada:
--   @IdProducto (INT): Identificador del producto que se desea modificar.
--   @Codigo (VARCHAR): Nuevo c�digo del producto.
--   @Nombre (VARCHAR): Nuevo nombre del producto.
--   @Descripcion (VARCHAR): Nueva descripci�n del producto.
--   @IdCategoria (INT): Nuevo identificador de la categor�a del producto.
--   @Estado (BIT): Nuevo estado del producto (activo/inactivo).
-- Par�metros de salida:
--   @Resultado (BIT OUTPUT): Indicador de resultado (1 = �xito, 0 = error).
--   @Mensaje (VARCHAR OUTPUT): Mensaje de resultado.

CREATE PROC sp_ModificarProducto(
    @IdProducto INT,
    @Codigo VARCHAR(20),
    @Nombre VARCHAR(30),
    @Descripcion VARCHAR(30),
    @IdCategoria INT,
    @Estado BIT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    -- Inicializamos las variables de salida
    SET @Resultado = 1
    SET @Mensaje = ''

    -- Verificamos si ya existe otro producto con el mismo c�digo (excluyendo el producto actual)
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo AND IdProducto != @IdProducto)
    BEGIN
        -- Si no existe otro producto con el mismo c�digo, actualizamos el registro del producto
        UPDATE PRODUCTO SET
            Codigo = @Codigo,
            Nombre = @Nombre,
            Descripcion = @Descripcion,
            IdCategoria = @IdCategoria,
            Estado = @Estado
        WHERE IdProducto = @IdProducto
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un producto con el mismo c�digo'
    END
END

GO

-- PROCEDIMIENTO PARA ELIMINAR UN PRODUCTO --
-- Descripci�n: Este procedimiento permite eliminar un producto de la base de datos, siempre que no est� relacionado con compras o ventas.
-- Par�metros de entrada:
--   @IdProducto (INT): Identificador del producto que se desea eliminar.
-- Par�metros de salida:
--   @Respuesta (BIT OUTPUT): Indicador de respuesta (0 = no se elimin�, 1 = se elimin�).
--   @Mensaje (VARCHAR OUTPUT): Mensaje de resultado.

CREATE PROC SP_EliminarProducto(
    @IdProducto INT,
    @Respuesta BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    -- Inicializamos las variables de salida
    SET @Respuesta = 0
    SET @Mensaje = ''
    DECLARE @pasoreglas BIT = 1

    -- Verificamos si el producto est� relacionado con compras
    IF EXISTS (SELECT * FROM DETALLE_COMPRA dc 
        INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� relacionado a una COMPRA\n' 
    END

    -- Verificamos si el producto est� relacionado con ventas
    IF EXISTS (SELECT * FROM DETALLE_VENTA dv
        INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque est� relacionado a una VENTA\n' 
    END

    -- Si el producto no est� relacionado con compras ni ventas, lo eliminamos
    IF (@pasoreglas = 1)
    BEGIN
        DELETE FROM PRODUCTO WHERE IdProducto = @IdProducto
        SET @Respuesta = 1
    END
END

GO
