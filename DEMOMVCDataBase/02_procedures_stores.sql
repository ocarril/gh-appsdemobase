
------------------------------------------------------------------
/*PROCEDIMIENTOS ALMACENADOS*/
------------------------------------------------------------------
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'MessageErrores')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].MessageErrores AS RETURN')
END
GO
ALTER PROCEDURE MessageErrores 
AS
    /* Return if there is no error information to retrieve. */
    IF ERROR_NUMBER() IS NULL
        RETURN;

    DECLARE
        @ErrorMessage    NVARCHAR(4000),
        @ErrorNumber     INT,
        @ErrorSeverity   INT,
        @ErrorState      INT,
        @ErrorLine       INT,
        @ErrorProcedure  NVARCHAR(200); 

    /* Assign variables to error-handling functions that
       capture information for RAISERROR. */

    SELECT
        @ErrorNumber = ERROR_NUMBER(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorLine = ERROR_LINE(),
        @ErrorProcedure = ISNULL(ERROR_PROCEDURE(),'-'); 

    /* Building the message string that will contain original
       error information. */

    SELECT @ErrorMessage = 
        N'Error %d, Level %d, State %d, Procedure %s, Line %d, ' + 
         'Message: '+ ERROR_MESSAGE(); 

    /* Raise an error: msg_str parameter of RAISERROR will contain
	   the original error information. */

    RAISERROR
	(	
		@ErrorMessage, 
		@ErrorSeverity, 
		1,
        @ErrorNumber,    /* parameter: original error number. */
        @ErrorSeverity,  /* parameter: original error severity. */
        @ErrorState,     /* parameter: original error state. */
        @ErrorProcedure, /* parameter: original error procedure name. */
        @ErrorLine       /* parameter: original error line number. */
     );
GO


/***********************************
TABLA: [Maestros].[Configuracion]		Procedures de Configuracion
**********************************/

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_I_Configuracion')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_I_Configuracion] AS RETURN')
END
GO
ALTER  PROCEDURE [Maestros].[demo_mvc_I_Configuracion]
(@prm_codConfiguracion			int OUTPUT
,@prm_codEmpresa				INT
,@prm_codKeyConfig             	varchar(30)
,@prm_codTabla                 	varchar(15)
,@prm_numNivel					INT=NULL
,@prm_indOrden                 	char(4)
,@prm_indTipoValor             	varchar(50)
,@prm_desValor                 	varchar(200)
,@prm_desNombre                	varchar(200)
,@prm_gloDescripcion           	varchar(500)
,@prm_indGenerico              	bit
,@prm_desGrupo					varchar(10)
,@prm_indActivo                	bit
,@prm_segUsuarioCrea           	varchar(30)
,@prm_segMaquina               	varchar(30)
)

AS
BEGIN
	INSERT INTO [Maestros].[Configuracion]
	([codEmpresa],[codKeyConfig]
	,[codTabla]
	,[numNivel]
	,[indOrden]
	,[indTipoValor]
	,[desValor]
	,[desNombre]
	,[gloDescripcion]
	,[indGenerico]
	,[desGrupo]
	,[indActivo]
	,[segUsuarioCrea]
	,[segFechaCrea]
	)
	VALUES
	(@prm_codEmpresa, @prm_codKeyConfig
	,@prm_codTabla
	,@prm_numNivel
	,@prm_indOrden
	,@prm_indTipoValor
	,@prm_desValor
	,@prm_desNombre
	,@prm_gloDescripcion
	,@prm_indGenerico
	,@prm_desGrupo
	,@prm_indActivo
	,@prm_segUsuarioCrea
	,DBO.fcn_GetDate()
	)
	SET @prm_codConfiguracion = SCOPE_IDENTITY();
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_U_Configuracion')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_U_Configuracion] AS RETURN')
END
GO
ALTER  PROCEDURE [Maestros].[demo_mvc_U_Configuracion]
(
 @prm_codEmpresa				INT
,@prm_codConfiguracion         	int
,@prm_codKeyConfig             	varchar(30)
,@prm_codTabla                 	varchar(15)
,@prm_numNivel					INT=NULL
,@prm_indOrden                 	char(4)
,@prm_indTipoValor             	varchar(50)
,@prm_desValor                 	varchar(200)
,@prm_desNombre                	varchar(200)
,@prm_gloDescripcion           	varchar(500)
,@prm_indGenerico              	bit
,@prm_desGrupo					varchar(10)
,@prm_indActivo                	bit
,@prm_segUsuarioEdita          	varchar(30)
)

AS
BEGIN
	UPDATE 
		[Maestros].[Configuracion]
	SET 
		 [codKeyConfig]          = 	@prm_codKeyConfig
		,[codTabla]              = 	@prm_codTabla
		,[numNivel]				 =	@prm_numNivel
		,[indOrden]              = 	@prm_indOrden
		,[indTipoValor]          = 	@prm_indTipoValor
		,[desValor]              = 	@prm_desValor
		,[desNombre]             = 	@prm_desNombre
		,[gloDescripcion]        = 	@prm_gloDescripcion
		,[indGenerico]           = 	@prm_indGenerico
		,[desGrupo]				 =	@prm_desGrupo
		,[indActivo]             = 	@prm_indActivo
		,[segUsuarioEdita]       = 	@prm_segUsuarioEdita
		,[segFechaEdita]         = 	DBO.fcn_GetDate()
	WHERE 
		[codEmpresa]			 =  @prm_codEmpresa		
	AND	[codConfiguracion]       = 	@prm_codConfiguracion
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_U_ConfiguracionConfig')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_U_ConfiguracionConfig] AS RETURN')
END
GO
ALTER  PROCEDURE [Maestros].[demo_mvc_U_ConfiguracionConfig]
(
 @prm_codEmpresa				INT
,@prm_codKeyConfig             	varchar(30)
,@prm_desValor                 	varchar(200)
,@prm_segUsuarioEdita          	varchar(30)
,@prm_segMaquina				varchar(30)
)

