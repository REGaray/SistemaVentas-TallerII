
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

GO

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
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo)
    BEGIN
        -- Si no existe, insertamos un nuevo registro en la tabla PRODUCTO
        INSERT INTO PRODUCTO(Codigo, Nombre, Descripcion, IdCategoria, Estado)
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

/*------------------------------------------------- PREOCEDIMIENTOS PARA CLIENTE -------------------------------------------------*/

-- PROCEDIMIENTO PARA REGISTRAR UN CLIENTE --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_RegistrarCliente
-- ========================================
-- Descripci�n: Registra un nuevo cliente en la base de datos, si el n�mero de documento no existe.
-- Par�metros de entrada:
-- @Documento (varchar(50)): El n�mero de documento del cliente.
-- @NombreCompleto (varchar(50)): El nombre completo del cliente.
-- @Correo (varchar(50)): La direcci�n de correo electr�nico del cliente.
-- @Telefono (varchar(50)): El n�mero de tel�fono del cliente.
-- @Estado (bit): El estado del cliente (activo/inactivo).
-- Par�metros de salida:
-- @Resultado (int output): El resultado de la operaci�n (0 si no se registr�, ID del cliente si se registr�).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROC sp_RegistrarCliente(
    @Documento varchar(50),
    @NombreCompleto varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    -- Inicializa el resultado como 0.
    SET @Resultado = 0

    -- Declara una variable para almacenar el ID de la persona.
    DECLARE @IDPERSONA INT

    -- Verifica si ya existe un cliente con el mismo n�mero de documento.
    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento)
    BEGIN
        -- Inserta los datos del nuevo cliente en la tabla CLIENTE.
        INSERT INTO CLIENTE(Documento, NombreCompleto, Correo, Telefono, Estado) 
        VALUES (@Documento, @NombreCompleto, @Correo, @Telefono, @Estado)

        -- Obtiene el ID del cliente reci�n registrado.
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        -- Establece un mensaje de error si el n�mero de documento ya existe.
        SET @Mensaje = 'El n�mero de documento ya existe'
    END
END


go

-- PROCEDIMIENTO PARA MODIFICAR UN CLIENTE --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_ModificarCliente
-- ========================================
-- Descripci�n: Modifica los datos de un cliente en la base de datos si el n�mero de documento no coincide con otro cliente existente.
-- Par�metros de entrada:
-- @IdCliente (int): El ID del cliente que se va a modificar.
-- @Documento (varchar(50)): El nuevo n�mero de documento del cliente.
-- @NombreCompleto (varchar(50)): El nuevo nombre completo del cliente.
-- @Correo (varchar(50)): La nueva direcci�n de correo electr�nico del cliente.
-- @Telefono (varchar(50)): El nuevo n�mero de tel�fono del cliente.
-- @Estado (bit): El nuevo estado del cliente (activo/inactivo).
-- Par�metros de salida:
-- @Resultado (bit output): El resultado de la operaci�n (1 si se modific�, 0 si no se modific�).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROC sp_ModificarCliente(
    @IdCliente int,
    @Documento varchar(50),
    @NombreCompleto varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    -- Inicializa el resultado como 1.
    SET @Resultado = 1

    -- Declara una variable para almacenar el ID de la persona.
    DECLARE @IDPERSONA INT

    -- Verifica si no existe otro cliente con el mismo n�mero de documento (excluyendo el cliente actual).
    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE Documento = @Documento AND IdCliente != @IdCliente)
    BEGIN
        -- Realiza la modificaci�n de los datos del cliente en la tabla CLIENTE.
        UPDATE CLIENTE
        SET
            Documento = @Documento,
            NombreCompleto = @NombreCompleto,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado
        WHERE IdCliente = @IdCliente
    END
    ELSE
    BEGIN
        -- Establece un resultado de 0 y un mensaje de error si el n�mero de documento ya existe en otro cliente.
        SET @Resultado = 0
        SET @Mensaje = 'El n�mero de documento ya existe en otro cliente'
    END
