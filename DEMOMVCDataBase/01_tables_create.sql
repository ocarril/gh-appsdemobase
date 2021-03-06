USE [BD_GC_DEMO]
GO

CREATE SCHEMA GestionComercial
GO

CREATE SCHEMA Maestros
go


/****** Object:  Table [GestionComercial].[DocumentoEstado]    Script Date: 25/12/2020 06:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GestionComercial].[DocumentoEstado](
	[codDocumentoEstado] [int] IDENTITY(1,1) NOT NULL,
	[codRegDocumento] [varchar](17) NOT NULL,
	[codRegEstado] [varchar](17) NOT NULL,
	[codEstado] [int] NULL,
	[indActivo] [bit] NOT NULL,
	[segUsuarioCrea] [varchar](50) NOT NULL,
	[segUsuarioEdita] [varchar](50) NULL,
	[segFechaCrea] [datetime] NOT NULL,
	[segFechaEdita] [datetime] NULL,
	[segMaquina] [varchar](30) NOT NULL,
	[codRegEstadoAnterior] [varchar](17) NULL,
 CONSTRAINT [PK_DocumentoEstado] PRIMARY KEY CLUSTERED 
(
	[codDocumentoEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATABASE01]
) ON [DATABASE01]
GO
/****** Object:  Table [GestionComercial].[TipoDeCambio]    Script Date: 25/12/2020 06:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GestionComercial].[TipoDeCambio](
	[codTipoCambio] [int] IDENTITY(1,1) NOT NULL,
	[FechaProceso] [date] NOT NULL,
	[CodigoArguMoneda] [varchar](17) NOT NULL,
	[CambioCompraGOB] [decimal](6, 4) NOT NULL,
	[CambioVentasGOB] [decimal](6, 4) NOT NULL,
	[CambioCompraPRL] [decimal](6, 4) NOT NULL,
	[CambioVentasPRL] [decimal](6, 4) NOT NULL,
	[Estado] [bit] NOT NULL,
	[SegUsuarioCrea] [varchar](50) NOT NULL,
	[SegUsuarioEdita] [varchar](50) NULL,
	[SegFechaCrea] [datetime] NOT NULL,
	[SegFechaEdita] [datetime] NULL,
	[SegMaquina] [varchar](30) NOT NULL,
	[codEmpresa] [int] NOT NULL,
 CONSTRAINT [TipoDeCambio_PK_codTipoCambio] PRIMARY KEY NONCLUSTERED 
(
	[codTipoCambio] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 75) ON [DATABASE01]
) ON [DATABASE01]
GO
/****** Object:  Table [Maestros].[Configuracion]    Script Date: 25/12/2020 06:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maestros].[Configuracion](
	[codConfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[codKeyConfig] [varchar](30) NOT NULL,
	[codTabla] [char](15) NULL,
	[numNivel] [int] NULL,
	[indOrden] [char](4) NOT NULL,
	[indTipoValor] [varchar](50) NOT NULL,
	[desValor] [varchar](200) NOT NULL,
	[desNombre] [varchar](200) NOT NULL,
	[gloDescripcion] [varchar](500) NULL,
	[indGenerico] [bit] NOT NULL,
	[indActivo] [bit] NOT NULL,
	[segUsuarioCrea] [varchar](50) NOT NULL,
	[segUsuarioEdita] [varchar](50) NULL,
	[segFechaCrea] [datetime] NOT NULL,
	[segFechaEdita] [datetime] NULL,
	[segMaquina] [varchar](40) NOT NULL,
	[desGrupo] [varchar](20) NULL,
	[indConfig] [varchar](250) NULL,
	[codEmpresa] [int] NOT NULL,
 CONSTRAINT [Configuracion_PK_codConfiguracion] PRIMARY KEY CLUSTERED 
(
	[codConfiguracion] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [DATABASE01]
) ON [DATABASE01]
GO
/****** Object:  Table [Maestros].[TablasMaestras]    Script Date: 25/12/2020 06:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maestros].[TablasMaestras](
	[CodigoTabla] [char](5) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[Niveles] [bit] NOT NULL,
	[LongitudNivel] [int] NOT NULL,
	[TipoArgumento] [char](1) NOT NULL,
	[TipoGeneracion] [char](1) NOT NULL,
	[Estado] [bit] NOT NULL,
	[SegUsuarioCrea] [varchar](50) NOT NULL,
	[SegUsuarioEdita] [varchar](50) NULL,
	[SegFechaHoraCrea] [datetime] NOT NULL,
	[SegFechaHoraEdita] [datetime] NULL,
	[SegMaquinaOrigen] [varchar](50) NOT NULL,
 CONSTRAINT [TablasMaestras_PK_CodigoTabla] PRIMARY KEY CLUSTERED 
(
	[CodigoTabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATABASE01]
) ON [DATABASE01]
GO
/****** Object:  Table [Maestros].[TablasMaestrasRegistros]    Script Date: 25/12/2020 06:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Maestros].[TablasMaestrasRegistros](
	[CodigoTabla] [char](5) NOT NULL,
	[CodigoArgumento] [varchar](17) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[Nivel] [int] NOT NULL,
	[ValorDecimal] [decimal](15, 5) NULL,
	[ValorCadena] [varchar](100) NULL,
	[ValorBoolean] [bit] NULL,
	[ValorEntero] [int] NULL,
	[ValorFecha] [datetime] NULL,
	[Estado] [bit] NOT NULL,
	[Dependencia] [int] NOT NULL,
	[SegUsuarioCrea] [varchar](50) NOT NULL,
	[SegUsuarioEdita] [varchar](50) NULL,
	[SegFechaHoraCrea] [datetime] NOT NULL,
	[SegFechaHoraEdita] [datetime] NULL,
	[SegMaquinaOrigen] [varchar](50) NOT NULL,
	[codValorSUNAT] [varchar](20) NULL,
	[codigoTMP] [varchar](50) NULL,
 CONSTRAINT [TablasMaestrasRegistros_PK_CodigoTabla_CodigoArgumento] PRIMARY KEY CLUSTERED 
(
	[CodigoArgumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATABASE01]
) ON [DATABASE01]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] ADD  CONSTRAINT [DEF_DocumentoEstado_indActivo]  DEFAULT ((1)) FOR [indActivo]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] ADD  CONSTRAINT [DEF_DocumentoEstado_segUsuarioCrea]  DEFAULT (user_name()) FOR [segUsuarioCrea]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] ADD  CONSTRAINT [DEF_DocumentoEstado_segFechaCrea]  DEFAULT (getdate()) FOR [segFechaCrea]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] ADD  CONSTRAINT [DEF_DocumentoEstado_segMaquina]  DEFAULT (host_name()) FOR [segMaquina]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT ((0)) FOR [CambioCompraGOB]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT ((0)) FOR [CambioVentasGOB]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT ((0)) FOR [CambioCompraPRL]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT ((0)) FOR [CambioVentasPRL]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT (user_name()) FOR [SegUsuarioCrea]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT (getdate()) FOR [SegFechaCrea]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] ADD  DEFAULT (host_name()) FOR [SegMaquina]
GO
ALTER TABLE [Maestros].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_indActivo]  DEFAULT ((1)) FOR [indActivo]
GO
ALTER TABLE [Maestros].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_segUsuarioCrea]  DEFAULT (user_name()) FOR [segUsuarioCrea]
GO
ALTER TABLE [Maestros].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_segFechaCrea]  DEFAULT (getdate()) FOR [segFechaCrea]
GO
ALTER TABLE [Maestros].[Configuracion] ADD  CONSTRAINT [DF_Configuracion_segMaquina]  DEFAULT (host_name()) FOR [segMaquina]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_Niveles]  DEFAULT ((1)) FOR [Niveles]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_LongitudNivel]  DEFAULT ((3)) FOR [LongitudNivel]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_TipoArgumento]  DEFAULT ('A') FOR [TipoArgumento]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_TipoGeneracion]  DEFAULT ('A') FOR [TipoGeneracion]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_SegFechaHoraCrea]  DEFAULT (getdate()) FOR [SegFechaHoraCrea]
GO
ALTER TABLE [Maestros].[TablasMaestras] ADD  CONSTRAINT [DEF_Maestros_TablasMaestras_SegMaquinaOrigen]  DEFAULT (host_name()) FOR [SegMaquinaOrigen]
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros] ADD  CONSTRAINT [DEF_Maestros_TablasMaestrasRegistros_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros] ADD  CONSTRAINT [DEF_Maestros_TablasMaestrasRegistros_Dependencia]  DEFAULT ((0)) FOR [Dependencia]
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros] ADD  CONSTRAINT [DEF_Maestros_TablasMaestrasRegistros_SegFechaHoraCrea]  DEFAULT (getdate()) FOR [SegFechaHoraCrea]
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros] ADD  CONSTRAINT [DEF_Maestros_TablasMaestrasRegistros_SegMaquinaOrigen]  DEFAULT (host_name()) FOR [SegMaquinaOrigen]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado]  WITH CHECK ADD  CONSTRAINT [DocumentoEstado_FK01_codRegDocumento] FOREIGN KEY([codRegDocumento])
REFERENCES [Maestros].[TablasMaestrasRegistros] ([CodigoArgumento])
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] CHECK CONSTRAINT [DocumentoEstado_FK01_codRegDocumento]
GO
ALTER TABLE [GestionComercial].[DocumentoEstado]  WITH CHECK ADD  CONSTRAINT [DocumentoEstado_FK02_codRegEstado] FOREIGN KEY([codRegEstado])
REFERENCES [Maestros].[TablasMaestrasRegistros] ([CodigoArgumento])
GO
ALTER TABLE [GestionComercial].[DocumentoEstado] CHECK CONSTRAINT [DocumentoEstado_FK02_codRegEstado]
GO
ALTER TABLE [GestionComercial].[TipoDeCambio]  WITH CHECK ADD  CONSTRAINT [TipodeCambio_FK01_CodigoArguMoneda] FOREIGN KEY([CodigoArguMoneda])
REFERENCES [Maestros].[TablasMaestrasRegistros] ([CodigoArgumento])
GO
ALTER TABLE [GestionComercial].[TipoDeCambio] CHECK CONSTRAINT [TipodeCambio_FK01_CodigoArguMoneda]
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros]  WITH CHECK ADD  CONSTRAINT [TablasMaestrasRegistros_FK01_CodigoTabla] FOREIGN KEY([CodigoTabla])
REFERENCES [Maestros].[TablasMaestras] ([CodigoTabla])
GO
ALTER TABLE [Maestros].[TablasMaestrasRegistros] CHECK CONSTRAINT [TablasMaestrasRegistros_FK01_CodigoTabla]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de estado anterior del documento de emisión para hologación de estados entre la version del sistema' , @level0type=N'SCHEMA',@level0name=N'GestionComercial', @level1type=N'TABLE',@level1name=N'DocumentoEstado', @level2type=N'COLUMN',@level2name=N'codRegEstadoAnterior'
GO