AS
BEGIN
	UPDATE 
		[Maestros].[Configuracion]
	SET 
		 indConfig			   =    desValor
		,desValor              = 	@prm_desValor
		,segUsuarioEdita       = 	@prm_segUsuarioEdita
		,segFechaEdita         = 	DBO.fcn_GetDate()
		,SegMaquina			   =	@prm_segMaquina
	WHERE 
		[codEmpresa]		=	@prm_codEmpresa
	AND [codKeyConfig]      = 	@prm_codKeyConfig
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_D_Configuracion')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_D_Configuracion] AS RETURN')
END
GO
ALTER PROCEDURE [Maestros].[demo_mvc_D_Configuracion]
(
  @prm_codEmpresa				INT
 ,@prm_codConfiguracion         int
 ,@prm_segUsuarioEdita			varchar(30)
)

AS
BEGIN
	UPDATE
		[Maestros].[Configuracion]
	SET 
		 indActivo			=	0
		,segUsuarioEdita	=	@prm_segUsuarioEdita
		,segFechaEdita		=	DBO.fcn_GetDate()
	WHERE 
		[codEmpresa]		=	@prm_codEmpresa	
	and [codConfiguracion]  = 	@prm_codConfiguracion
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_Configuracion_Paged')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_S_Configuracion_Paged] AS RETURN')
END
GO
ALTER PROCEDURE [Maestros].[demo_mvc_S_Configuracion_Paged]
/*
TEST:
EXEC [Maestros].[demo_mvc_S_Configuracion_Paged]   1,15,'codKeyConfig',NULL,'por','','','',1
*/
(
 @prm_NumPagina		int
,@prm_TamPagina		int
,@prm_OrdenPor		varchar(30)=null
,@prm_OrdenTipo		varchar(4)=null

,@prm_codEmpresa	INT
,@prm_desNombre		varchar(30)
,@prm_codKeyConfig	varchar(30)
,@prm_codTabla		varchar(15)
,@prm_desValor		varchar(30)	
,@prm_indActivo		bit=null
)

AS
BEGIN
	SELECT
	 *
	FROM
	(
		SELECT 
		 [codConfiguracion]
		,[codKeyConfig]
		,[codTabla]
		,[numNivel]
		,[indOrden]
		,[indTipoValor]
		,[desValor]
		,[desNombre]
		,[gloDescripcion]
		,[indGenerico]
		,[desGrupo]
		,[indActivo]
		,[segUsuarioCrea]
		,[segUsuarioEdita]
		,[segFechaCrea]
		,[segFechaEdita]
		,[segMaquina]
		,COUNT(*) OVER() AS [TOTALROWS]
	    ,ROW_NUMBER() OVER (ORDER BY 
			 CASE WHEN @prm_OrdenPor = 'desNombre'		and @prm_OrdenTipo = 'ASC'  THEN [desNombre]
			 END ASC,
			 CASE WHEN @prm_OrdenPor = 'desNombre'		and @prm_OrdenTipo = 'DESC'  THEN [desNombre]
			 END DESC,
			 
		     CASE WHEN @prm_OrdenPor = 'codKeyConfig'	and @prm_OrdenTipo = 'ASC'  THEN [codKeyConfig] 
			 END ASC,
			 CASE WHEN @prm_OrdenPor = 'codKeyConfig'	and @prm_OrdenTipo = 'DESC'  THEN [codKeyConfig] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'desValor'		and @prm_OrdenTipo = 'ASC'  THEN [desValor] 
			 END ASC,
			 CASE WHEN @prm_OrdenPor = 'desValor'		and @prm_OrdenTipo = 'DESC'  THEN [desValor] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'indOrden'		and @prm_OrdenTipo = 'ASC'  THEN [indOrden] 
			 END ASC,
			 CASE WHEN @prm_OrdenPor = 'indOrden'		and @prm_OrdenTipo = 'DESC'  THEN [indOrden] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'numNivel'		and @prm_OrdenTipo = 'ASC'  THEN [numNivel] 
			 END ASC,
			 CASE WHEN @prm_OrdenPor = 'numNivel'		and @prm_OrdenTipo = 'DESC'  THEN [numNivel] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'desGrupo'		and @prm_OrdenTipo = 'ASC'  THEN [desGrupo] 
			 END ASC,
			  CASE WHEN @prm_OrdenPor = 'desGrupo'		and @prm_OrdenTipo = 'DESC'  THEN [desGrupo] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'segFechaEdita'	and @prm_OrdenTipo = 'ASC'  THEN [segFechaEdita] 
			 END ASC,
			  CASE WHEN @prm_OrdenPor = 'segFechaEdita'	and @prm_OrdenTipo = 'DESC'  THEN [segFechaEdita] 
			 END DESC,
			 
			 CASE WHEN @prm_OrdenPor = 'segUsuarioEdita'and @prm_OrdenTipo = 'ASC'  THEN [segUsuarioEdita]   
		     END ASC,
		     CASE WHEN @prm_OrdenPor = 'segUsuarioEdita'and @prm_OrdenTipo = 'DESC'  THEN [segUsuarioEdita]   
		     END DESC) AS [ROWNUM]
		FROM
			[Maestros].[Configuracion]
		WHERE 
			[codEmpresa]			=	@prm_codEmpresa	
		AND ISNULL([desNombre],'')	 LIKE	(CASE WHEN ISNULL(@prm_desNombre,'')<>''	THEN '%'+ ISNULL(@prm_desNombre,'')+'%'	   ELSE ISNULL([desNombre],'')	 END) 
		AND ISNULL([codKeyConfig],'')LIKE	(CASE WHEN ISNULL(@prm_codKeyConfig,'')<>''	THEN '%'+ ISNULL(@prm_codKeyConfig,'')+'%' ELSE ISNULL([codKeyConfig],'')END) 
		AND(ISNULL([codTabla],'')	 LIKE	(CASE WHEN ISNULL(@prm_codTabla,'')<>''		
												THEN '%'+ ISNULL(@prm_codTabla,'')+'%'	   
												ELSE ISNULL([codTabla],'')	 
											END) 
			OR
			ISNULL([desGrupo],'')	 LIKE	(CASE WHEN ISNULL(@prm_codTabla,'')<>''		
												THEN '%'+ ISNULL(@prm_codTabla,'')+'%'	   
												ELSE ISNULL([desGrupo],'')	 
											END) 
			)
		AND ISNULL([desValor],'')	 LIKE	(CASE WHEN ISNULL(@prm_desValor,'')<>''		THEN '%'+ ISNULL(@prm_desValor,'')+'%'	   ELSE ISNULL([desValor],'')	 END) 
		AND [indActivo] = @prm_indActivo
	)
	AS Tabla
	WHERE ROWNUM BETWEEN (@prm_NumPagina*@prm_TamPagina) - @prm_TamPagina + 1 
					 AND (@prm_NumPagina*@prm_TamPagina)
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_Configuracion')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_S_Configuracion] AS RETURN')
END
GO
ALTER PROCEDURE [Maestros].[demo_mvc_S_Configuracion]
/*
TEST
	--[Maestros].[demo_mvc_S_Configuracion] null ,'','',null
	--[Maestros].[demo_mvc_S_Configuracion] 2 ,null,'',null

*/
(
  @prm_codEmpresa			INT
 ,@prm_codConfiguracion		INT
 ,@prm_codKeyConfig			VARCHAR(30)
 ,@prm_desNombre			VARCHAR(30)
 ,@prm_indActivo			BIT=NULL
)

