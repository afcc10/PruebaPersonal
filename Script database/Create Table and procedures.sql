USE [Polizas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutomotoresModels]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutomotoresModels](
	[Placa] [nvarchar](450) NOT NULL,
	[Modelo] [nvarchar](max) NULL,
	[TieneInspeccion] [bit] NOT NULL,
 CONSTRAINT [PK_AutomotoresModels] PRIMARY KEY CLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientesModels]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientesModels](
	[IdentificacionCliente] [nvarchar](450) NOT NULL,
	[NombreCliente] [nvarchar](max) NULL,
	[FechaNacimiento] [datetime2](7) NOT NULL,
	[CiudadResidencia] [nvarchar](max) NULL,
	[DireccionResidencia] [nvarchar](max) NULL,
	[AutomotorPlaca] [nvarchar](450) NULL,
 CONSTRAINT [PK_ClientesModels] PRIMARY KEY CLUSTERED 
(
	[IdentificacionCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoberturasPolizaModels]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoberturasPolizaModels](
	[Id] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_CoberturasPolizaModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolizaCoberturasModels]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolizaCoberturasModels](
	[Id] [uniqueidentifier] NOT NULL,
	[polizaNumeroPoliza] [nvarchar](450) NULL,
	[CoberturaId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PolizaCoberturasModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolizasModels]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolizasModels](
	[NumeroPoliza] [nvarchar](450) NOT NULL,
	[FechaInicioPoliza] [datetime2](7) NOT NULL,
	[ValorMaximoCubierto] [float] NOT NULL,
	[NombrePlanPoliza] [nvarchar](max) NULL,
	[ClienteIdentificacionCliente] [nvarchar](450) NULL,
	[FechaFinPoliza] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PolizasModels] PRIMARY KEY CLUSTERED 
(
	[NumeroPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PolizasModels] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaFinPoliza]
GO
ALTER TABLE [dbo].[ClientesModels]  WITH CHECK ADD  CONSTRAINT [FK_ClientesModels_AutomotoresModels_AutomotorPlaca] FOREIGN KEY([AutomotorPlaca])
REFERENCES [dbo].[AutomotoresModels] ([Placa])
GO
ALTER TABLE [dbo].[ClientesModels] CHECK CONSTRAINT [FK_ClientesModels_AutomotoresModels_AutomotorPlaca]
GO
ALTER TABLE [dbo].[PolizaCoberturasModels]  WITH CHECK ADD  CONSTRAINT [FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId] FOREIGN KEY([CoberturaId])
REFERENCES [dbo].[CoberturasPolizaModels] ([Id])
GO
ALTER TABLE [dbo].[PolizaCoberturasModels] CHECK CONSTRAINT [FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId]
GO
ALTER TABLE [dbo].[PolizaCoberturasModels]  WITH CHECK ADD  CONSTRAINT [FK_PolizaCoberturasModels_PolizasModels_polizaNumeroPoliza] FOREIGN KEY([polizaNumeroPoliza])
REFERENCES [dbo].[PolizasModels] ([NumeroPoliza])
GO
ALTER TABLE [dbo].[PolizaCoberturasModels] CHECK CONSTRAINT [FK_PolizaCoberturasModels_PolizasModels_polizaNumeroPoliza]
GO
ALTER TABLE [dbo].[PolizasModels]  WITH CHECK ADD  CONSTRAINT [FK_PolizasModels_ClientesModels_ClienteIdentificacionCliente] FOREIGN KEY([ClienteIdentificacionCliente])
REFERENCES [dbo].[ClientesModels] ([IdentificacionCliente])
GO
ALTER TABLE [dbo].[PolizasModels] CHECK CONSTRAINT [FK_PolizasModels_ClientesModels_ClienteIdentificacionCliente]
GO
/****** Object:  StoredProcedure [dbo].[sp_consultar_polizas]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_consultar_polizas](
	-- Add the parameters for the stored procedure here
	@numeroPoliza as varchar(450),
	@placa as varchar(450))
AS
BEGIN
	
	SET NOCOUNT ON;

	if (@numeroPoliza <> '' and @placa = '')
		SELECT po.* 
		from PolizasModels po			
		where NumeroPoliza = @numeroPoliza
	
	if (@numeroPoliza = '' and @placa <> '')
		SELECT po.* 
		from PolizasModels po
			inner join ClientesModels cl on cl.IdentificacionCliente = po.ClienteIdentificacionCliente
			inner join AutomotoresModels au on au.Placa = cl.AutomotorPlaca
		where au.Placa = @placa

	if (@numeroPoliza <> '' and @placa <> '')
		SELECT po.* 
		from PolizasModels po
			inner join ClientesModels cl on cl.IdentificacionCliente = po.ClienteIdentificacionCliente
			inner join AutomotoresModels au on au.Placa = cl.AutomotorPlaca
		where au.Placa = @placa
		and   po.NumeroPoliza = @numeroPoliza

    if (@numeroPoliza = '' and @placa = '')
		SELECT po.* 
		from PolizasModels po
		where 1 = 2
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_automores]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_automores](
	-- Add the parameters for the stored procedure here
	@placa as varchar(10))
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from AutomotoresModels
	where Placa = @placa
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_clientes]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_clientes](
	-- Add the parameters for the stored procedure here
	@identificion as varchar(450))
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from ClientesModels
	where IdentificacionCliente = @identificion
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_coberturas]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_coberturas](
	-- Add the parameters for the stored procedure here
	@id as uniqueidentifier)
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from CoberturasPolizaModels
	where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_polizas]    Script Date: 1/03/2022 9:37:53 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_polizas](
	-- Add the parameters for the stored procedure here
	@numeroPoliza as varchar(450))
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	from PolizasModels
	where NumeroPoliza = @numeroPoliza
END
GO
