
/*------------------------------------------------- PREOCEDIMIENTOS PARA USUARIOS -------------------------------------------------*/

-- PROCEDIMIENTO PARA GUARDAR USUARIO --
-- Descripción: Este procedimiento permite registrar un nuevo usuario en la base de datos, asegurándose de que no se duplique el número de documento.
-- Parámetros de entrada:
--   @Documento (VARCHAR): Documento del usuario que se desea registrar.
--   @NombreCompleto (VARCHAR): Nombre completo del usuario.
--   @Correo (VARCHAR): Correo del usuario.
--   @Clave (VARCHAR): Clave del usuario.
--   @IdRol (INT): Identificador del rol del usuario.
--   @Estado (BIT): Estado del usuario (activo/inactivo).
-- Parámetros de salida:
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

            -- Obtenemos el identificador del usuario recién insertado
            SET @IdUsuarioResultado = SCOPE_IDENTITY()
        END
    ELSE
        -- Si ya existe un usuario con el mismo documento, asignamos un mensaje de error
        SET @Mensaje = 'No se puede repetir el número de documento para más de un usuario'  
END


GO

-- PROCEDIMIENTO PARA MODIFICAR USUARIO --
-- Descripción: Este procedimiento permite la edición de un usuario en la base de datos, excluyendo la posibilidad de duplicar el número de documento.
-- Parámetros de entrada:
--   @IdUsuario (INT): Identificador del usuario que se desea editar.
--   @Documento (VARCHAR): Nuevo número de documento del usuario.
--   @NombreCompleto (VARCHAR): Nuevo nombre completo del usuario.
--   @Correo (VARCHAR): Nuevo correo del usuario.
--   @Clave (VARCHAR): Nueva clave del usuario.
--   @IdRol (INT): Nuevo identificador del rol del usuario.
--   @Estado (BIT): Nuevo estado del usuario (activo/inactivo).
-- Parámetros de salida:
--   @Respuesta (BIT OUTPUT): Indicador de respuesta (0 = No se editó, 1 = Se editó).
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

            -- Indicamos que se realizó la edición
            SET @Respuesta = 1
        END
    ELSE
        -- Si ya existe otro usuario con el mismo documento, establecemos un mensaje de error
        SET @Mensaje = 'No se puede repetir el número de documento para más de un usuario'  
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

/*------------------------------------------------- PREOCEDIMIENTOS PARA CATEGORIA -------------------------------------------------*/

-- PROCEDIMIENTO PARA GUARDAR CATEGORIA --
-- Descripción: Este procedimiento almacena una nueva categoría en la base de datos.
-- Parámetros:
--   @Descripcion (VARCHAR): Descripción de la categoría que se desea guardar.
--   @Estado (BIT): Estado de la categoría (activo o inactivo).
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operación.
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

    -- Verificar si ya existe una categoría con la misma descripción
    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
        BEGIN
            -- Si no existe, insertar la nueva categoría en la tabla CATEGORIA
            INSERT INTO CATEGORIA(Descripcion, Estado)
            VALUES(@Descripcion, @Estado)

            -- Asignar el ID de la nueva categoría al resultado
            SET @Resultado = SCOPE_IDENTITY()
        END
    ELSE
        -- Mensaje en caso de duplicado
        SET @Mensaje = 'No se puede repetir la descripción de una categoría\n'
END

GO

-- PROCEDIMIENTO PARA MODIFICAR CATEGORIA --
-- Descripción: Este procedimiento modifica una categoría existente en la base de datos.
-- Parámetros:
--   @IdCategoria (INT): ID de la categoría que se desea modificar.
--   @Descripcion (VARCHAR): Nueva descripción de la categoría.
--   @Estado (BIT): Nuevo estado de la categoría.
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operación.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de salida para informar sobre el resultado.

CREATE PROC SP_EditarCategoria(
    @IdCategoria INT,
    @Descripcion VARCHAR(50),
    @Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS

BEGIN
    -- Inicializar el resultado como 1 (éxito)
    SET @Resultado = 1

    -- Verificar si ya existe otra categoría con la misma descripción, excluyendo la categoría actual
    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria)
        BEGIN
            -- Si no existe una categoría con la misma descripción, actualizar la categoría
            UPDATE CATEGORIA SET
            Descripcion = @Descripcion,
            Estado = @Estado 
            WHERE IdCategoria = @IdCategoria
        END
    ELSE
        BEGIN
            SET @Resultado = 0
            -- Mensaje en caso de duplicado
            SET @Mensaje = 'No se puede repetir la descripción de una categoría\n'
        END
END

GO

-- PROCEDIMIENTO PARA ELIMINAR CATEGORIA --
-- Descripción: Este procedimiento elimina una categoría de la base de datos, siempre que no esté relacionada a productos.
-- Parámetros:
--   @IdCategoria (INT): ID de la categoría que se desea eliminar.
--   @Resultado (INT OUTPUT): Variable de salida para indicar el resultado de la operación.
--   @Mensaje (VARCHAR OUTPUT): Mensaje de salida para informar sobre el resultado.

CREATE PROC SP_EliminarCategoria(
    @IdCategoria INT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
) AS

BEGIN
    -- Inicializar el resultado como 1 (éxito)
    SET @Resultado = 1

    -- Verificar si la categoría está relacionada a algún producto
    IF NOT EXISTS (
        SELECT * FROM CATEGORIA c
        INNER JOIN PRODUCTO p on p.IdCategoria = c.IdCategoria
        WHERE c.IdCategoria = @IdCategoria
    )
    BEGIN
        -- Si la categoría no está relacionada a ningún producto, eliminarla
        DELETE TOP(1) FROM CATEGORIA WHERE IdCategoria = @IdCategoria
    END
        
    ELSE
    BEGIN
        SET @Resultado = 0
        -- Mensaje en caso de relación a productos
        SET @Mensaje = 'La categoría se encuentra relacionada a un producto\n'
    END
END

/*------------------------------------------------- PREOCEDIMIENTOS PARA PRODUCTO -------------------------------------------------*/

-- PROCEDIMIENTO PARA REGISTRAR UN PRODUCTO --
-- Descripción: Este procedimiento permite registrar un nuevo producto en la base de datos, asegurándose de que no se duplique el código del producto.
-- Parámetros de entrada:
--   @Codigo (VARCHAR): Código del producto que se desea registrar.
--   @Nombre (VARCHAR): Nombre del producto.
--   @Descripcion (VARCHAR): Descripción del producto.
--   @IdCategoria (INT): Identificador de la categoría del producto.
--   @Estado (BIT): Estado del producto (activo/inactivo).
-- Parámetros de salida:
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

    -- Verificamos si ya existe un producto con el mismo código
    IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
    BEGIN
        -- Si no existe, insertamos un nuevo registro en la tabla PRODUCTO
        INSERT INTO producto(Codigo, Nombre, Descripcion, IdCategoria, Estado)
        VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Estado)
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
        SET @Mensaje = 'Ya existe un producto con el mismo código'
END

GO

-- PROCEDIMIENTO PARA MODIFICAR UN PRODUCTO --
-- Descripción: Este procedimiento permite modificar un producto existente en la base de datos, asegurándose de que no se duplique el código del producto.
-- Parámetros de entrada:
--   @IdProducto (INT): Identificador del producto que se desea modificar.
--   @Codigo (VARCHAR): Nuevo código del producto.
--   @Nombre (VARCHAR): Nuevo nombre del producto.
--   @Descripcion (VARCHAR): Nueva descripción del producto.
--   @IdCategoria (INT): Nuevo identificador de la categoría del producto.
--   @Estado (BIT): Nuevo estado del producto (activo/inactivo).
-- Parámetros de salida:
--   @Resultado (BIT OUTPUT): Indicador de resultado (1 = éxito, 0 = error).
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

    -- Verificamos si ya existe otro producto con el mismo código (excluyendo el producto actual)
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo AND IdProducto != @IdProducto)
    BEGIN
        -- Si no existe otro producto con el mismo código, actualizamos el registro del producto
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
        SET @Mensaje = 'Ya existe un producto con el mismo código'
    END
END

GO

-- PROCEDIMIENTO PARA ELIMINAR UN PRODUCTO --
-- Descripción: Este procedimiento permite eliminar un producto de la base de datos, siempre que no esté relacionado con compras o ventas.
-- Parámetros de entrada:
--   @IdProducto (INT): Identificador del producto que se desea eliminar.
-- Parámetros de salida:
--   @Respuesta (BIT OUTPUT): Indicador de respuesta (0 = no se eliminó, 1 = se eliminó).
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

    -- Verificamos si el producto está relacionado con compras
    IF EXISTS (SELECT * FROM DETALLE_COMPRA dc 
        INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque está relacionado a una COMPRA\n' 
    END

    -- Verificamos si el producto está relacionado con ventas
    IF EXISTS (SELECT * FROM DETALLE_VENTA dv
        INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
        WHERE p.IdProducto = @IdProducto
    )
    BEGIN
        SET @pasoreglas = 0
        SET @Respuesta = 0
        SET @Mensaje = @Mensaje + 'No se puede eliminar porque está relacionado a una VENTA\n' 
    END

    -- Si el producto no está relacionado con compras ni ventas, lo eliminamos
    IF (@pasoreglas = 1)
    BEGIN
        DELETE FROM PRODUCTO WHERE IdProducto = @IdProducto
        SET @Respuesta = 1
    END
END

GO
