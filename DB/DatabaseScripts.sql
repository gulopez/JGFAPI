USE [master]
GO
/****** Object:  Database [WebFortoul]    Script Date: 10/24/2020 8:35:07 AM ******/
CREATE DATABASE [WebFortoul]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebFortoul', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebFortoul2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebFortoul_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WebFortoul2_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebFortoul] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebFortoul].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebFortoul] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebFortoul] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebFortoul] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebFortoul] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebFortoul] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebFortoul] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebFortoul] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebFortoul] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebFortoul] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebFortoul] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebFortoul] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebFortoul] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebFortoul] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebFortoul] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebFortoul] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebFortoul] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebFortoul] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebFortoul] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebFortoul] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebFortoul] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebFortoul] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebFortoul] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebFortoul] SET RECOVERY FULL 
GO
ALTER DATABASE [WebFortoul] SET  MULTI_USER 
GO
ALTER DATABASE [WebFortoul] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebFortoul] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebFortoul] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebFortoul] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebFortoul] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebFortoul', N'ON'
GO
ALTER DATABASE [WebFortoul] SET QUERY_STORE = OFF
GO
USE [WebFortoul]
GO
/****** Object:  User [JGFWebAPIUser]    Script Date: 10/24/2020 8:35:08 AM ******/
CREATE USER [JGFWebAPIUser] FOR LOGIN [JGFWebAPIUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [JGFWebAPIUser]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Id] [uniqueidentifier] NOT NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[Sexo] [char](1) NOT NULL,
	[CedulaAlumno] [varchar](50) NULL,
	[CarnetEstudiante] [varchar](50) NULL,
	[LugardeNacimiento] [varchar](50) NOT NULL,
	[EstadoDeNacimiento] [varchar](50) NOT NULL,
	[PaisDeNacimiento] [varchar](50) NOT NULL,
	[FechaDeNacimiento] [date] NOT NULL,
	[Telefono] [varchar](50) NULL,
	[TelefonoAdicional] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Comentarios] [varchar](200) NULL,
	[IdRepresentante] [uniqueidentifier] NOT NULL,
	[IdPadre] [uniqueidentifier] NOT NULL,
	[IdMadre] [uniqueidentifier] NOT NULL,
	[Escolaridad] [varchar](50) NULL,
	[Materias] [varchar](60) NULL,
	[PlantelProcedencia] [varchar](50) NULL,
	[IdDireccion] [uniqueidentifier] NOT NULL,
	[IdDatosMedicos] [uniqueidentifier] NOT NULL,
	[IdDatosFamiliares] [uniqueidentifier] NOT NULL,
	[IdPeriodoEscolar] [uniqueidentifier] NOT NULL,
	[IdGradoEscolar] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarritoCompra]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarritoCompra](
	[Id] [uniqueidentifier] NOT NULL,
	[IdAlumno] [uniqueidentifier] NOT NULL,
	[IdPeriodoEscolar] [uniqueidentifier] NOT NULL,
	[IdConceptoPago] [uniqueidentifier] NOT NULL,
	[IdMesEscolar] [uniqueidentifier] NULL,
	[MontoPagar] [decimal](11, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptoPago]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptoPago](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ConceptoPago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatosFamiliares]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosFamiliares](
	[Id] [uniqueidentifier] NOT NULL,
	[Religion] [varchar](50) NULL,
	[Hermanos] [varchar](100) NULL,
	[Ingresos] [varchar](50) NULL,
	[Personas] [varchar](50) NULL,
	[EstadoCivil] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatosMedicos]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosMedicos](
	[Id] [uniqueidentifier] NOT NULL,
	[IsAlergias] [bit] NOT NULL,
	[Alergias] [varchar](100) NULL,
	[IsServiciosMedicos] [bit] NOT NULL,
	[Servicios] [varchar](50) NULL,
	[IsAfeccion] [bit] NOT NULL,
	[Afeccion] [varchar](100) NULL,
	[IsTratamiento] [bit] NOT NULL,
	[Tratamiento] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[Id] [uniqueidentifier] NOT NULL,
	[IdEstadoProvincia] [uniqueidentifier] NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[Linea1] [varchar](400) NOT NULL,
	[Linea2] [varchar](400) NULL,
	[Sector] [varchar](50) NOT NULL,
	[Urbanizacion] [varchar](50) NOT NULL,
	[CodigoPostal] [varchar](10) NULL,
	[FechaModificacion] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [uniqueidentifier] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCivil](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoProvincia]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoProvincia](
	[Id] [uniqueidentifier] NOT NULL,
	[IdPais] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormaPago]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaPago](
	[Id] [uniqueidentifier] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradoEscolar]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradoEscolar](
	[Id] [uniqueidentifier] NOT NULL,
	[Grado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MesEscolar]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesEscolar](
	[Id] [uniqueidentifier] NOT NULL,
	[Mes] [varchar](50) NOT NULL,
	[Numero] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagoDetallado]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagoDetallado](
	[Id] [uniqueidentifier] NOT NULL,
	[IdPagoMaster] [uniqueidentifier] NOT NULL,
	[IdConceptoPago] [uniqueidentifier] NOT NULL,
	[IdMesEscolar] [uniqueidentifier] NULL,
	[Monto] [decimal](11, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagoMaster]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagoMaster](
	[Id] [uniqueidentifier] NOT NULL,
	[IdAlumno] [uniqueidentifier] NOT NULL,
	[IdPeriodoEscolar] [uniqueidentifier] NOT NULL,
	[Monto] [decimal](11, 2) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[TwoLetterIsoCode] [nvarchar](2) NULL,
	[ThreeLetterIsoCode] [nvarchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeriodoEscolar]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodoEscolar](
	[Id] [uniqueidentifier] NOT NULL,
	[Periodo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreInscripcion]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreInscripcion](
	[Id] [uniqueidentifier] NOT NULL,
	[IdAlumno] [uniqueidentifier] NOT NULL,
	[IdPeriodoEscolar] [uniqueidentifier] NOT NULL,
	[FechaPreInscripcion] [date] NOT NULL,
	[IdGradoEscolar] [uniqueidentifier] NOT NULL,
	[Actualizado] [date] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[Comentarios] [varchar](4000) NULL,
	[IdEstado] [uniqueidentifier] NOT NULL,
	[IdRepresentante] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Representante]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Representante](
	[Id] [uniqueidentifier] NOT NULL,
	[Parentesco] [varchar](50) NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[CedulaRepresentante] [varchar](4000) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[TelefonoAdicional] [varchar](50) NULL,
	[Ocupacion] [varchar](50) NOT NULL,
	[Email] [varchar](4000) NOT NULL,
	[Edad] [int] NOT NULL,
	[Profesion] [varchar](50) NULL,
	[EmpresaTrabaja] [varchar](50) NULL,
	[IdDireccion] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudCupo]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudCupo](
	[Id] [uniqueidentifier] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[IdAlumno] [uniqueidentifier] NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NULL,
	[PrimerApellido] [varchar](50) NOT NULL,
	[SegundoApellido] [varchar](50) NULL,
	[Sexo] [char](1) NOT NULL,
	[FechaDeNacimiento] [date] NOT NULL,
	[IdPeriodoEscolar] [uniqueidentifier] NOT NULL,
	[IdGradoEscolar] [uniqueidentifier] NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
	[TelefonoAdicional] [varchar](12) NULL,
	[IdEstado] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/24/2020 8:35:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[CedulaIdentidad] [varchar](10) NULL,
	[Clave] [varchar](60) NOT NULL,
	[IdPerfil] [uniqueidentifier] NOT NULL,
	[Estado] [bit] NOT NULL,
	[SolicitarClave] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MesEscolar] ADD  DEFAULT ((0)) FOR [Numero]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_DatosFamiliares] FOREIGN KEY([IdDatosFamiliares])
