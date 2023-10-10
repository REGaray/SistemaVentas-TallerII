
SELECT * FROM USUARIO


INSERT INTO ROL(Descripcion)
VALUES ('ADMINISTRADOR') 

INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
VALUES ('42603051', 'Diana B. Mini', 'diana@gmail.com', '123', 2, 1)


SELECT * FROM ROL
DELETE FROM USUARIO
DBCC CHECKIDENT (USUARIO, RESEED, 0);

SELECT * FROM PERMISO

-- Esta consulta selecciona los roles (IdRol) y nombres de men� (NombreMenu) de la tabla PERMISO,
-- y los combina con los roles (IdRol) correspondientes de la tabla ROL mediante una operaci�n INNER JOIN.
-- La condici�n de uni�n se basa en la igualdad de IdRol en ROL y IdPermiso en PERMISO.
-- El resultado proporciona informaci�n relacionada entre las dos tablas.
SELECT p.IdRol, p.NombreMenu
FROM PERMISO p
INNER JOIN ROL r on r.IdRol = p.IdRol
INNER JOIN USUARIO u on u.IdRol = r.IdRol

WHERE u.IdUsuario = 2


INSERT INTO PERMISO (IdRol, NombreMenu) VALUES
(1, 'btnUsuarios'),
(1, 'btnConfiguracion'),
(1, 'btnVentas'),
(1, 'btnCompras'),
(1, 'btnClientes'),
(1, 'btnProveedores'),
(1, 'btnReportes')

INSERT INTO PERMISO (IdRol, NombreMenu) VALUES
(2, 'btnVentas'),
(2, 'btnCompras'),
(2, 'btnClientes'),
(2, 'btnProveedores')



/*
DELETE FROM USUARIO
WHERE IdUsuario = 5
*/

-- Reinicia el valor de identidad a 1
-- DBCC CHECKIDENT('mi_tabla', RESEED, 0);

select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u
inner join rol r on r.IdRol = u.IdRol