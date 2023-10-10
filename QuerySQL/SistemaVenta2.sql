USE [master]
GO
/****** Object:  Database [DBSISTEMA_VENTA]    Script Date: 09/10/2023 21:17:31 ******/
CREATE DATABASE [DBSISTEMA_VENTA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBSISTEMA_VENTA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBSISTEMA_VENTA.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBSISTEMA_VENTA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DBSISTEMA_VENTA_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBSISTEMA_VENTA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET  MULTI_USER 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DBSISTEMA_VENTA]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPRA](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdProveedor] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLE_COMPRA]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_COMPRA](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_VENTA]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_VENTA](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERMISO](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[NombreMenu] [varchar](100) NULL,
	[FechaRegistro] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[IdCategoria] [int] NULL,
	[Stock] [int] NOT NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[RazonSocial] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ROL](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaRegistro] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[IdRol] [int] NULL,
	[Estado] [bit] NULL,
	[FechaRegistro] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VENTA](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[TipoDocumento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[DocumentoCliente] [varchar](50) NULL,
	[NombreCliente] [varchar](100) NULL,
	[MontoPago] [decimal](10, 2) NULL,
	[MontoCambio] [decimal](10, 2) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CATEGORIA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CLIENTE] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[DETALLE_COMPRA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[DETALLE_VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioCompra]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT ((0)) FOR [PrecioVenta]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PROVEEDOR] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[VENTA] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[DETALLE_COMPRA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[PERMISO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([IdCategoria])
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITARUSUARIO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EDITARUSUARIO](
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

	SET @Respuesta = 0
	SET @Mensaje = ''  

	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Documento = @Documento AND IdUsuario != @IdUsuario)
		BEGIN
			UPDATE USUARIO SET
				Documento = @Documento,
				NombreCompleto = @NombreCompleto,
				Correo = @Correo,
				Clave = @Clave,
				IdRol = @IdRol,
				Estado = @Estado

				WHERE IdUsuario = @IdUsuario

			SET @Respuesta = 1
		END
	ELSE
		SET @Mensaje = 'No se puede repetir el documento para más de un usuario'  

END

GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINARUSUARIO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_ELIMINARUSUARIO](
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
/****** Object:  StoredProcedure [dbo].[SP_REGISTRARUSUARIO]    Script Date: 09/10/2023 21:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SP_REGISTRARUSUARIO](
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

	SET @IdUsuarioResultado = 0
	SET @Mensaje = ''  
	
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Documento = @Documento)
		BEGIN
			INSERT INTO USUARIO(Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
			VALUES(@Documento, @NombreCompleto, @Correo, @Clave, @IdRol, @Estado)

			SET @IdUsuarioResultado = SCOPE_IDENTITY()
		END

	ELSE
		SET @Mensaje = 'No se puede repetir el documento para más de un usuario'  

END
GO
USE [master]
GO
ALTER DATABASE [DBSISTEMA_VENTA] SET  READ_WRITE 
GO
