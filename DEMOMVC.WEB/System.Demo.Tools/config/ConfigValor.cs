using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.config
{
    public class ConfigValor
    {
        public int codConfiguracion { get; set; }
        public string codKeyConfig { get; set; }
        public string codTabla { get; set; }
        public string indOrden { get; set; }
        public string indTipoValor { get; set; }
        public string desValor { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indGenerico { get; set; }
        public bool indActivo { get; set; }
    }

    public enum ConfigTool
    {
       
          DEFAULT_ActualizaCostos
        , DEFAULT_AlmacenPrincipal
        , DEFAULT_AperturaCajaAuto
        , DEFAULT_AsigCliente
        , DEFAULT_AsigProveed
        , DEFAULT_AsistenciaLogicos
        , DEFAULT_AsistenciaValores

        , DEFAULT_Atributo_NumerDNI
        , DEFAULT_Atributo_NumerRUC
        , DEFAULT_Atributo_Telefono

        , DEFAULT_Calc_IGV_Horiz
        , DEFAULT_CantidadDecimals
        , DEFAULT_CategEmpleado
        , DEFAULT_CentroProduccion
        , DEFAULT_Cliente
        , DEFAULT_ConcatenaNumDias
        , DEFAULT_CondicionCompra
        , DEFAULT_CondicionVenta
        , DEFAULT_CotizNota001
        , DEFAULT_CotizNota002
        , DEFAULT_CotizPersonaFirma
        , DEFAULT_DatosWeb

        , DEFAULT_DestinoCliente
        , DEFAULT_DestinoInterno
        , DEFAULT_DestinoProveed

        , DEFAULT_DiasAntesConsultas
        , DEFAULT_DiasValidezCotiz
        , DEFAULT_DiferCierreCaja

        , DEFAULT_Doc_CotizaArchivada
        , DEFAULT_Doc_Cotizacion
        , DEFAULT_Doc_FacturaProveedor
        , DEFAULT_Doc_FacturaProvLocal
        , DEFAULT_Doc_GuiaRemArchivada
        , DEFAULT_Doc_GuiaRemConsig
        , DEFAULT_Doc_GuiaRemEmitida
        , DEFAULT_Doc_GuiaRemUso
        , DEFAULT_Doc_Inventarios
        , DEFAULT_Doc_InventEstado
        , DEFAULT_Doc_NotaIngreso
        , DEFAULT_Doc_NotaSalida

        , DEFAULT_Docum_DUA
        , DEFAULT_Docum_EQUI
        , DEFAULT_Docum_MNTO
        , DEFAULT_Docum_ODP
        , DEFAULT_Docum_OI

        , DEFAULT_EliminacionMaestros
        , DEFAULT_EliminacionMovimien
        , DEFAULT_EmailPersona
        , DEFAULT_EmpTransporte

        , DEFAULT_EstadoDeLetra
        , DEFAULT_EstadoDeLetraANU
        , DEFAULT_EstadoDeLetraCAN
        , DEFAULT_EstadoDeLetraPTT

        , DEFAULT_Exten_Imagenes
        , DEFAULT_Exten_ODP
        , DEFAULT_FirmaPersona
        , DEFAULT_fmt_Letra
        , DEFAULT_Formato_Archivo
        , DEFAULT_FPago_Efectivo
        , DEFAULT_GastoFOB
        , DEFAULT_HabilitaCaja
        , DEFAULT_HeightPantalla
        , DEFAULT_HeightPantallaP
        , DEFAULT_HoraTurnoManana
        , DEFAULT_Importaciones
        , DEFAULT_Impuesto_Desctos
        , DEFAULT_Impuesto_Producto
        , DEFAULT_Impuesto_Ventas
        , DEFAULT_LeyendaFactura

        , DEFAULT_LinkImportacion

        , DEFAULT_ListaPrecioCompra
        , DEFAULT_ListaPrecioVenta
        , DEFAULT_Logo_Web
        , DEFAULT_LogoAdicionalEmp
        , DEFAULT_MargenUtilidad
        , DEFAULT_MaxDiasCredito
        , DEFAULT_MaximoComision
        , DEFAULT_MaximoDescuento

        , DEFAULT_Merca_Aduana
        , DEFAULT_Merca_Apto
        , DEFAULT_Merca_Consignacion
        , DEFAULT_Merca_PorRegular
        , DEFAULT_Merca_Retirada
        , DEFAULT_MercaderApto
        , DEFAULT_MercaderConsig
        , DEFAULT_MercaderMalogra
        , DEFAULT_MercaderVendida

        , DEFAULT_MinimoComision
        , DEFAULT_MinimoDescuento

        , DEFAULT_MonedaInt
        , DEFAULT_MonedaNac

        , DEFAULT_MotivoAnula

        , DEFAULT_Movim_Compra
        , DEFAULT_Movim_Devolucion
        , DEFAULT_Movim_Entrada
        , DEFAULT_Movim_InvCierre
        , DEFAULT_Movim_InvInicial
        , DEFAULT_Movim_Mermas
        , DEFAULT_Movim_NotCredDevol
        , DEFAULT_Movim_Salida
        , DEFAULT_Movim_SInicial
        , DEFAULT_Movim_Venta
        , DEFAULT_Movim_VentaDevol
        , DEFAULT_Movim_VentaRetiro

        , DEFAULT_NotaIngrEstado
        , DEFAULT_NotaSalidaEstado
        , DEFAULT_OpacidadWindow
        , DEFAULT_Path_Empleados
        , DEFAULT_Path_Exportacion
        , DEFAULT_Path_Importacion
        , DEFAULT_Path_ODP
        , DEFAULT_Path_Productos
        , DEFAULT_Path_Sistema
        , DEFAULT_PathOI
        , DEFAULT_PersonaBancos
        , DEFAULT_PersonaPorDefecto
        , DEFAULT_PersonaTransporte
        , DEFAULT_PersonaVendedor
        , DEFAULT_PonerCantiArticTick
        , DEFAULT_PonerNombreVendImpF
        , DEFAULT_PrefijoPtoVta
        , DEFAULT_ProducEnvaseEmb
        , DEFAULT_ProducMaterPrim
        , DEFAULT_ProducTerminado
        , DEFAULT_Producto
        , DEFAULT_ProductoCateg
        , DEFAULT_ProductoMarca
        , DEFAULT_Proveedor
        , DEFAULT_RolAdmin
        , DEFAULT_SectorAlmacenami
        , DEFAULT_SectorDeVenta

        , DEFAULT_SFS_DOCUMENTO
        , DEFAULT_SFS_MAIL_CLAVE
        , DEFAULT_SFS_MAIL_CUENTA
        , DEFAULT_SFS_MAIL_PUERTO
        , DEFAULT_SFS_MAIL_SMTP
        , DEFAULT_SFS_MAIL_SSL
        , DEFAULT_SFS_MAIL_NOTA
        , DEFAULT_SFS_MAIL_AVISO

        , DEFAULT_SFS_RUTA_ACEPTADOS
        , DEFAULT_SFS_RUTA_BANDEJA
        , DEFAULT_SFS_RUTA_BAT
        , DEFAULT_SFS_RUTA_CODIGOBARRAS
        , DEFAULT_SFS_RUTA_CONTING
        , DEFAULT_SFS_RUTA_PDF
        , DEFAULT_SFS_RUTA_PLANOSSUNAT
        , DEFAULT_SFS_RUTA_FIRMADOS
        , DEFAULT_SFS_RUTA_SUNATBKP
        , DEFAULT_SFS_TIPOTRIBUTOISC
        , DEFAULT_SFS_UBL
        , DEFAULT_SFS_NUM_DIA_PLAZO
        , DEFAULT_SFS_MONTO_MIN_BVT_DNI
        , DEFAULT_SFS_NDIAS_ALERT_CD

        , DEFAULT_SitioWEBPersona
        , DEFAULT_Size_FotoLogotipo
        , DEFAULT_Size_FotoPersonas
        , DEFAULT_Size_FotoProducto
        , DEFAULT_SizeFile_ODP
        , DEFAULT_SizeFTransferMB

        , DEFAULT_StockMaximo
        , DEFAULT_StockMinimo

        , DEFAULT_Telefono1Persona
        , DEFAULT_Telefono2Persona
        , DEFAULT_TiempoPlazoCredito
        , DEFAULT_Time60
        , DEFAULT_TipoDeTurno
        , DEFAULT_Titulo_Web
        , DEFAULT_TrabajaDeposito
        , DEFAULT_Ubigeo
        , DEFAULT_UnidadMedida
        , DEFAULT_Valid_TCambio
        , DEFAULT_VerAvisoDEMOS
        , DEFAULT_VerAvisoPrecios

        , DEFAULT_WidthPantalla
        , DEFAULT_WidthPantallaP

        , EST_BVT_Archivado
        , EST_COT_Archivado

        , EST_DUA_Nacionalizado
        , EST_DUA_Pendiente

        , EST_EQUI_Cerrado
        , EST_EQUI_Vigente

        , EST_FAC_Archivado
        , EST_FAC_Cancelada
        , EST_FAC_Emitida

        , EST_GRE_Archivado
        , EST_MNTO_Cerrado
        , EST_MNTO_Pendiente

        , EST_ODP_Cerrado
        , EST_ODP_Pendiente
        , EST_OIM_Cerrado
        , EST_OIM_Pendiente

        , DEFAULT_DetraccionPersonaBanco
        , DEFAULT_DetraccionFormaPago
        , DEFAULT_DetraccionServicio
    }
}