END


GO

/*------------------------------------------------- PREOCEDIMIENTOS PARA PROVEEDOR -------------------------------------------------*/

-- PROCEDIMIENTO PARA REGISTRAR UN PROVEEDOR --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_RegistrarProveedor
-- ========================================
-- Descripci�n: Registra un nuevo proveedor en la base de datos, si el n�mero de documento no existe.
-- Par�metros de entrada:
-- @Documento (varchar(50)): El n�mero de documento del proveedor.
-- @RazonSocial (varchar(50)): La raz�n social o nombre del proveedor.
-- @Correo (varchar(50)): La direcci�n de correo electr�nico del proveedor.
-- @Telefono (varchar(50)): El n�mero de tel�fono del proveedor.
-- @Estado (bit): El estado del proveedor (activo/inactivo).
-- Par�metros de salida:
-- @Resultado (int output): El resultado de la operaci�n (0 si no se registr�, ID del proveedor si se registr�).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROC sp_RegistrarProveedor(
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado int output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    -- Inicializa el resultado como 0.
    SET @Resultado = 0

    -- Declara una variable para almacenar el ID de la persona.
    DECLARE @IDPERSONA INT

    -- Verifica si ya existe un proveedor con el mismo n�mero de documento.
    IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
    BEGIN
        -- Inserta los datos del nuevo proveedor en la tabla PROVEEDOR.
        INSERT INTO PROVEEDOR(Documento, RazonSocial, Correo, Telefono, Estado) 
        VALUES (@Documento, @RazonSocial, @Correo, @Telefono, @Estado)

        -- Obtiene el ID del proveedor reci�n registrado.
        SET @Resultado = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        -- Establece un mensaje de error si el n�mero de documento ya existe.
        SET @Mensaje = 'El n�mero de documento ya existe en otro proveedor'
    END
END


GO


-- PROCEDIMIENTO PARA MODIFICAR UN PROVEEDOR --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_ModificarProveedor
-- ========================================
-- Descripci�n: Modifica los datos de un proveedor en la base de datos si el n�mero de documento no coincide con otro proveedor existente.
-- Par�metros de entrada:
-- @IdProveedor (int): El ID del proveedor que se va a modificar.
-- @Documento (varchar(50)): El nuevo n�mero de documento del proveedor.
-- @RazonSocial (varchar(50)): La nueva raz�n social o nombre del proveedor.
-- @Correo (varchar(50)): La nueva direcci�n de correo electr�nico del proveedor.
-- @Telefono (varchar(50)): El nuevo n�mero de tel�fono del proveedor.
-- @Estado (bit): El nuevo estado del proveedor (activo/inactivo).
-- Par�metros de salida:
-- @Resultado (bit output): El resultado de la operaci�n (1 si se modific�, 0 si no se modific�).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROC sp_ModificarProveedor(
    @IdProveedor int,
    @Documento varchar(50),
    @RazonSocial varchar(50),
    @Correo varchar(50),
    @Telefono varchar(50),
    @Estado bit,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    -- Inicializa el resultado como 1.
    SET @Resultado = 1

    -- Declara una variable para almacenar el ID de la persona.
    DECLARE @IDPERSONA INT

    -- Verifica si no existe otro proveedor con el mismo n�mero de documento (excluyendo el proveedor actual).
    IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento AND IdProveedor != @IdProveedor)
    BEGIN
        -- Realiza la modificaci�n de los datos del proveedor en la tabla PROVEEDOR.
        UPDATE PROVEEDOR
        SET
            Documento = @Documento,
            RazonSocial = @RazonSocial,
            Correo = @Correo,
            Telefono = @Telefono,
            Estado = @Estado
        WHERE IdProveedor = @IdProveedor
    END
    ELSE
    BEGIN
        -- Establece un resultado de 0 y un mensaje de error si el n�mero de documento ya existe en otro proveedor.
        SET @Resultado = 0
        SET @Mensaje = 'El n�mero de documento ya existe en otro proveedor'
    END
END



go

-- PROCEDIMIENTO PARA ELIMINAR UN PROVEEDOR --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_EliminarProveedor
-- ========================================
-- Descripci�n: Elimina un proveedor de la base de datos si no est� relacionado a ninguna compra.
-- Par�metros de entrada:
-- @IdProveedor (int): El ID del proveedor que se va a eliminar.
-- Par�metros de salida:
-- @Resultado (bit output): El resultado de la operaci�n (1 si se elimin�, 0 si no se elimin�).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROC sp_EliminarProveedor(
    @IdProveedor int,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    -- Inicializa el resultado como 1.
    SET @Resultado = 1

    -- Verifica si el proveedor no est� relacionado a ninguna compra.
    IF NOT EXISTS (
        SELECT *
        FROM PROVEEDOR p
        INNER JOIN COMPRA c ON p.IdProveedor = c.IdProveedor
        WHERE p.IdProveedor = @IdProveedor
    )
    BEGIN
        -- Elimina el proveedor de la tabla PROVEEDOR.
        DELETE TOP(1) FROM PROVEEDOR WHERE IdProveedor = @IdProveedor
    END
    ELSE
    BEGIN
        -- Establece un resultado de 0 y un mensaje de error si el proveedor est� relacionado a una compra.
        SET @Resultado = 0
        SET @Mensaje = 'El proveedor est� relacionado a una compra y no puede ser eliminado'
    END
END


go



/*------------------------------------------------- PREOCEDIMIENTOS PARA COMPRAS -------------------------------------------------*/

-- Descripci�n: Este script crea un tipo de tabla llamado EDetalle_Compra en la base de datos.
-- Este tipo de tabla se utiliza para almacenar detalles de compra, como el ID del producto, 
-- el precio de compra, el precio de venta, la cantidad comprada y el monto total.
--

-- Crear el tipo de tabla EDetalle_Compra
CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
	-- Descripci�n: Representa el ID del producto asociado al detalle de compra.
	[IdProducto] int NULL,

	-- Descripci�n: Representa el precio de compra del producto asociado al detalle de compra.
	[PrecioCompra] decimal(18,2) NULL,
	
	-- Descripci�n: Representa el precio de venta del producto asociado al detalle de compra.
	[PrecioVenta] decimal(18,2) NULL,

	-- Descripci�n: Representa la cantidad del producto comprado en el detalle de compra.
	[Cantidad] int NULL,
	

	-- Descripci�n: Representa el monto total calculado para el detalle de compra.
	[MontoTotal] decimal(18,2) NULL
)

GO


-- 
-- PROCEDIMIENTO PARA REGISTRAR UNA COMPRA --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_RegistrarCompra
-- ========================================
-- Descripci�n: Registra una compra en la base de datos, incluyendo la informaci�n de la compra y su detalle.
-- Par�metros de entrada:
-- @IdUsuario (int): El ID del usuario que realiza la compra.
-- @IdProveedor (int): El ID del proveedor asociado a la compra.
-- @TipoDocumento (varchar(500)): El tipo de documento utilizado en la compra.
-- @NumeroDocumento (varchar(500)): El n�mero de documento asociado a la compra.
-- @MontoTotal (decimal(18,2)): El monto total de la compra.
-- @DetalleCompra (EDetalle_Compra READONLY): Detalle de la compra utilizando el tipo de tabla definido [EDetalle_Compra].
-- Par�metros de salida:
-- @Resultado (bit output): El resultado de la operaci�n (1 si se registr� correctamente, 0 si hubo un error).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROCEDURE sp_RegistrarCompra(
    @IdUsuario int,
    @IdProveedor int,
    @TipoDocumento varchar(500),
    @NumeroDocumento varchar(500),
    @MontoTotal decimal(18,2),
    @DetalleCompra [EDetalle_Compra] READONLY,
    @Resultado bit output,
    @Mensaje varchar(500) output
)
as
begin
	
	begin try
		-- Declaraci�n de variables locales
		declare @idcompra int = 0
		set @Resultado = 1
		set @Mensaje = ''

		-- Inicio de la transacci�n
		begin transaction registro

		-- Insertar informaci�n de la compra en la tabla COMPRA
		insert into COMPRA(IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal)
		values(@IdUsuario, @IdProveedor, @TipoDocumento, @NumeroDocumento, @MontoTotal)

		-- Obtener el ID de la compra reci�n registrada
		set @idcompra = SCOPE_IDENTITY()

		-- Insertar detalle de la compra en la tabla DETALLE_COMPRA
		insert into DETALLE_COMPRA(IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal)
		select @idcompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal from @DetalleCompra

		-- Actualizar el stock, precio de compra y precio de venta de los productos en la tabla PRODUCTO
		update p set p.Stock = p.Stock + dc.Cantidad, 
		p.PrecioCompra = dc.PrecioCompra,
		p.PrecioVenta = dc.PrecioVenta
		from PRODUCTO p
		inner join @DetalleCompra dc on dc.IdProducto = p.IdProducto

		-- Commit de la transacci�n
		commit transaction registro

	end try
	begin catch
		-- Manejo de errores: establecer el resultado y el mensaje de error, y realizar un rollback
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end

GO

-- 
-- PROCEDIMIENTO PARA GENERAR UN REPORTE DE COMPRAS --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: sp_ReporteCompras
-- ========================================
-- Descripci�n: Genera un reporte detallado de compras filtrado por rango de fechas y/o proveedor.
-- Par�metros de entrada:
-- @fechainicio (varchar(10)): La fecha de inicio del rango de compras en formato dd/mm/yyyy.
-- @fechafin (varchar(10)): La fecha de fin del rango de compras en formato dd/mm/yyyy.
-- @idproveedor (int): El ID del proveedor. Si es 0, se considerar�n todas las compras independientemente del proveedor.
-- ========================================
CREATE PROCEDURE sp_ReporteCompras(
    @fechainicio varchar(10),
    @fechafin varchar(10),
    @idproveedor int
)
as
begin
    -- Establecer el formato de fecha como dd/mm/yyyy
    SET DATEFORMAT dmy;

    -- Consulta para obtener el reporte de compras
    select 
        -- Informaci�n de la compra
        convert(char(10), c.FechaRegistro, 103) as [FechaRegistro],
        c.TipoDocumento,
        c.NumeroDocumento,
        c.MontoTotal,

        -- Informaci�n del usuario que registr� la compra
        u.NombreCompleto as [UsuarioRegistro],

        -- Informaci�n del proveedor asociado a la compra
        pr.Documento as [DocumentoProveedor],
        pr.RazonSocial,

        -- Informaci�n del producto comprado
        p.Codigo as [CodigoProducto],
        p.Nombre as [NombreProducto],

        -- Informaci�n de la categor�a del producto
        ca.Descripcion as [Categoria],

        -- Detalle de la compra
        dc.PrecioCompra,
        dc.PrecioVenta,
        dc.Cantidad,
        dc.MontoTotal as [SubTotal]
    from COMPRA c
    inner join USUARIO u on u.IdUsuario = c.IdUsuario
    inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
    inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
    inner join PRODUCTO p on p.IdProducto = dc.IdProducto
    inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
    where CONVERT(date, c.FechaRegistro) between @fechainicio and @fechafin
    and pr.IdProveedor = iif(@idproveedor = 0, pr.IdProveedor, @idproveedor)
end


GO


/*------------------------------------------------- PREOCEDIMIENTOS PARA VENTAS -------------------------------------------------*/

-- Descripci�n: Este script crea un tipo de tabla llamado EDetalle_Venta en la base de datos.
-- Este tipo de tabla se utiliza para almacenar detalles de venta, como el ID del producto, 
-- el precio de venta, la cantidad vendida y el monto subtotal.
--

-- Crear el tipo de tabla EDetalle_Venta
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	-- Descripci�n: Representa el ID del producto asociado al detalle de venta.
	[IdProducto] int NULL,

	-- Descripci�n: Representa el precio de venta del producto asociado al detalle de venta.
	[PrecioVenta] decimal(18,2) NULL,
	
	-- Descripci�n: Representa la cantidad del producto vendido en el detalle de venta.
	[Cantidad] int NULL,
	
	-- Descripci�n: Representa el monto subtotal calculado para el detalle de venta.
	[SubTotal] decimal(18,2) NULL
)