AS
BEGIN
	SELECT 
		[codConfiguracion],
		[codKeyConfig],
		[codTabla],
		[numNivel],
		[indOrden],
		[indTipoValor],
		[desValor],
		[desNombre],
		[gloDescripcion],
		[indGenerico],
		[desGrupo],
		[indActivo],
		[segUsuarioCrea],
		[segUsuarioEdita],
		[segFechaCrea],
		[segFechaEdita],
		[segMaquina]
	FROM 
		[Maestros].[Configuracion]
	WHERE
		[codEmpresa]	= @prm_codEmpresa	
	AND ISNULL([codConfiguracion],0) = (CASE WHEN ISNULL(@prm_codConfiguracion,0)<>0	
											THEN ISNULL(@prm_codConfiguracion,0)	
											ELSE ISNULL([codConfiguracion],0)	
										 END) 
	AND ISNULL([desNombre],'')	 LIKE	(CASE WHEN ISNULL(@prm_desNombre,'')<>''	
										THEN '%'+ ISNULL(@prm_desNombre,'')+'%'	   
										ELSE ISNULL([desNombre],'')	 
									 END) 
	AND ISNULL([codKeyConfig],'')LIKE	(CASE WHEN ISNULL(@prm_codKeyConfig,'')<>''	
										THEN '%'+ ISNULL(@prm_codKeyConfig,'')+'%' 
										ELSE ISNULL([codKeyConfig],'')
									 END) 
	AND ISNULL([indActivo],0) = (CASE WHEN ISNULL(@prm_indActivo,0)<>0	
											THEN ISNULL(@prm_indActivo,0)	
											ELSE ISNULL([indActivo],0)	
										 END) 
		
END
GO




/*
-- TABLA : [GestionComercial].[TipoDeCambio]
*/
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_I_TipoDeCambio')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_I_TipoDeCambio] AS RETURN')
END
GO
ALTER  PROCEDURE [GestionComercial].[demo_mvc_I_TipoDeCambio]
(@prm_codTipoCambio				INT			OUTPUT
,@prm_codEmpresa				INT
,@prm_FechaProceso             	DATE
,@prm_CodigoArguMoneda         	VARCHAR(17)
,@prm_CambioCompraGOB          	DECIMAL(13,5)
,@prm_CambioVentasGOB          	DECIMAL(13,5)
,@prm_CambioCompraPRL          	DECIMAL(13,5)
,@prm_CambioVentasPRL          	DECIMAL(13,5)
,@prm_Estado                   	BIT
,@prm_SegUsuarioCrea           	VARCHAR(50)
,@prm_SegMaquina				VARCHAR(30)
)

AS
BEGIN
	INSERT INTO [GestionComercial].[TipoDeCambio]
	([codEmpresa]
	,[FechaProceso]
	,[CodigoArguMoneda]
	,[CambioCompraGOB]
	,[CambioVentasGOB]
	,[CambioCompraPRL]
	,[CambioVentasPRL]
	,[Estado]
	,[SegUsuarioCrea]
	,[SegMaquina]
	)
	VALUES
	(@prm_codEmpresa
	,@prm_FechaProceso
	,@prm_CodigoArguMoneda
	,@prm_CambioCompraGOB
	,@prm_CambioVentasGOB
	,@prm_CambioCompraPRL
	,@prm_CambioVentasPRL
	,@prm_Estado
	,@prm_SegUsuarioCrea
	,@prm_SegMaquina
	)
	SET @prm_codTipoCambio = @@IDENTITY
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_U_TipoDeCambio')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_U_TipoDeCambio] AS RETURN')
END
GO
ALTER  PROCEDURE [GestionComercial].[demo_mvc_U_TipoDeCambio]
(
 @prm_codEmpresa				INT
,@prm_codTipoCambio				int	
,@prm_FechaProceso             	datetime
,@prm_CodigoArguMoneda         	varchar(17)
,@prm_CambioCompraGOB          	decimal(13,5)
,@prm_CambioVentasGOB          	decimal(13,5)
,@prm_CambioCompraPRL          	decimal(13,5)
,@prm_CambioVentasPRL          	decimal(13,5)
,@prm_Estado                   	bit
,@prm_SegUsuarioEdita          	varchar(50)
,@prm_SegMaquina				varchar(30)
)

