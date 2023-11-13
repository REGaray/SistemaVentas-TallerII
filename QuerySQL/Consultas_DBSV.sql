-- Las siguientes sentecias hacen un DROP completo de la BD.
-- USE DBSISTEMA_VENTA;  -- Reemplaza "NOMBRE_DE_TU_BASE_DE_DATOS" por el nombre de tu base de datos.
-- EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
-- EXEC sp_MSforeachtable 'DELETE FROM ?'
-- EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'


-- Reinicia el valor de identidad a 1
-- DBCC CHECKIDENT('mi_tabla', RESEED, 0);

-- Consultar el estado de las tablas
SELECT * FROM CLIENTE
SELECT * FROM PRODUCTO
SELECT * FROM CATEGORIA
SELECT * FROM VENTA
SELECT * FROM DETALLE_VENTA
SELECT * FROM USUARIO
SELECT * FROM ROL
SELECT * FROM PERMISO
SELECT * FROM COMPRA
SELECT * FROM DETALLE_COMPRA
SELECT * FROM PROVEEDOR

-- Creando roles --
INSERT INTO ROL(Descripcion)
VALUES ('GERENTE'),
	   ('ADMINISTRADOR'),
	   ('ENCARGADO')

--
INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) VALUES 
-- GERENTE --
	   ('42061377', 'Jeremias J. Goytia', 'jere@gmail.com', '123', 1, 1),
-- ENCARGADO --
	   ('42503051', 'Diana B. Mini', 'diana@gmail.com', '123', 2, 1),
-- EMPLEADO --
	   ('42000111', 'Ruben E. Garay', 'ruben@gmail.com', '123', 3, 1)


-- Brindar seguridad del rol Gerente --
INSERT INTO PERMISO (IdRol, NombreMenu) VALUES
(1, 'btnUsuarios'),
(1, 'btnConfiguracion'),
(1, 'btnVentas'),
(1, 'btnCompras'),
(1, 'btnClientes'),
(1, 'btnProveedores'),
(1, 'btnReportes');

-- Brindar seguridad del rol Encargado --
INSERT INTO PERMISO (IdRol, NombreMenu) VALUES
(2, 'btnUsuarios'),
(2, 'btnConfiguracion'),
(2, 'btnVentas'),
(2, 'btnCompras'),
(2, 'btnClientes'),
(2, 'btnProveedores');


-- Brindar seguridad del rol Empleado --
INSERT INTO PERMISO (IdRol, NombreMenu) VALUES
(3, 'btnVentas'),
(3, 'btnCompras'),
(3, 'btnClientes'),
(3, 'btnProveedores');

-- Agregando categorias a la DB --
INSERT INTO CATEGORIA(Descripcion, Estado) VALUES
('Gaseosas', 1),
('Almac�n', 1),
('Espirituosas', 1),
('Higiene Personal', 1),
('Cigarrillos', 1),
('Limpieza', 1),
('L�cteos', 1),
('Espirituosas', 1)


-- Agregando productos a la DB --
INSERT INTO PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria) VALUES
(779596, 'Leche LV LS x 1l', 'Leche Larga Vida La Seren�sima x 1l', 8),
(779595, 'Coca Cola x3l', 'Gaseosa Coca Cola x 3l Regular', 2),
(779594, 'Chocolatada Cindor x1l', 'Leche Chocolatada Cindor x 1l', 8),
(779593, 'Pur� De la Huerta 510ml', 'Pur� de Tomate De la Huerta 510ml', 3),
(779592, 'Fernet Branca 75cc', 'Fernet Branca 75cc', 9),
(779591, 'Sprite 2.25l', 'Gaseosa Sprite 2.25l Regular', 2),
(779590, 'Gancia 450cc', 'Aperitivo Gancia 450ccr', 9)

-- Actualiza el estado de todos los productos a 1 --
UPDATE PRODUCTO SET Estado = 1
DELETE PRODUCTO
SELECT * FROM PRODUCTO
DBCC CHECKIDENT('PRODUCTO', RESEED, 0);



-- Agregando clientes a la DB --
SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado FROM CLIENTE



-- Esta consulta selecciona los roles (IdRol) y nombres de men� (NombreMenu) de la tabla PERMISO,
-- y los combina con los roles (IdRol) correspondientes de la tabla ROL mediante una operaci�n INNER JOIN.
-- La condici�n de uni�n se basa en la igualdad de IdRol en ROL y IdPermiso en PERMISO.
-- El resultado proporciona informaci�n relacionada entre las dos tablas.

SELECT p.IdRol, p.NombreMenu FROM PERMISO p
INNER JOIN ROL r on r.IdRol = p.IdRol
INNER JOIN USUARIO u on u.IdRol = r.IdRol
WHERE u.IdUsuario = 2

-- Esta consulta recupera datos de usuarios y sus roles correspondientes.

-- Seleccionamos las siguientes columnas de la tabla 'usuario':
--   - IdUsuario: Identificador �nico del usuario.
--   - Documento: N�mero de documento del usuario.
--   - NombreCompleto: Nombre completo del usuario.
--   - Correo: Direcci�n de correo electr�nico del usuario.
--   - Clave: Contrase�a del usuario (ten en cuenta que almacenar contrase�as en texto plano no es seguro).
--   - Estado: Estado del usuario (activo, inactivo, etc.).

-- Adem�s, seleccionamos las siguientes columnas de la tabla 'rol':
--   - IdRol: Identificador �nico del rol.
--   - Descripcion: Descripci�n o nombre del rol.

SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion FROM usuario u
INNER JOIN rol r ON r.IdRol = u.IdRol



-- Esta consulta recupera datos de productos y sus categor�as correspondientes.

-- Seleccionamos las siguientes columnas de la tabla 'producto':
--   - IdProducto: Identificador �nico del producto.
--   - Codigo: C�digo �nico del producto.
--   - Nombre: Nombre del producto.
--   - Descripcion: Descripci�n detallada del producto.
--   - IdCategoria: Identificador �nico de la categor�a a la que pertenece el producto.
--   - DescripcionCategoria: Descripci�n de la categor�a del producto.
--   - Stock: Cantidad de stock disponible del producto.
--   - PrecioCompra: Precio al que se compra el producto.
--   - PrecioVenta: Precio al que se vende el producto.

-- Adem�s, seleccionamos las siguientes columnas de la tabla 'categoria':
--   - IdCategoria: Identificador �nico de la categor�a.
--   - DescripcionCategoria: Descripci�n o nombre de la categor�a.
--   - (Nota: La columna 'IdCategoria' se selecciona tanto de 'producto' como de 'categoria' para vincular los productos con sus categor�as correspondientes).

-- Se utiliza una instrucci�n INNER JOIN para combinar datos de las tablas 'producto' y 'categoria' en funci�n de la igualdad de 'IdCategoria'.

SELECT IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria, c.Descripcion[DescripcionCategoria], Stock, PrecioCompra, PrecioVenta, p.Estado FROM PRODUCTO p
INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria