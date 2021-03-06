USE [master]
GO
/****** Object:  Database [RentCarDB]    Script Date: 12/6/2022 12:43:19 p. m. ******/
CREATE DATABASE [RentCarDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentCarDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RentCarDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RentCarDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RentCarDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RentCarDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentCarDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentCarDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RentCarDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RentCarDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RentCarDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RentCarDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RentCarDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RentCarDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentCarDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentCarDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentCarDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RentCarDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RentCarDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentCarDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RentCarDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentCarDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RentCarDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentCarDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentCarDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentCarDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RentCarDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentCarDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentCarDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentCarDB] SET RECOVERY FULL 
GO
ALTER DATABASE [RentCarDB] SET  MULTI_USER 
GO
ALTER DATABASE [RentCarDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RentCarDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentCarDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RentCarDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RentCarDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RentCarDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RentCarDB', N'ON'
GO
ALTER DATABASE [RentCarDB] SET QUERY_STORE = OFF
GO
USE [RentCarDB]
GO
/****** Object:  Table [dbo].[CantidadCombustible]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CantidadCombustible](
	[CantidadCombustibleId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CantidadCombustibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_CantidadCombustible]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_CantidadCombustible]
AS
SELECT        CantidadCombustibleId, Descripcion, Estado
FROM            dbo.CantidadCombustible
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[TipoPersonaId] [int] NULL,
	[Nombre] [nvarchar](100) NULL,
	[Cedula] [nvarchar](50) NULL,
	[TarjetaCredito] [nvarchar](50) NULL,
	[LimiteCredito] [numeric](18, 2) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Cliente]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Cliente]
AS
SELECT        ClienteId, TipoPersonaId, Nombre, Cedula, TarjetaCredito, LimiteCredito, Estado
FROM            dbo.Cliente
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[TandaLaboralId] [int] NULL,
	[Nombre] [nvarchar](100) NULL,
	[Cedula] [nvarchar](50) NULL,
	[PorcientoComision] [int] NULL,
	[FechaIngreso] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Empleado]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Empleado]
AS
SELECT        EmpleadoId, TandaLaboralId, Nombre, Cedula, PorcientoComision, FechaIngreso, Estado
FROM            dbo.Empleado
GO
/****** Object:  Table [dbo].[Inspeccion]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspeccion](
	[InspeccionId] [int] IDENTITY(1,1) NOT NULL,
	[VehiculoId] [int] NULL,
	[ClienteId] [int] NULL,
	[EmpleadoId] [int] NULL,
	[CantidadCombustibleId] [int] NULL,
	[TieneRalladuras] [bit] NULL,
	[TieneGomaRespuesta] [bit] NULL,
	[TieneGato] [bit] NULL,
	[TieneRoturasCristal] [bit] NULL,
	[GomaDelanteraIzquierda] [bit] NULL,
	[GomaDelanteraDerecha] [bit] NULL,
	[GomaTraceraIzquierda] [bit] NULL,
	[GomaTraceraDerecha] [bit] NULL,
	[Etc] [nvarchar](500) NULL,
	[Fecha] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[InspeccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Inspeccion]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Inspeccion]
AS
SELECT        InspeccionId, VehiculoId, ClienteId, EmpleadoId, CantidadCombustibleId, TieneRalladuras, TieneGomaRespuesta, TieneGato, TieneRoturasCristal, GomaDelanteraIzquierda, GomaDelanteraDerecha, GomaTraceraIzquierda, 
                         GomaTraceraDerecha, Etc, Fecha, Estado
FROM            dbo.Inspeccion
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Marca]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Marca]
AS
SELECT        MarcaId, Descripcion, Estado
FROM            dbo.Marca
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[ModeloId] [int] IDENTITY(1,1) NOT NULL,
	[MarcaId] [int] NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ModeloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Modelo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Modelo]
AS
SELECT        ModeloId, MarcaId, Descripcion, Estado
FROM            dbo.Modelo
GO
/****** Object:  Table [dbo].[Renta]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renta](
	[RentaId] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NULL,
	[VehiculoId] [int] NULL,
	[ClienteId] [int] NULL,
	[FechaRenta] [datetime] NULL,
	[FechaEsperada] [datetime] NULL,
	[FechaDevolucion] [datetime] NULL,
	[MontoDiario] [numeric](18, 2) NULL,
	[Dias] [int] NULL,
	[Comentario] [nvarchar](500) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK__Renta__3440A34352B7577A] PRIMARY KEY CLUSTERED 
(
	[RentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Renta]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Renta]
AS
SELECT        RentaId, EmpleadoId, VehiculoId, ClienteId, FechaRenta, FechaEsperada, FechaDevolucion, MontoDiario, Dias, Comentario, Estado
FROM            dbo.Renta
GO
/****** Object:  Table [dbo].[TandaLaboral]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TandaLaboral](
	[TandaLaboralId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TandaLaboralId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_TandaLaboral]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_TandaLaboral]
AS
SELECT        TandaLaboralId, Descripcion, Estado
FROM            dbo.TandaLaboral
GO
/****** Object:  Table [dbo].[TipoCombustible]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCombustible](
	[TipoCombustibleId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoCombustibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_TipoCombustible]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_TipoCombustible]
AS
SELECT        TipoCombustibleId, Descripcion, Estado
FROM            dbo.TipoCombustible
GO
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[TipoPersonaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoPersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_TipoPersona]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_TipoPersona]
AS
SELECT        TipoPersonaId, Descripcion, Estado
FROM            dbo.TipoPersona
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[TipoVehiculoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoVehiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_TipoVehiculo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_TipoVehiculo]
AS
SELECT        TipoVehiculoId, Descripcion, Estado
FROM            dbo.TipoVehiculo
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[VehiculoId] [int] IDENTITY(1,1) NOT NULL,
	[TipoVehiculoId] [int] NULL,
	[MarcaId] [int] NULL,
	[ModeloId] [int] NULL,
	[TipoCombustibleId] [int] NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Chasis] [nvarchar](250) NULL,
	[Motor] [nvarchar](250) NULL,
	[Placa] [nvarchar](250) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[VehiculoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_Vehiculo]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Vehiculo]
AS
SELECT        VehiculoId, TipoVehiculoId, MarcaId, ModeloId, TipoCombustibleId, Descripcion, Chasis, Motor, Placa, Estado
FROM            dbo.Vehiculo
GO
/****** Object:  View [dbo].[View_Rentas]    Script Date: 12/6/2022 12:43:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Rentas]
AS
SELECT        dbo.Renta.RentaId, dbo.Empleado.Nombre AS Empleado, dbo.Cliente.Nombre AS Cliente, dbo.Vehiculo.Descripcion AS Vehiculo, dbo.Renta.FechaRenta, dbo.Renta.FechaEsperada, dbo.Renta.FechaDevolucion, 
                         dbo.Renta.MontoDiario, dbo.Renta.Dias, dbo.Renta.Comentario, dbo.Renta.Estado, dbo.TipoVehiculo.Descripcion AS TipoVehiculo
FROM            dbo.Renta INNER JOIN
                         dbo.Empleado ON dbo.Renta.EmpleadoId = dbo.Empleado.EmpleadoId INNER JOIN
                         dbo.Cliente ON dbo.Renta.ClienteId = dbo.Cliente.ClienteId INNER JOIN
                         dbo.Vehiculo ON dbo.Renta.VehiculoId = dbo.Vehiculo.VehiculoId INNER JOIN
                         dbo.TipoVehiculo ON dbo.Vehiculo.TipoVehiculoId = dbo.TipoVehiculo.TipoVehiculoId
GO
SET IDENTITY_INSERT [dbo].[CantidadCombustible] ON 

INSERT [dbo].[CantidadCombustible] ([CantidadCombustibleId], [Descripcion], [Estado]) VALUES (1, N'1/4', 1)
INSERT [dbo].[CantidadCombustible] ([CantidadCombustibleId], [Descripcion], [Estado]) VALUES (2, N'1/2', 1)
INSERT [dbo].[CantidadCombustible] ([CantidadCombustibleId], [Descripcion], [Estado]) VALUES (3, N'3/4', 1)
INSERT [dbo].[CantidadCombustible] ([CantidadCombustibleId], [Descripcion], [Estado]) VALUES (4, N'Lleno', 1)
INSERT [dbo].[CantidadCombustible] ([CantidadCombustibleId], [Descripcion], [Estado]) VALUES (5, N'Vacio', 1)
SET IDENTITY_INSERT [dbo].[CantidadCombustible] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [TipoPersonaId], [Nombre], [Cedula], [TarjetaCredito], [LimiteCredito], [Estado]) VALUES (1, 1, N'Randolph', N'40230256022', N'213265465464', CAST(25000.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[Cliente] ([ClienteId], [TipoPersonaId], [Nombre], [Cedula], [TarjetaCredito], [LimiteCredito], [Estado]) VALUES (2, 2, N'Nayhara', N'4023212165', N'321654856', CAST(5000.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[Cliente] ([ClienteId], [TipoPersonaId], [Nombre], [Cedula], [TarjetaCredito], [LimiteCredito], [Estado]) VALUES (3, 1, N'Juan Valdez', N'00110641468', N'546216565161', CAST(-150000.00 AS Numeric(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([EmpleadoId], [TandaLaboralId], [Nombre], [Cedula], [PorcientoComision], [FechaIngreso], [Estado]) VALUES (1, 3, N'Rhansu', N'4023021546', 15, CAST(N'2022-06-03T20:43:00.000' AS DateTime), 1)
INSERT [dbo].[Empleado] ([EmpleadoId], [TandaLaboralId], [Nombre], [Cedula], [PorcientoComision], [FechaIngreso], [Estado]) VALUES (2, 2, N'Miguel cotton', N'40362354215', 25, CAST(N'2022-06-11T10:51:20.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Inspeccion] ON 

INSERT [dbo].[Inspeccion] ([InspeccionId], [VehiculoId], [ClienteId], [EmpleadoId], [CantidadCombustibleId], [TieneRalladuras], [TieneGomaRespuesta], [TieneGato], [TieneRoturasCristal], [GomaDelanteraIzquierda], [GomaDelanteraDerecha], [GomaTraceraIzquierda], [GomaTraceraDerecha], [Etc], [Fecha], [Estado]) VALUES (1, 1, 2, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, N'Visto bueno', CAST(N'2022-03-15T21:16:45.000' AS DateTime), 1)
INSERT [dbo].[Inspeccion] ([InspeccionId], [VehiculoId], [ClienteId], [EmpleadoId], [CantidadCombustibleId], [TieneRalladuras], [TieneGomaRespuesta], [TieneGato], [TieneRoturasCristal], [GomaDelanteraIzquierda], [GomaDelanteraDerecha], [GomaTraceraIzquierda], [GomaTraceraDerecha], [Etc], [Fecha], [Estado]) VALUES (2, 3, 3, 2, 4, 0, 1, 1, 0, 1, 1, 1, 1, N'En buen estado', CAST(N'2022-06-12T10:53:06.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Inspeccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([MarcaId], [Descripcion], [Estado]) VALUES (1, N'Toyota', 1)
INSERT [dbo].[Marca] ([MarcaId], [Descripcion], [Estado]) VALUES (2, N'Kia', 1)
INSERT [dbo].[Marca] ([MarcaId], [Descripcion], [Estado]) VALUES (3, N'Mazda', 1)
INSERT [dbo].[Marca] ([MarcaId], [Descripcion], [Estado]) VALUES (4, N'Hyundai', 1)
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 

INSERT [dbo].[Modelo] ([ModeloId], [MarcaId], [Descripcion], [Estado]) VALUES (1, 1, N'Corolla', 1)
INSERT [dbo].[Modelo] ([ModeloId], [MarcaId], [Descripcion], [Estado]) VALUES (2, 2, N'Picanto', 1)
INSERT [dbo].[Modelo] ([ModeloId], [MarcaId], [Descripcion], [Estado]) VALUES (3, 4, N'Y20', 1)
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[Renta] ON 

INSERT [dbo].[Renta] ([RentaId], [EmpleadoId], [VehiculoId], [ClienteId], [FechaRenta], [FechaEsperada], [FechaDevolucion], [MontoDiario], [Dias], [Comentario], [Estado]) VALUES (1, 1, 1, 1, CAST(N'2022-06-01T21:49:33.000' AS DateTime), CAST(N'2022-06-04T21:49:33.000' AS DateTime), CAST(N'2022-06-11T22:57:16.757' AS DateTime), CAST(700.00 AS Numeric(18, 2)), 3, N'Entregado en perfecto estado', 0)
INSERT [dbo].[Renta] ([RentaId], [EmpleadoId], [VehiculoId], [ClienteId], [FechaRenta], [FechaEsperada], [FechaDevolucion], [MontoDiario], [Dias], [Comentario], [Estado]) VALUES (2, 1, 1, 1, CAST(N'2022-06-01T21:49:33.000' AS DateTime), CAST(N'2022-06-04T21:49:33.000' AS DateTime), NULL, CAST(700.00 AS Numeric(18, 2)), 3, N'Entregado en perfecto estado', 1)
INSERT [dbo].[Renta] ([RentaId], [EmpleadoId], [VehiculoId], [ClienteId], [FechaRenta], [FechaEsperada], [FechaDevolucion], [MontoDiario], [Dias], [Comentario], [Estado]) VALUES (3, 1, 2, 2, CAST(N'2022-06-01T21:49:33.000' AS DateTime), CAST(N'2022-06-07T21:49:33.000' AS DateTime), NULL, CAST(5200.00 AS Numeric(18, 2)), 6, N'Entregado en perfecto estado', 1)
INSERT [dbo].[Renta] ([RentaId], [EmpleadoId], [VehiculoId], [ClienteId], [FechaRenta], [FechaEsperada], [FechaDevolucion], [MontoDiario], [Dias], [Comentario], [Estado]) VALUES (4, 2, 3, 3, CAST(N'2022-06-12T10:53:57.920' AS DateTime), CAST(N'2022-06-17T10:53:57.920' AS DateTime), CAST(N'2022-06-12T10:55:14.807' AS DateTime), CAST(1700.00 AS Numeric(18, 2)), 5, N'Entregado en buen estado y con el tanque lleno', 0)
INSERT [dbo].[Renta] ([RentaId], [EmpleadoId], [VehiculoId], [ClienteId], [FechaRenta], [FechaEsperada], [FechaDevolucion], [MontoDiario], [Dias], [Comentario], [Estado]) VALUES (5, 2, 3, 3, CAST(N'2022-06-12T10:53:57.000' AS DateTime), CAST(N'2022-06-17T10:53:57.000' AS DateTime), NULL, CAST(1700.00 AS Numeric(18, 2)), 5, N'Entregado en buen estado y con el tanque lleno', 1)
SET IDENTITY_INSERT [dbo].[Renta] OFF
GO
SET IDENTITY_INSERT [dbo].[TandaLaboral] ON 

INSERT [dbo].[TandaLaboral] ([TandaLaboralId], [Descripcion], [Estado]) VALUES (1, N'Matutina', 1)
INSERT [dbo].[TandaLaboral] ([TandaLaboralId], [Descripcion], [Estado]) VALUES (2, N'Vespertina', 1)
INSERT [dbo].[TandaLaboral] ([TandaLaboralId], [Descripcion], [Estado]) VALUES (3, N'Nocturna', 1)
INSERT [dbo].[TandaLaboral] ([TandaLaboralId], [Descripcion], [Estado]) VALUES (4, N'Full time', 1)
SET IDENTITY_INSERT [dbo].[TandaLaboral] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCombustible] ON 

INSERT [dbo].[TipoCombustible] ([TipoCombustibleId], [Descripcion], [Estado]) VALUES (1, N'Gasolina', 1)
INSERT [dbo].[TipoCombustible] ([TipoCombustibleId], [Descripcion], [Estado]) VALUES (2, N'GLP', 1)
INSERT [dbo].[TipoCombustible] ([TipoCombustibleId], [Descripcion], [Estado]) VALUES (3, N'Gasoil', 1)
SET IDENTITY_INSERT [dbo].[TipoCombustible] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPersona] ON 

INSERT [dbo].[TipoPersona] ([TipoPersonaId], [Descripcion], [Estado]) VALUES (1, N'Fisica', 1)
INSERT [dbo].[TipoPersona] ([TipoPersonaId], [Descripcion], [Estado]) VALUES (2, N'Juridica', NULL)
INSERT [dbo].[TipoPersona] ([TipoPersonaId], [Descripcion], [Estado]) VALUES (3, N'Otros', 1)
SET IDENTITY_INSERT [dbo].[TipoPersona] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoVehiculo] ON 

INSERT [dbo].[TipoVehiculo] ([TipoVehiculoId], [Descripcion], [Estado]) VALUES (1, N'Sedan', 1)
INSERT [dbo].[TipoVehiculo] ([TipoVehiculoId], [Descripcion], [Estado]) VALUES (2, N'Convertible', 1)
INSERT [dbo].[TipoVehiculo] ([TipoVehiculoId], [Descripcion], [Estado]) VALUES (3, N'Deportivo', 0)
INSERT [dbo].[TipoVehiculo] ([TipoVehiculoId], [Descripcion], [Estado]) VALUES (4, N'Hashback1', 1)
SET IDENTITY_INSERT [dbo].[TipoVehiculo] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

INSERT [dbo].[Vehiculo] ([VehiculoId], [TipoVehiculoId], [MarcaId], [ModeloId], [TipoCombustibleId], [Descripcion], [Chasis], [Motor], [Placa], [Estado]) VALUES (1, 1, 1, 1, 1, N'Toyota corolla blanco', N'321654154', N'16546516', N'A004568', 1)
INSERT [dbo].[Vehiculo] ([VehiculoId], [TipoVehiculoId], [MarcaId], [ModeloId], [TipoCombustibleId], [Descripcion], [Chasis], [Motor], [Placa], [Estado]) VALUES (2, 1, 2, 2, 1, N'Kia Picanto negro', N'165464', N'1984651', N'A001452', 1)
INSERT [dbo].[Vehiculo] ([VehiculoId], [TipoVehiculoId], [MarcaId], [ModeloId], [TipoCombustibleId], [Descripcion], [Chasis], [Motor], [Placa], [Estado]) VALUES (3, 1, 4, 3, 2, N'Hyundai sonata Y20 gris', N'21651651', N'61651651', N'A004568', 1)
INSERT [dbo].[Vehiculo] ([VehiculoId], [TipoVehiculoId], [MarcaId], [ModeloId], [TipoCombustibleId], [Descripcion], [Chasis], [Motor], [Placa], [Estado]) VALUES (4, 3, 1, 1, 1, N'Rosangel', N'464651651', N'215151621', N'A325654', 1)
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([TipoPersonaId])
REFERENCES [dbo].[TipoPersona] ([TipoPersonaId])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([TandaLaboralId])
REFERENCES [dbo].[TandaLaboral] ([TandaLaboralId])
GO
ALTER TABLE [dbo].[Inspeccion]  WITH CHECK ADD FOREIGN KEY([CantidadCombustibleId])
REFERENCES [dbo].[CantidadCombustible] ([CantidadCombustibleId])
GO
ALTER TABLE [dbo].[Inspeccion]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Inspeccion]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([EmpleadoId])
GO
ALTER TABLE [dbo].[Inspeccion]  WITH CHECK ADD FOREIGN KEY([VehiculoId])
REFERENCES [dbo].[Vehiculo] ([VehiculoId])
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([MarcaId])
GO
ALTER TABLE [dbo].[Renta]  WITH CHECK ADD  CONSTRAINT [FK__Renta__ClienteId__45F365D3] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Renta] CHECK CONSTRAINT [FK__Renta__ClienteId__45F365D3]
GO
ALTER TABLE [dbo].[Renta]  WITH CHECK ADD  CONSTRAINT [FK__Renta__EmpleadoI__440B1D61] FOREIGN KEY([EmpleadoId])
REFERENCES [dbo].[Empleado] ([EmpleadoId])
GO
ALTER TABLE [dbo].[Renta] CHECK CONSTRAINT [FK__Renta__EmpleadoI__440B1D61]
GO
ALTER TABLE [dbo].[Renta]  WITH CHECK ADD  CONSTRAINT [FK__Renta__VehiculoI__44FF419A] FOREIGN KEY([VehiculoId])
REFERENCES [dbo].[Vehiculo] ([VehiculoId])
GO
ALTER TABLE [dbo].[Renta] CHECK CONSTRAINT [FK__Renta__VehiculoI__44FF419A]
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([MarcaId])
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([ModeloId])
REFERENCES [dbo].[Modelo] ([ModeloId])
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([TipoCombustibleId])
REFERENCES [dbo].[TipoCombustible] ([TipoCombustibleId])
GO
ALTER TABLE [dbo].[Vehiculo]  WITH CHECK ADD FOREIGN KEY([TipoVehiculoId])
REFERENCES [dbo].[TipoVehiculo] ([TipoVehiculoId])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CantidadCombustible"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 253
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_CantidadCombustible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_CantidadCombustible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cliente"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Empleado"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Empleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Empleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Inspeccion"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 12
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Inspeccion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Inspeccion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Marca"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Marca'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Marca'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Modelo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Modelo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Modelo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Renta"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Renta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Renta'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Renta"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Empleado"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 136
               Right = 447
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cliente"
            Begin Extent = 
               Top = 149
               Left = 257
               Bottom = 285
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vehiculo"
            Begin Extent = 
               Top = 112
               Left = 514
               Bottom = 242
               Right = 704
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TipoVehiculo"
            Begin Extent = 
               Top = 6
               Left = 742
               Bottom = 119
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1815
         Width = 1980
         Width = 1980
         Width = 1500
         Width = 1200
         Width = 525
         Width = 2445
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Rentas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Rentas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Rentas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TandaLaboral"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TandaLaboral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TandaLaboral'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TipoCombustible"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoCombustible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoCombustible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TipoPersona"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoPersona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoPersona'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TipoVehiculo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoVehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TipoVehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Vehiculo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Vehiculo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Vehiculo'
GO
USE [master]
GO
ALTER DATABASE [RentCarDB] SET  READ_WRITE 
GO