AS
BEGIN
	UPDATE 
		[GestionComercial].[TipoDeCambio]
	SET 
		 [FechaProceso]			 = 	@prm_FechaProceso
		,[CodigoArguMoneda]		 = 	@prm_CodigoArguMoneda
		,[CambioCompraGOB]       = 	@prm_CambioCompraGOB
		,[CambioVentasGOB]       = 	@prm_CambioVentasGOB
		,[CambioCompraPRL]       = 	@prm_CambioCompraPRL
		,[CambioVentasPRL]       = 	@prm_CambioVentasPRL
		,[Estado]                = 	@prm_Estado
		,[SegUsuarioEdita]       = 	@prm_SegUsuarioEdita
		,[SegFechaEdita]         = 	DBO.FCN_GETDATE()
		,[SegMaquina]			 =  @prm_SegMaquina
	WHERE 
		 codEmpresa			=	@prm_codEmpresa	
	AND	[codTipoCambio]		=	@prm_codTipoCambio
	
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_D_TipoDeCambio')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_D_TipoDeCambio] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_D_TipoDeCambio]
(
 @prm_codEmpresa				INT
,@prm_codTipoCambio         	int
)

AS
BEGIN
	DELETE FROM 
		[GestionComercial].[TipoDeCambio]
	WHERE 
		codEmpresa			=	@prm_codEmpresa		AND
		[codTipoCambio]		= 	@prm_codTipoCambio
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_TipoDeCambio')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio]
/* 
Propósito	:Lista las ordenes de importaciones de acuerdo al filtro
Parametros	Input:
	@prm_codTipoCambio		: ID del registro
	@prm_FechaProcesoINI	: Fecha de inicio de proceso a listar
	@prm_FechaProcesoFIN	: Fecha de fin de proceso a listar
	@prm_CodigoArguMoneda	: Código de tipo de moneda
	@prm_Estado				: Estado del registro a listar
Creado por	: Orlando Carril Ramírez
Creado el	: 11-Ago-2015
Editado el	: 25-Feb-2016
Test		: EXECUTE [GestionComercial].[demo_mvc_S_TipoDeCambio] 500,null,null,null,null
*/
(
 @prm_codEmpresa				INT
,@prm_codTipoCambio				INT=NULL
,@prm_FechaProcesoINI           CHAR(8)=NULL
,@prm_FechaProcesoFIN          	CHAR(8)=NULL
,@prm_CodigoArguMoneda         	VARCHAR(17)=NULL
,@prm_Estado					BIT=NULL
)

AS
BEGIN
	SELECT 
		tc.[codTipoCambio],
		tc.[FechaProceso],
		tc.[CodigoArguMoneda],
		mon.[Nombre]		[CodigoArguMonedaNombre],
		tc.[CambioCompraGOB],
		tc.[CambioVentasGOB],
		tc.[CambioCompraPRL],
		tc.[CambioVentasPRL],
		tc.[Estado],
		tc.[SegUsuarioCrea],
		tc.[SegUsuarioEdita],
		tc.[SegFechaCrea],
		tc.[SegFechaEdita],
		tc.[SegMaquina]
	FROM 
		[GestionComercial].[TipoDeCambio]		AS	tc
		LEFT JOIN [Maestros].[TablasMaestrasRegistros]	AS mon	ON	tc.[CodigoArguMoneda]	=	mon.[CodigoArgumento]
	WHERE 
		tc.codEmpresa	= @prm_codEmpresa	AND
		ISNULL(tc.[codTipoCambio],0)	=	(CASE WHEN ISNULL(@prm_codTipoCambio,0)<>0	
												THEN ISNULL(@prm_codTipoCambio,0)  
												ELSE ISNULL(tc.[codTipoCambio],0)	
										END) AND
		CONVERT(CHAR(8),tc.[FechaProceso],112)	BETWEEN 
		CASE WHEN ISNULL(@prm_FechaProcesoINI,'')<>''	THEN @prm_FechaProcesoINI	ELSE 
		CONVERT(CHAR(8),tc.[FechaProceso],112)	END		AND 
		CASE WHEN ISNULL(@prm_FechaProcesoFIN,'')<>''	THEN @prm_FechaProcesoFIN	ELSE 
		CONVERT(CHAR(8),tc.[FechaProceso],112) 	END		AND
		ISNULL(tc.[CodigoArguMoneda],'')	=	(CASE WHEN ISNULL(@prm_CodigoArguMoneda,'')<>''	
														THEN ISNULL(@prm_CodigoArguMoneda,'')  
														ELSE ISNULL(tc.CodigoArguMoneda,'')	
												END) AND
		ISNULL(tc.[Estado],0)				=	(CASE WHEN ISNULL(@prm_Estado,0)<>0	
														THEN ISNULL(@prm_Estado,0)  
														ELSE ISNULL(tc.[Estado],0)	
												END)
	ORDER BY
		tc.[FechaProceso] DESC
END
GO


IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_TipoDeCambio_Paged')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio_Paged] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio_Paged]
/* 
Propósito	:Lista las ordenes de importaciones de acuerdo al filtro
Parametros	Input:
	@prm_NumPagina			: Número de página
	@prm_TamPagina			: Tamaño del paginado 
	@prm_OrdenPor			: Ordenado por el nombre de la columna
	@prm_OrdenTipo			: Tipo de ordenamiento [ASC/DESC]
	@prm_FechaProcesoINI	: Fecha de inicio de proceso a listar
	@prm_FechaProcesoFIN	: Fecha de fin de proceso a listar
	@prm_CodigoArguMoneda	: Código de tipo de moneda
	@prm_Estado				: Estado del registro a listar
Creado por	: Orlando Carril Ramírez
Creado el	: 11-Ago-2015
Editado el	: 
Test		: EXECUTE [GestionComercial].[omgc_S_TipoDeCambio_Paged] 1,10,'NOMBRE','ASC','','','GTMND002','1'
*/
(
	 @prm_NumPagina			int
	,@prm_TamPagina			int
	,@prm_OrdenPor			varchar(30)=null
	,@prm_OrdenTipo			varchar(4)=null
	
	,@prm_codEmpresa		INT
	,@prm_FechaProcesoINI   char(8)
	,@prm_FechaProcesoFIN   char(8)
	,@prm_CodigoArguMoneda  varchar(17),
	 @prm_Estado			bit
)

AS
BEGIN
	SET NOCOUNT ON
	SELECT *
	FROM
	(
		SELECT 
		 tc.[codTipoCambio]
		,tc.[FechaProceso]
		,tc.[CodigoArguMoneda]
		,mon.[Nombre]		[CodigoArguMonedaNombre]
		,tc.[CambioCompraGOB]
		,tc.[CambioVentasGOB]
		,tc.[CambioCompraPRL]
		,tc.[CambioVentasPRL]
		,tc.[Estado]
		,tc.[SegUsuarioCrea]
		,tc.[SegUsuarioEdita]
		,tc.[SegFechaCrea]
		,tc.[SegFechaEdita]
		,tc.[SegMaquina]
		,COUNT(*) OVER() AS [TOTALROWS]
	    ,ROW_NUMBER() OVER (ORDER BY CASE WHEN @prm_OrdenPor = 'codRegMoneda'  and @prm_OrdenTipo = 'ASC' 
										   THEN mon.[Nombre]
									 END ASC,
									 CASE WHEN @prm_OrdenPor = 'codRegMoneda'  and @prm_OrdenTipo = 'DESC' 
										   THEN mon.[Nombre]
									 END DESC,	
									   	   
									 CASE WHEN @prm_OrdenPor = 'fecProceso'  and @prm_OrdenTipo = 'ASC'  THEN
										tc.[FechaProceso]  
									 END ASC,
									 CASE WHEN @prm_OrdenPor = 'fecProceso'  and @prm_OrdenTipo = 'DESC'  THEN
										tc.[FechaProceso]  
									 END DESC,
									 
									 CASE WHEN @prm_OrdenPor = 'monVentaGOB'  and @prm_OrdenTipo = 'ASC'  THEN
										tc.[CambioVentasGOB]  
									 END ASC,
									 CASE WHEN @prm_OrdenPor = 'monVentaGOB'  and @prm_OrdenTipo = 'DESC'  THEN
										tc.[CambioVentasGOB]  
									 END DESC,
									 
									 CASE WHEN @prm_OrdenPor = 'monCompraGOB'  and @prm_OrdenTipo = 'ASC'  THEN
										tc.[CambioCompraGOB]  
									 END ASC,
									 CASE WHEN @prm_OrdenPor = 'monCompraGOB'  and @prm_OrdenTipo = 'DESC'  THEN
										tc.[CambioCompraGOB]  
									 END DESC,
									 
									 CASE WHEN @prm_OrdenPor = 'UsuModi'  and @prm_OrdenTipo = 'ASC'  THEN
										tc.[SegUsuarioEdita]  
									 END ASC,
									  CASE WHEN @prm_OrdenPor = 'UsuModi'  and @prm_OrdenTipo = 'DESC'  THEN
										tc.[SegUsuarioEdita]  
									 END DESC,
									 
									 CASE WHEN @prm_OrdenPor = 'FeModi'  and @prm_OrdenTipo = 'ASC'  THEN
										tc.[SegFechaEdita]  
									 END ASC,
									 CASE WHEN @prm_OrdenPor = 'FeModi'  and @prm_OrdenTipo = 'DESC'  THEN
										tc.[SegFechaEdita]  
									 END DESC  
									 ) AS [ROWNUM]	
		FROM 
			[GestionComercial].[TipoDeCambio]		AS	tc
			LEFT JOIN [Maestros].[TablasMaestrasRegistros]	AS mon	ON	tc.[CodigoArguMoneda]	=	mon.[CodigoArgumento]
		WHERE 
			tc.codEmpresa	= @prm_codEmpresa	AND
			CONVERT(CHAR(8),tc.[FechaProceso],112)	BETWEEN 
			CASE WHEN ISNULL(@prm_FechaProcesoINI,'')<>''	THEN @prm_FechaProcesoINI	ELSE 
			CONVERT(CHAR(8),tc.[FechaProceso],112)	END		AND 
			CASE WHEN ISNULL(@prm_FechaProcesoFIN,'')<>''	THEN @prm_FechaProcesoFIN	ELSE 
			CONVERT(CHAR(8),tc.[FechaProceso],112) 	END		AND
			ISNULL(tc.[CodigoArguMoneda],'')	=	(CASE WHEN ISNULL(@prm_CodigoArguMoneda,'')<>''	THEN @prm_CodigoArguMoneda  ELSE tc.[CodigoArguMoneda]	END) AND
			tc.[Estado]							=	@prm_Estado
	)
	AS Tabla
	WHERE ROWNUM BETWEEN (@prm_NumPagina*@prm_TamPagina) - @prm_TamPagina + 1 
					 AND (@prm_NumPagina*@prm_TamPagina)
					 
	SET NOCOUNT OFF
END
GO


IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_TipoDeCambio_Ultimo')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio_Ultimo] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_S_TipoDeCambio_Ultimo]
/* 
Propósito	:Lista las ordenes de importaciones de acuerdo al filtro
Parametros	Input:
	@prm_codTipoCambio		: ID del registro
	@prm_FechaProcesoINI	: Fecha de inicio de proceso a listar
	@prm_FechaProcesoFIN	: Fecha de fin de proceso a listar
	@prm_CodigoArguMoneda	: Código de tipo de moneda
	@prm_Estado				: Estado del registro a listar
Creado por	: Orlando Carril Ramírez
Creado el	: 11-Ago-2015
Editado el	: 25-Feb-2016

Test		: 
EXECUTE [GestionComercial].[usp_sgcfe_R_TipoDeCambio_Ultimo] 2,'GTMND002', 1
EXECUTE [GestionComercial].[usp_sgcfe_R_TipoDeCambio_Ultimo] 2,'GTMND002', 0
*/
(
 @prm_codEmpresa				INT
,@prm_CodigoArguMoneda         	VARCHAR(17)=NULL
,@prm_Estado					BIT=NULL
)

