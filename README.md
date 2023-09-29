# SistemaVentas-TallerII
Sistema de Ventas realizado para la materia Taller de Programación 2 de 3er año Carrera Licenciatura en Sistemas de la Información de la Universidad Nacional del Nordeste, Corrientes Argentina. Créditos: Jeremías Goytia - Ruben Garay

# JR Software ® - Proyecto de Taller de Programación 2

Este es un proyecto colaborativo para la materia de Taller de Programación 2. Se trata de una aplicación de escritorio CRUD desarrollada en .NET Forms para gestionar un comercio de supermercado, que ofrece un amplio catalogo de productos. El sistema permite registrar tanto compras como ventas y ver sus detalles. La aplicación consta de dos tipos de usuarios:

1. **Usuario Administrador**
2. **Usuario Empleado**

## Módulos

### Registrar Pedido

Este módulo permite agregar productos al pedido del cliente y realizar el pago de manera inmediata.

### Gestionar Empleados

En este módulo, se pueden agregar, editar y eliminar empleados. Cada empleado tiene su propio registro de ventas realizadas.

### Gestionar Productos

Aquí se pueden agregar, editar y eliminar productos del catálogo.

### Reportes

El módulo de reportes permite generar informes de ventas, incluyendo detalles como cuánto ha vendido cada empleado en la semana o el mes.

## Permisos de Usuarios

Los usuarios tienen acceso solo a ciertos módulos, y se asignan los siguientes permisos:

- **Administrador:** Tiene acceso a todos los módulos.
- **Empleado:** Tiene acceso solo al módulo "Registrar Pedido".
- **Gerente:** Tiene acceso solo al módulo "Reportes".