REFERENCES [dbo].[DatosFamiliares] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_DatosFamiliares]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_DatosMedicos] FOREIGN KEY([IdDatosMedicos])
REFERENCES [dbo].[DatosMedicos] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_DatosMedicos]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Direccion]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_GradoEscolar] FOREIGN KEY([IdGradoEscolar])
REFERENCES [dbo].[GradoEscolar] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_GradoEscolar]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Madre] FOREIGN KEY([IdMadre])
REFERENCES [dbo].[Representante] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Madre]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Padre] FOREIGN KEY([IdPadre])
REFERENCES [dbo].[Representante] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Padre]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_PeriodoEscolar]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Representante] FOREIGN KEY([IdRepresentante])
REFERENCES [dbo].[Representante] ([Id])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Representante]
GO
ALTER TABLE [dbo].[CarritoCompra]  WITH CHECK ADD  CONSTRAINT [FK_CarritoCompra_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[CarritoCompra] CHECK CONSTRAINT [FK_CarritoCompra_Alumno]
GO
ALTER TABLE [dbo].[CarritoCompra]  WITH CHECK ADD  CONSTRAINT [FK_CarritoCompra_ConceptoPago] FOREIGN KEY([IdConceptoPago])
REFERENCES [dbo].[ConceptoPago] ([Id])
GO
ALTER TABLE [dbo].[CarritoCompra] CHECK CONSTRAINT [FK_CarritoCompra_ConceptoPago]
GO
ALTER TABLE [dbo].[CarritoCompra]  WITH CHECK ADD  CONSTRAINT [FK_CarritoCompra_MesEscolar] FOREIGN KEY([IdMesEscolar])
REFERENCES [dbo].[MesEscolar] ([Id])
GO
ALTER TABLE [dbo].[CarritoCompra] CHECK CONSTRAINT [FK_CarritoCompra_MesEscolar]
GO
ALTER TABLE [dbo].[CarritoCompra]  WITH CHECK ADD  CONSTRAINT [FK_CarritoCompra_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([Id])
GO
ALTER TABLE [dbo].[CarritoCompra] CHECK CONSTRAINT [FK_CarritoCompra_PeriodoEscolar]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_ProvinciaEstado] FOREIGN KEY([IdEstadoProvincia])
REFERENCES [dbo].[EstadoProvincia] ([Id])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_ProvinciaEstado]
GO
ALTER TABLE [dbo].[EstadoProvincia]  WITH CHECK ADD  CONSTRAINT [FK_EstadoProvincia_Pais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([Id])
GO
ALTER TABLE [dbo].[EstadoProvincia] CHECK CONSTRAINT [FK_EstadoProvincia_Pais]
GO
ALTER TABLE [dbo].[PagoDetallado]  WITH CHECK ADD  CONSTRAINT [FK_PagoDetallado_ConceptoPago] FOREIGN KEY([IdConceptoPago])
REFERENCES [dbo].[ConceptoPago] ([Id])
GO
ALTER TABLE [dbo].[PagoDetallado] CHECK CONSTRAINT [FK_PagoDetallado_ConceptoPago]
GO
ALTER TABLE [dbo].[PagoDetallado]  WITH CHECK ADD  CONSTRAINT [FK_PagoDetallado_MesEscolar] FOREIGN KEY([IdMesEscolar])
REFERENCES [dbo].[MesEscolar] ([Id])
GO
ALTER TABLE [dbo].[PagoDetallado] CHECK CONSTRAINT [FK_PagoDetallado_MesEscolar]
GO
ALTER TABLE [dbo].[PagoDetallado]  WITH CHECK ADD  CONSTRAINT [FK_PagoDetallado_PagoMaster] FOREIGN KEY([IdPagoMaster])
REFERENCES [dbo].[PagoMaster] ([Id])
GO
ALTER TABLE [dbo].[PagoDetallado] CHECK CONSTRAINT [FK_PagoDetallado_PagoMaster]
GO
ALTER TABLE [dbo].[PagoMaster]  WITH CHECK ADD  CONSTRAINT [FK_PagoMaster_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[PagoMaster] CHECK CONSTRAINT [FK_PagoMaster_Alumno]
GO
ALTER TABLE [dbo].[PagoMaster]  WITH CHECK ADD  CONSTRAINT [FK_PagoMaster_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([Id])
GO
ALTER TABLE [dbo].[PagoMaster] CHECK CONSTRAINT [FK_PagoMaster_PeriodoEscolar]
GO
ALTER TABLE [dbo].[PreInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PreInscripcion_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[PreInscripcion] CHECK CONSTRAINT [FK_PreInscripcion_Alumno]
GO
ALTER TABLE [dbo].[PreInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PreInscripcion_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[PreInscripcion] CHECK CONSTRAINT [FK_PreInscripcion_Estado]
GO
ALTER TABLE [dbo].[PreInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PreInscripcion_GradoEscolar] FOREIGN KEY([IdGradoEscolar])
REFERENCES [dbo].[GradoEscolar] ([Id])
GO
ALTER TABLE [dbo].[PreInscripcion] CHECK CONSTRAINT [FK_PreInscripcion_GradoEscolar]
GO
ALTER TABLE [dbo].[PreInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PreInscripcion_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([Id])
GO
ALTER TABLE [dbo].[PreInscripcion] CHECK CONSTRAINT [FK_PreInscripcion_PeriodoEscolar]
GO
ALTER TABLE [dbo].[PreInscripcion]  WITH CHECK ADD  CONSTRAINT [FK_PreInscripcion_Representante] FOREIGN KEY([IdRepresentante])
REFERENCES [dbo].[Representante] ([Id])
GO
ALTER TABLE [dbo].[PreInscripcion] CHECK CONSTRAINT [FK_PreInscripcion_Representante]
GO
ALTER TABLE [dbo].[Representante]  WITH CHECK ADD  CONSTRAINT [FK_Representante_Direccion] FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([Id])
GO
ALTER TABLE [dbo].[Representante] CHECK CONSTRAINT [FK_Representante_Direccion]
GO
ALTER TABLE [dbo].[SolicitudCupo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCupo_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[SolicitudCupo] CHECK CONSTRAINT [FK_SolicitudCupo_Alumno]
GO
ALTER TABLE [dbo].[SolicitudCupo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCupo_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[SolicitudCupo] CHECK CONSTRAINT [FK_SolicitudCupo_Estado]
GO
ALTER TABLE [dbo].[SolicitudCupo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCupo_GradoEscolar] FOREIGN KEY([IdGradoEscolar])
REFERENCES [dbo].[GradoEscolar] ([Id])
GO
ALTER TABLE [dbo].[SolicitudCupo] CHECK CONSTRAINT [FK_SolicitudCupo_GradoEscolar]
GO
ALTER TABLE [dbo].[SolicitudCupo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCupo_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([Id])
GO
ALTER TABLE [dbo].[SolicitudCupo] CHECK CONSTRAINT [FK_SolicitudCupo_PeriodoEscolar]
GO
ALTER TABLE [dbo].[SolicitudCupo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCupo_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[SolicitudCupo] CHECK CONSTRAINT [FK_SolicitudCupo_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
USE [master]
GO
ALTER DATABASE [WebFortoul] SET  READ_WRITE 
GO