AS
BEGIN
	SELECT TOP 1
		tc.[codTipoCambio],
		tc.[FechaProceso],
		tc.[CodigoArguMoneda],
		mon.[Nombre]		[CodigoArguMonedaNombre],
		tc.[CambioCompraGOB],
		tc.[CambioVentasGOB],
		tc.[CambioCompraPRL],
		tc.[CambioVentasPRL],
		tc.[Estado],
		tc.[SegUsuarioCrea],
		tc.[SegUsuarioEdita],
		tc.[SegFechaCrea],
		tc.[SegFechaEdita],
		tc.[SegMaquina]
	FROM 
		[GestionComercial].[TipoDeCambio]		AS	tc
		LEFT JOIN [Maestros].[TablasMaestrasRegistros]	AS mon	ON	tc.[CodigoArguMoneda]	=	mon.[CodigoArgumento]
	WHERE 
		tc.codEmpresa	= @prm_codEmpresa	AND
		ISNULL(tc.[CodigoArguMoneda],'')	=	(CASE WHEN ISNULL(@prm_CodigoArguMoneda,'')<>''	
														THEN ISNULL(@prm_CodigoArguMoneda,'')  
														ELSE ISNULL(tc.CodigoArguMoneda,'')	
												END) AND
		ISNULL(tc.[Estado],0)				=	(CASE WHEN ISNULL(@prm_Estado,0)<>0	
														THEN ISNULL(@prm_Estado,0)  
														ELSE ISNULL(tc.[Estado],0)	
												END)
	ORDER BY
		tc.[FechaProceso] DESC
END
GO





/********************************************************
TABLA : [GestionComercial].[DocumentoEstado]
*********************************************************/
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_I_DocumentoEstado')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_I_DocumentoEstado] AS RETURN')
END
GO
ALTER  PROCEDURE [GestionComercial].[demo_mvc_I_DocumentoEstado]
(@prm_codDocumentoEstado       	int OUTPUT
,@prm_codRegDocumento          	varchar(17)
,@prm_codRegEstado             	varchar(17)
,@prm_codEstado          		INT
,@prm_indActivo                	bit
,@prm_segUsuarioCrea           	varchar(50)
)

AS
BEGIN
	INSERT INTO [GestionComercial].[DocumentoEstado]
	([codRegDocumento]
	,[codRegEstado]
	,[codEstado]
	,[indActivo]
	,[segUsuarioCrea]
	)
	VALUES
	(@prm_codRegDocumento
	,@prm_codRegEstado
	,@prm_codEstado
	,@prm_indActivo
	,@prm_segUsuarioCrea
	)
	SET @prm_codDocumentoEstado = @@IDENTITY
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_U_DocumentoEstado')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_U_DocumentoEstado] AS RETURN')
END
GO
ALTER  PROCEDURE [GestionComercial].[demo_mvc_U_DocumentoEstado]
(
 @prm_codDocumentoEstado       	int
,@prm_codRegDocumento          	varchar(17)
,@prm_codRegEstado             	varchar(17)
,@prm_codEstado          		INT
,@prm_indActivo                	bit
,@prm_segUsuarioEdita          	varchar(50)
)

AS
BEGIN
	UPDATE 
	[GestionComercial].[DocumentoEstado]
	SET 
	 [codRegDocumento]       = 	@prm_codRegDocumento
	,[codRegEstado]          = 	@prm_codRegEstado
	,[codEstado]			 = 	@prm_codEstado
	,[indActivo]             = 	@prm_indActivo
	,[segUsuarioEdita]       = 	@prm_segUsuarioEdita
	,[segFechaEdita]         = 	DBO.FCN_GETDATE()
	WHERE 
	[codDocumentoEstado]      = 	@prm_codDocumentoEstado
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_DocumentoEstado')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_S_DocumentoEstado] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_S_DocumentoEstado]
/*
TEST:
 EXECUTE [GestionComercial].[demo_mvc_S_DocumentoEstado] null,'GCMPB001','ESTLC002'
 EXECUTE [GestionComercial].[demo_mvc_S_DocumentoEstado] null,'GCMPB001',''

SELECT * FROM [GestionComercial].[DocumentoEstado]
*/
(
 @prm_codDocumentoEstado    INT=NULL
,@prm_codRegDocumento       VARCHAR(17)=NULL
,@prm_codRegEstado			VARCHAR(17)=NULL
)

AS
BEGIN
	SELECT 
		 de.[codDocumentoEstado]		[codDocumentoEstado]
		,de.[codRegDocumento]			[codRegDocumento]
		,dc.[nombre]					[codRegDocumentoNombre]
		,de.[codRegEstado]				[codRegEstado]
		,et.[nombre]					[codRegEstadoNombre]
		,de.[codEstado]					[codEstado]
		,de.[indActivo]					[indActivo]
		,de.[segUsuarioCrea]			[segUsuarioCrea]
		,isnull(de.[segUsuarioEdita],de.[segUsuarioCrea])			
										[segUsuarioEdita]
		,de.[segFechaCrea]				[segFechaCrea]
		,isnull(de.[segFechaEdita],de.[segFechaCrea])
										[segFechaEdita]
		,de.[segMaquina]				[segMaquinaEdita]
	FROM
		[GestionComercial].[DocumentoEstado] de
		INNER JOIN [Maestros].TablasMaestrasRegistros dc on de.codRegDocumento = dc.CodigoArgumento
		INNER JOIN [Maestros].TablasMaestrasRegistros et on de.codRegEstado	= et.CodigoArgumento
	WHERE 
		ISNULL(de.[codDocumentoEstado],0)=	(CASE WHEN ISNULL(@prm_codDocumentoEstado,0)<>''	
											 THEN      ISNULL(@prm_codDocumentoEstado,0)     	
											 ELSE ISNULL(de.[codDocumentoEstado],0)	END) 
	AND ISNULL(de.[codRegDocumento],'')	  =	(CASE WHEN ISNULL(@prm_codRegDocumento,'')<>''	
											 THEN      ISNULL(@prm_codRegDocumento,'')     	
											 ELSE ISNULL(de.[codRegDocumento],'')	END) 
	AND ISNULL(de.[codRegEstado],'')	  =	(CASE WHEN ISNULL(@prm_codRegEstado,'')<>''	
											 THEN      ISNULL(@prm_codRegEstado,'')     	
											 ELSE ISNULL(de.[codRegEstado],'')	END) 
	ORDER BY 
		DC.Descripcion, ET.Descripcion
END
GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_DocumentoEstado_Paged')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_S_DocumentoEstado_Paged] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_S_DocumentoEstado_Paged]
/*
TEST:
EXECUTE [GestionComercial].[demo_mvc_S_DocumentoEstado_Paged]1,10,'auxcodRegNacionalizac','asc', null,'',''

*/
(
 @prm_NumPagina				int
,@prm_TamPagina				int
,@prm_OrdenPor				varchar(30)=null
,@prm_OrdenTipo				varchar(4)=null

,@prm_codDocumentoEstado    int=null
,@prm_codRegDocumento       varchar(17)=null
,@prm_codRegEstado			varchar(17)=null
)

AS
BEGIN
	SELECT
	 TOTALROWS
	,ROWNUM
	,codDocumentoEstado
	,codRegDocumento
	,codRegDocumentoNombre
	,codRegEstado
	,codRegEstadoNombre
	,ISNULL([codRegEstadoColor],'')	[codRegEstadoColor]
	,codEstado
	,indActivo
	,segUsuarioCrea
	,segFechaCrea
	,CASE WHEN segUsuarioEdita IS NULL
		THEN segUsuarioCrea
		ELSE segUsuarioEdita
	 END	segUsuarioEdita
	,CASE WHEN segFechaEdita IS NULL
		THEN segFechaCrea
		ELSE segFechaEdita
	 END	segFechaEdita
	,segMaquina
	FROM
	(	
		SELECT 
		 COUNT(*) OVER() AS [TOTALROWS]
		,ROW_NUMBER() OVER (ORDER BY  CASE WHEN @prm_OrdenPor = 'codRegDocumentoDesc'  and @prm_OrdenTipo = 'ASC' THEN 
										dc.[nombre]
									  END ASC,
									  CASE WHEN @prm_OrdenPor = 'codRegDocumentoDesc'  and @prm_OrdenTipo = 'DESC' THEN
										dc.[nombre]
									  END DESC,	
									  CASE WHEN @prm_OrdenPor = 'codRegEstadoDesc'  and @prm_OrdenTipo = 'ASC' THEN 
										et.[nombre]
									  END ASC,
									  CASE WHEN @prm_OrdenPor = 'codRegEstadoDesc'  and @prm_OrdenTipo = 'DESC' THEN
										et.[nombre]
									  END DESC,	
									  CASE WHEN @prm_OrdenPor = 'codEstado'  and @prm_OrdenTipo = 'ASC' THEN 
										de.[codEstado]
									  END ASC,
									  CASE WHEN @prm_OrdenPor = 'codEstado'  and @prm_OrdenTipo = 'DESC' THEN
										de.[codEstado]
									  END DESC) AS [ROWNUM]
		,de.[codDocumentoEstado]
		,de.[codRegDocumento]
		,dc.[nombre] [codRegDocumentoNombre]
		,de.[codRegEstado]
		,et.[nombre]		[codRegEstadoNombre]
		,et.[ValorCadena]	[codRegEstadoColor]
		,de.[codEstado]
		,de.[indActivo]
		,de.[segUsuarioCrea]
		,de.[segUsuarioEdita]
		,de.[segFechaCrea]
		,de.[segFechaEdita]
		,de.[segMaquina]
		FROM
		[GestionComercial].[DocumentoEstado] de
		INNER JOIN [Maestros].TablasMaestrasRegistros dc on de.codRegDocumento = dc.CodigoArgumento
		INNER JOIN [Maestros].TablasMaestrasRegistros et on de.codRegEstado	= et.CodigoArgumento
		WHERE 
		ISNULL(de.[codDocumentoEstado],0)=	(CASE WHEN ISNULL(@prm_codDocumentoEstado,0)<>''	
											 THEN      ISNULL(@prm_codDocumentoEstado,0)     	
											 ELSE ISNULL(de.[codDocumentoEstado],0)	END) AND 
		ISNULL(de.[codRegDocumento],'')	  =	(CASE WHEN ISNULL(@prm_codRegDocumento,'')<>''	
											 THEN      ISNULL(@prm_codRegDocumento,'')     	
											 ELSE ISNULL(de.[codRegDocumento],'')	END) AND 
		ISNULL(de.[codRegEstado],'')	  =	(CASE WHEN ISNULL(@prm_codRegEstado,'')<>''	
											 THEN      ISNULL(@prm_codRegEstado,'')     	
											 ELSE ISNULL(de.[codRegEstado],'')	END)
		)
		AS TABLA							   
		WHERE ROWNUM BETWEEN (@prm_NumPagina*@prm_TamPagina) - @prm_TamPagina + 1 
					 AND (@prm_NumPagina*@prm_TamPagina)
		
END
GO


IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_D_DocumentoEstado')
BEGIN
	EXEC('CREATE PROCEDURE [GestionComercial].[demo_mvc_D_DocumentoEstado] AS RETURN')
END
GO
ALTER PROCEDURE [GestionComercial].[demo_mvc_D_DocumentoEstado]
(
 @prm_codDocumentoEstado      int
,@prm_codRegDocumento         varchar(17)=null 
)

AS
BEGIN
	DELETE FROM 
	[GestionComercial].[DocumentoEstado]
	WHERE 
	[codDocumentoEstado]      = 	@prm_codDocumentoEstado
END
GO








IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_Tabla')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_S_Tabla]  AS RETURN')
END
GO
ALTER PROCEDURE [Maestros].[demo_mvc_S_Tabla] 
/* 
Propósito	:Lista las tablas maestras definidas de acuerdo al filtro
Parametros	Input:
	@prm_codTabla	: Código de tabla a listar
	@prm_desNombre	: Nombre de tabla a listar
	@prm_indActivo	: Estado del registro a listar
Creado por	: Orlando Carril Ramírez
Creado el	: 18-Oct-2014
Editado el	: 22-Ago-2015
Test		: [Maestros].[omgc_S_Tabla] '','PER',1
*/
	 @prm_codTabla		VARCHAR(5)	=NULL,
	 @prm_desNombre		varchar(40)	=NULL,
	 @prm_indActivo		bit			=NULL
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @v_indActivo_2 BIT
	IF @prm_indActivo = 1 or @prm_indActivo = 0
	BEGIN
		SET @v_indActivo_2	= @prm_indActivo
	END
	ELSE
	BEGIN
		SET @prm_indActivo	= '1'
		SET @v_indActivo_2	= '0'
	END

	SELECT 
	CodigoTabla			[codTabla],
	Nombre				[desNombre],
	Descripcion			[gloDescripcion],
	LongitudNivel		[numLongitudNivel],
	Niveles				[indNivel],
	TipoArgumento,
	TipoGeneracion,
	Estado				[indActivo],
	SegUsuarioCrea		[segUsuCrea],
	SegUsuarioEdita		[segUsuEdita],
	SegFechaHoraCrea	[segFechaCrea],
	SegFechaHoraEdita	[segFechaEdita],
	SegMaquinaOrigen	[segMaquinaOrigen]
	FROM 
	[Maestros].[TablasMaestras]
	WHERE
	([Estado]	 =	@prm_indActivo	OR 
	 [Estado]	 =	@v_indActivo_2	) AND
	 CodigoTabla LIKE (CASE WHEN ltrim(ISNULL(@prm_codTabla,''))=''		
						THEN '%%'		
						ELSE '%' + @prm_codTabla +'%'		
						END) AND
	 Nombre	 LIKE  (CASE WHEN ltrim(ISNULL(@prm_desNombre,''))=''		
					THEN '%%'		
					ELSE '%' + @prm_desNombre +'%'	
					END)
	 SET NOCOUNT OFF;
END
GO



IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'demo_mvc_S_Registro_Combo')
BEGIN
	EXEC('CREATE PROCEDURE [Maestros].[demo_mvc_S_Registro_Combo]  AS RETURN')
END
GO
ALTER PROCEDURE [Maestros].[demo_mvc_S_Registro_Combo]
/* 
Propósito	:Lista registro de tablas maestras para los combos
Parametros	Input:
	@prm_codTabla	: Código de tabla a listar
	@prm_codRegistro: Nombre de tabla a listar
	@prm_numNivel	: Numero de nivel a listar
	@prm_indActivo	: Estado del registro a listar
Creado por	: Orlando Carril Ramírez
Creado el	: 18-Oct-2014
Editado el	: 22-Ago-2015
Test		: 

EXECUTE [Maestros].[omgc_S_Registro_Combo]'GCMPB','GCMPB001','2',1
EXECUTE [Maestros].[omgc_S_Registro_Combo]'PMEDI','PMEDI003','1',1
EXECUTE [Maestros].[omgc_S_Registro_Combo]'PMEDI','PMEDI002','2',1
EXECUTE [Maestros].[omgc_S_Registro_Combo]'PCATE',NULL,'1',1
 
SELECT * FROM [Maestros].[TablasMaestras] ORDER BY NOMBRE
*/
	@prm_codTabla		char(5),
	@prm_codRegistro	varchar(17),
	@prm_numNivel		int,
	@prm_indActivo		bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		 tr.CodigoTabla								[codTabla]		
		,CodigoArgumento							[codRegistro]	
		,Nivel										[numNivel]
		,tr.Nombre									[desNombre]
		,tr.Descripcion								[gloDescripcion]
		,ISNULL(ValorDecimal, CONVERT(DECIMAL,0))	[desValorDecimal]
		,ISNULL(ValorCadena,'')						[desValorCadena]
		,ISNULL(ValorBoolean, CONVERT(BIT,0))		[desValorLogico]
		,ISNULL(ValorEntero, CONVERT(INT,0))		[desValorEntero]
		,ValorFecha									[desValorFecha]	 
		,tr.Estado									[indActivo]
		,ISNULL(codValorSUNAT,'')					[codValorSunat]
		,ISNULL(codigoTMP,'')						[codigoTMP]
		,tm.LongitudNivel							[numLongitudNivel]
		,CASE WHEN tr.[SegFechaHoraEdita] IS NULL
			THEN	tr.[SegFechaHoraCrea]
			ELSE	tr.[SegFechaHoraEdita]
		 END										[segFechaEdita]
		,CASE WHEN tr.[SegUsuarioEdita] IS NULL
			THEN	tr.[SegUsuarioCrea]
			ELSE	tr.[SegUsuarioEdita]
		 END										[segUsuarioEdita]
		,tr.[SegMaquinaOrigen]						[segMaquinaEdita]
	FROM 
		[Maestros].[TablasMaestrasRegistros] tr
		INNER JOIN [Maestros].[TablasMaestras] tm ON tm.CodigoTabla = tr.CodigoTabla
	WHERE 
		tr.CodigoTabla		=	 @prm_codTabla			AND 
		 ISNULL(CodigoArgumento,'')	LIKE	 (CASE WHEN ISNULL(@prm_codRegistro,'')<>''			
												  THEN  ISNULL(@prm_codRegistro,'')    + '%'    
												  ELSE ISNULL(CodigoArgumento,'')	
											  END)	AND 
		Nivel			=	 @prm_numNivel			AND 
		tr.Estado			=	 @prm_indActivo 
	ORDER BY
		tr.Nombre
		
	SET NOCOUNT ON;
END
GO