-- 
-- PROCEDIMIENTO PARA REGISTRAR UNA VENTA --
-- ========================================
-- PROCEDIMIENTO ALMACENADO: usp_RegistrarVenta
-- ========================================
-- Descripci�n: Registra una venta en la base de datos, incluyendo la informaci�n de la venta y su detalle.
-- Par�metros de entrada:
-- @IdUsuario (int): El ID del usuario que realiza la venta.
-- @TipoDocumento (varchar(500)): El tipo de documento utilizado en la venta.
-- @NumeroDocumento (varchar(500)): El n�mero de documento asociado a la venta.
-- @DocumentoCliente (varchar(500)): El documento del cliente asociado a la venta.
-- @NombreCliente (varchar(500)): El nombre del cliente asociado a la venta.
-- @MontoPago (decimal(18,2)): El monto pagado por el cliente.
-- @MontoCambio (decimal(18,2)): El monto de cambio devuelto al cliente.
-- @MontoTotal (decimal(18,2)): El monto total de la venta.
-- @DetalleVenta [EDetalle_Venta] READONLY: Detalle de la venta utilizando el tipo de tabla definido [EDetalle_Venta].
-- Par�metros de salida:
-- @Resultado (bit output): El resultado de la operaci�n (1 si se registr� correctamente, 0 si hubo un error).
-- @Mensaje (varchar(500) output): Un mensaje de texto que describe el resultado de la operaci�n.
-- ========================================
CREATE PROCEDURE usp_RegistrarVenta(
    @IdUsuario int,
    @TipoDocumento varchar(500),
    @NumeroDocumento varchar(500),
    @DocumentoCliente varchar(500),
    @NombreCliente varchar(500),
    @MontoPago decimal(18,2),
    @MontoCambio decimal(18,2),
    @MontoTotal decimal(18,2),
    @DetalleVenta [EDetalle_Venta] READONLY,                                      
    @Resultado bit output,
    @Mensaje varchar(500) output
)
as
begin
	
	begin try
		-- Declaraci�n de variables locales
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		-- Inicio de la transacci�n
		begin transaction registro

		-- Insertar informaci�n de la venta en la tabla VENTA
		insert into VENTA(IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal)
		values(@IdUsuario, @TipoDocumento, @NumeroDocumento, @DocumentoCliente, @NombreCliente, @MontoPago, @MontoCambio, @MontoTotal)

		-- Obtener el ID de la venta reci�n registrada
		set @idventa = SCOPE_IDENTITY()

		-- Insertar detalle de la venta en la tabla DETALLE_VENTA
		insert into DETALLE_VENTA(IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal)
		select @idventa, IdProducto, PrecioVenta, Cantidad, SubTotal from @DetalleVenta

		-- Commit de la transacci�n
		commit transaction registro

	end try
	begin catch
		-- Manejo de errores: establecer el resultado y el mensaje de error, y realizar un rollback
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end

go

CREATE PROC sp_ReporteVentas(
 @fechainicio varchar(10),
 @fechafin varchar(10)
 )
 as
 begin
 SET DATEFORMAT dmy;  
 select 
 convert(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
 u.NombreCompleto[UsuarioRegistro],
 v.DocumentoCliente,v.NombreCliente,
 p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dv.PrecioVenta,dv.Cantidad,dv.SubTotal
 from VENTA v
 inner join USUARIO u on u.IdUsuario = v.IdUsuario
 inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
 inner join PRODUCTO p on p.IdProducto = dv.IdProducto
 inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
 where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end



SELECT * FROM COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria