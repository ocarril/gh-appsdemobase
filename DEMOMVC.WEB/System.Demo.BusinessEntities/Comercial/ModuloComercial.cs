using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.BusinessEntities.Comercial
{



    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltros.cs]
    /// </summary>
    public class BaseFiltro : BEBuscadorBaseRequest
    {
        public int codDocumReg { get; set; }


        public int? codTipoCambio { get; set; }
        public int? codEntidad { get; set; }
        public int? codProducto { get; set; }
        public string codProductoRefer { get; set; }
        public int? codGrupo { get; set; }
        public int indOperador { get; set; }
        public int indIncidenciaStock { get; set; }
        public int codDocumRegDetalle { get; set; }
        public int? codDocumRegGasto { get; set; }
        public string codImpuesto { get; set; }
        public int codCajaRegistro { get; set; }
        public int? codId { get; set; }
        public int codInventario { get; set; }
        public int codProductoSeriado { get; set; }
        public int? codEmpleado { get; set; }
        public int? codEmpleadoVendedor { get; set; }

        public string codAlmacen { get; set; }
        public string codArticuloSeriado { get; set; }
        public string codEntidadReferencia { get; set; }
        public string codParteDiario { get; set; }
        public string codPerProveedor { get; set; }
        public string codPerCliente { get; set; }
        public string codPerEntidad { get; set; }
        public string codPerEmpleado { get; set; }
        public string codPerVendedor { get; set; }
        public int? codPerInventario { get; set; }
        public string codPuntoVenta { get; set; }
        public string codDocumento { get; set; }
        public int? codDocumentoEstado { get; set; }
        public string codDocumentoAsos { get; set; }
        public string codReferencia { get; set; }
        public string codListaPrecio { get; set; }
        public string codTurno { get; set; }
        public string codItem { get; set; }
        public int? codCondicionVenta { get; set; }
        public int? codCondicionCompra { get; set; }
        public int? codsFormaPago { get; set; }
        public int? codFormaPago { get; set; }
        public string codTalonario { get; set; }


        public string codRegTipoTurno { get; set; }
        public string codRegDiaSemana { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegLineaProd { get; set; }
        public string codRegMaterialProd { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string codRegDocumento { get; set; }
        public string codRegDestinoDocum { get; set; }
        public string codRegEstado { get; set; }
        public string codRegMarca { get; set; }
        public string codRegTipo { get; set; }
        public string codRegTipoMotivo { get; set; }
        public string codRegTipoMovimiUno { get; set; }
        public string codRegTipoMovimiDos { get; set; }
        public string codRegCentroProducc { get; set; }
        public string codRegCategoria { get; set; }
        public string codRegGasto { get; set; }
        public string codRegAnulacion { get; set; }
        public string codRegTipoOperacion { get; set; }
        public string codRegEstadoMercaderia { get; set; }

        public string desNombre { get; set; }
        public string desComercial { get; set; }
        public string fecProceso { get; set; }
        public string fecInicio { get; set; }
        public string fecFinal { get; set; }
        public string desPalabraClave { get; set; }
        public string perPeriodo { get; set; }
        public string perTributario { get; set; }
        public string segUsuarioEdita { get; set; }
        public string numDocumento { get; set; }
        public string numDocumentoCompromiso { get; set; }
        public string numDocumentoVenta { get; set; }
        public string numDocumentoCompra { get; set; }
        public string gloObservacion { get; set; }
        public string codDocumentoReferencia { get; set; }
        public string numDocumentoReferencia { get; set; }
        public string numSerieProducto { get; set; }
        public string desAgrupacion { get; set; }

        public Nullable<DateTime> fecProcesoDate { get; set; }
        public Nullable<DateTime> fecInicioDate { get; set; }
        public Nullable<DateTime> fecFinalDate { get; set; }
        public Nullable<DateTime> fecCierreInventario { get; set; }
        public Nullable<DateTime> fecAnulacion { get; set; }
        public Nullable<DateTime> fecDeclaracion { get; set; }
        public Nullable<DateTime> fecCancelacion { get; set; }

        public bool? indEstado { get; set; }
        public bool? indFiscal { get; set; }
        public bool? indLocal { get; set; }
        public bool? indDestinoCompra { get; set; }
        public bool? indDestinaVenta { get; set; }
        public bool? indVentaCompra { get; set; }
        public bool? indComprometido { get; set; }
        public bool? indVendido { get; set; }
        public bool? indParaVenta { get; set; }
        public bool indVacio { get; set; }
        public bool indTodos { get; set; }
        public bool indTraeDetalle { get; set; }
        public bool indArticuloExistencia { get; set; }
        public bool indAsientoEnKardex { get; set; }
        public bool? indConciliado { get; set; }
        public bool? indCajaActiva { get; set; }
        public bool? indCancelado { get; set; }
        public bool? indEliminado { get; set; }
        public bool? indInternacional { get; set; }
        public bool? indLogicoFiltro { get; set; }
        public bool indContabilizado { get; set; }
        public decimal cntStockInicial { get; set; }
        public decimal cntStockFisico { get; set; }
        public decimal cntStockMerma { get; set; }
        public decimal cntStockSobrante { get; set; }
        public decimal cntStockComprometido { get; set; }
        public decimal monTipoCambioVenta { get; set; }
        public int? cntConteo { get; set; }
        public int? perAnio { get; set; }
        public int? cntRegistros { get; set; }
        public string gloDescripcion { get; set; }

        public int grpageSize { get; set; }
        public int grcurrentPage { get; set; }
        public string grsortColumn { get; set; }
        public string grsortOrder { get; set; }
        public bool indConDetalle { get; set; }
    }

    public class BaseFiltroDocumRegVendedor
    {
        public BaseFiltroDocumRegVendedor()
        {
            codPerEntidad = string.Empty;
            codRegDestinoDocum = string.Empty;
        }

        public int codEmpresa { get; set; }

        public string codPerEntidad { get; set; }

        public string codRegDestinoDocum { get; set; }

        [JsonIgnore]
        public string segUsuarioEdita { get; set; }
    }


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    :
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltros.cs]
    /// </summary>
    public class FiltroDocumReg : BEBuscadorBase
    {
        public FiltroDocumReg()
        {
            codDocumento = string.Empty;
            codPuntoVenta = string.Empty;
            numDocumento = string.Empty;
            codEmpresaRUC = string.Empty;
        }

        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string numDocumento { get; set; }

    }

    public class FiltroDocumRegPage : BEBuscadorBaseRequest
    {
        public FiltroDocumRegPage()
        {
            codDocumento = string.Empty;
            codPuntoVenta = string.Empty;
            numDocumento = string.Empty;
            codEmpresaRUC = string.Empty;
            desComercial = string.Empty;
            desDomicilio = string.Empty;
            codRegDestinoDocum = string.Empty;
            numDocumentoEntidad = string.Empty;
            numOrdenDeCompra = string.Empty;
            numPedidoAdquisicion = string.Empty;
            codParteDiario = string.Empty;
            numGuiaDeSalida = string.Empty;
            codRegTipoOperacion = string.Empty;
            fecInicio = string.Empty;
            fecFinal = string.Empty;
            perTributario = string.Empty;
            codRegEstadoDocu = string.Empty;
            codPersonaEntidad = string.Empty;
        }


        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string numDocumento { get; set; }

        public string desComercial { get; set; }

        public string desDomicilio { get; set; }

        public string codRegDestinoDocum { get; set; }

        public string numDocumentoEntidad { get; set; }

        public int? codEmpleado { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string codParteDiario { get; set; }

        public int? codCondicionVenta { get; set; }

        public int? codCondicionCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public string codRegTipoOperacion { get; set; }

        public string perTributario { get; set; }

        public Nullable<DateTime> fecInicioDate { get; set; }

        public Nullable<DateTime> fecFinalDate { get; set; }

        public string codRegEstadoDocu { get; set; }

        public string codPersonaEntidad { get; set; }

        [JsonIgnore]
        public string fecInicio { get; set; }

        [JsonIgnore]
        public string fecFinal { get; set; }


    }

    public class FiltroDocumRegDetallePage : BEBuscadorBaseRequest
    {
        public FiltroDocumRegDetallePage()
        {
            codDocumento = string.Empty;
            codPuntoVenta = string.Empty;
            numDocumento = string.Empty;
            codEmpresaRUC = string.Empty;
            desComercial = string.Empty;
            numDocumentoEntidad = string.Empty;
            fecInicio = string.Empty;
            fecFinal = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string numDocumento { get; set; }

        public string desComercial { get; set; }
        
        public string numDocumentoEntidad { get; set; }

        public int? codEmpleadoVendedor { get; set; }

        public Nullable<DateTime> fecInicioDate { get; set; }

        public Nullable<DateTime> fecFinalDate { get; set; }


        [JsonIgnore]
        public string fecInicio { get; set; }

        [JsonIgnore]
        public string fecFinal { get; set; }
        
    }

    public class FiltroDocumRegForReference : BEBuscadorBaseRequest
    {
        public FiltroDocumRegForReference()
        {
            jqCurrentPage = 1;
            jqPageSize = 100;
            jqSortColumn = "fecEmision";
            jqSortOrder = "DESC";
            codDocumentoSerie = 0;
            numDocumento = string.Empty;
            codEmpresaRUC = string.Empty;
        }

        public int codDocumentoSerie { get; set; }

        public string numDocumento { get; set; }

        public string codEntidad { get; set; }
               
    }

    

    public class BaseFiltroDocumentSerieEmployee : BEBuscadorBaseRequest
    {
        public BaseFiltroDocumentSerieEmployee()
        {
            indEstado = true;
        }

        public int? codDocumentoSerie { get; set; }

        public int? codEmpleado { get; set; }

        public bool? indEstado { get; set; }

    }
    
    public class BaseFiltroProductoConsignacion : BEBuscadorBase
    {
        public BaseFiltroProductoConsignacion()
        {
            codDocumento = string.Empty;
            codPuntoVenta = string.Empty;
            numDocumento = string.Empty;
            codPerEmpresa = string.Empty;
        }

        public string codDocumento { get; set; }

        public string codPuntoVenta { get; set; }

        public string numDocumento { get; set; }

        public string codPerEmpresa { get; set; }

        public Nullable<DateTime> fecInicioDate { get; set; }
        public Nullable<DateTime> fecFinalDate { get; set; }

        public string fecInicio { get; set; }
        public string fecFinal { get; set; }

        public int? codProducto { get; set; }

        public string codPerEntidad { get; set; }

        public string numSerieProducto { get; set; }
    }

    public class BaseFiltroParteDiarioTurno : BEBuscadorBase
    {
        public BaseFiltroParteDiarioTurno()
        {
            codEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            codRegTipoTurno = string.Empty;
            desNombre = string.Empty;
            codRegDiaSemana = string.Empty;
            codTurno = string.Empty;
            indEstado = false;
        }


        public string codTurno { get; set; }

        public string codPuntoVenta { get; set; }

        public string codRegTipoTurno { get; set; }

        public string desNombre { get; set; }

        public string codRegDiaSemana { get; set; }

        public bool indEstado { get; set; }

        [JsonIgnore]
        public string codPlanilla { get; set; }

    }

    public class BaseFiltroCondicion : BEBuscadorBase
    {
        public BaseFiltroCondicion()
        {
            desNombre = string.Empty;
            indDestinoVenta = false;
            indEstado = false;
        }

        public int? codCondicionCompra { get; set; }

        public string desNombre { get; set; }

        public bool indDestinoVenta { get; set; }

        public bool indEstado { get; set; }

    }

    public class BaseFiltroCondicionPage : BEBuscadorBaseRequest
    {
        public BaseFiltroCondicionPage()
        {
            desNombre = string.Empty;
            indDestinoVenta = false;
            indEstado = false;
        }

        public int? codCondicionCompra { get; set; }

        public string desNombre { get; set; }

        public bool indDestinoVenta { get; set; }

        public bool indEstado { get; set; }

    }

    public class BaseFiltroImpuesto : BEBuscadorBase
    {
        public BaseFiltroImpuesto()
        {
            desNombre = string.Empty;
            codImpuesto = string.Empty;
            indEstado = false;
        }

        public string codImpuesto { get; set; }

        public string desNombre { get; set; }

        public bool? indEstado { get; set; }

    }

    public class BaseFiltroParteDiario : BEBuscadorBase
    {
        public BaseFiltroParteDiario()
        {
            codEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            fechaParte = string.Empty;
            codParteDiario = string.Empty;
            codTurno = string.Empty;
        }


        public string codPuntoVenta { get; set; }

        public string codParteDiario { get; set; }

       public string codTurno { get; set; }

        public string fechaParte { get; set; }
 
        public int codEmpleado { get; set; }

        public bool indCajaActiva { get; set; }

    }

    public class BaseFiltroCajaRegistroPage: BEBuscadorBaseRequest
    {
        public BaseFiltroCajaRegistroPage()
        {

        }

        public string fecIngresoInicio { get; set; }
        public string fecIngresoFinal { get; set; }
        public int? codDocumReg { get; set; }

        public string codPuntoVenta { get; set; }

        public  string codRegDestinoDocum { get; set; }
        public string codPersonaEntidad { get; set; }
        public int? codEmpleado { get; set; }
        public string codRegMoneda { get; set; }
        public string codParteDiario { get; set; }
        public int? codFormaDePago { get; set; }
        public bool? indConciliado { get; set; }
    }

    public class BaseFiltroImpuestoPage : BEBuscadorBaseRequest
    {
        public BaseFiltroImpuestoPage()
        {
            desNombre = string.Empty;
            codImpuesto = string.Empty;
            indEstado = false;
        }

        public string codImpuesto { get; set; }

        public string desNombre { get; set; }

        public bool? indEstado { get; set; }

    }

    public class BaseFiltroDocumentoImpuesto : BEBuscadorBase
    {
        public BaseFiltroDocumentoImpuesto()
        {
            codEmpresaRUC = string.Empty;
            codDocumento = string.Empty;
            codImpuesto = string.Empty;
            indEstado = false;
        }

        public int? codDocumentoImpuesto { get; set; }

        public string codDocumento { get; set; }

        public string codImpuesto { get; set; }

        public bool indEstado { get; set; }

    }

    public class BaseFiltroDocumentoImpuestoPage : BEBuscadorBaseRequest
    {
        public BaseFiltroDocumentoImpuestoPage()
        {
            desNombre = string.Empty;

            codImpuesto = string.Empty;
            indEstado = false;
        }

        public string codDocumento { get; set; }
        public string codImpuesto { get; set; }

        public string desNombre { get; set; }

        public bool? indEstado { get; set; }

    }

    public class BaseFiltroDocumentoEstado : BEBuscadorBase
    {
        public BaseFiltroDocumentoEstado()
        {
            codRegDocumento = string.Empty;
            codRegEstado = string.Empty;
        }

        public int? codDocumentoEstado { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstado { get; set; }

    }

    public class BaseFiltroDocumentoSerie : BEBuscadorBase
    {
        public BaseFiltroDocumentoSerie()
        {
            desNombre = string.Empty;
            codEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            codRegDestino = string.Empty;
            tipDocumento = string.Empty;
            lstTipDocumento = new List<string>();
        }


        public int? codDocumentoSerie { get; set; }

        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string desNombre { get; set; }

        public bool? indEstado { get; set; }

        public string codPlanilla { get; set; }

        public string tipDocumento { get; set; }

        public List<string> lstTipDocumento { get; set; }


        public string codRegDestino { get; set; }

        public int pindView { get; set; }

    }

    public class BaseFiltroDocumentoSeriePage : BEBuscadorBaseRequest
    {
        public BaseFiltroDocumentoSeriePage()
        {
            desNombre = string.Empty;
            codEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            indEstado = true;
        }

        public int? codDocumentoSerie { get; set; }

        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string desNombre { get; set; }

        public bool indEstado { get; set; }

        public string nomEmpleado { get; set; }

        

    }

    public class BaseFiltroDocumento : BEBuscadorBaseRequest
    {
        public BaseFiltroDocumento()
        {
            desNombre = string.Empty;
            codEmpresaRUC = string.Empty;
            codDocumento = string.Empty;
            codRegDocumento = string.Empty;
            codDocumentoAsos = string.Empty;
            codRegDestinoDocum = string.Empty;
            Abreviatura = string.Empty;
            indEstado = false;
        }

        public string codPuntoVenta { get; set; }
        public string codDocumento { get; set; }

        public string codRegDocumento { get; set; }

        public string codDocumentoAsos { get; set; }

        public string codRegDestinoDocum { get; set; }

        public string desNombre { get; set; }

        public string Abreviatura { get; set; }

        public bool? indFiscal { get; set; }

        public bool? indLocal { get; set; }

        public bool? indEstado { get; set; }

    }

    public class BaseFiltroPuntoDeVenta : BEBuscadorBaseRequest
    {
        public BaseFiltroPuntoDeVenta()
        {
            codEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            desNombre = string.Empty;
        }

        public string codPuntoVenta { get; set; }

        public string desNombre { get; set; }

        public bool indEstado { get; set; }

    }

    public class BaseFiltroProductoPrecio : BEBuscadorBaseRequest
    {
        public BaseFiltroProductoPrecio()
        {
            codEmpresaRUC = string.Empty;
            codRegMoneda = string.Empty;
            codPuntoVenta = string.Empty;
        }

        public int? codProductoPrecio { get; set; }
        public int? codProducto { get; set; }

        public string codRegMoneda { get; set; }

        public string codListaPrecio { get; set; }

        public string codPuntoVenta { get; set; }

        public bool? indEstado { get; set; }

    }

    public class BaseFiltroInventarioActual : BEBuscadorBase
    {
        public BaseFiltroInventarioActual()
        {
            codPerEmpresaRUC = string.Empty;
            codPuntoVenta = string.Empty;
            codProductoRefer = string.Empty;
            codAlmacen = string.Empty;
            codRegCategoria = string.Empty;
        }

        public string codPerEmpresaRUC { get; set; }

        public string codPuntoVenta { get; set; }

        public string codAlmacen { get; set; }

        public int? codGrupo { get; set; }

        public string codRegCategoria { get; set; }

        public string codProductoRefer { get; set; }

    }

    public class BaseFiltroTipoCambio : BEBuscadorBase
    {
        public BaseFiltroTipoCambio()
        {

        }
        public int? codTipoCambio { get; set; }
        public Nullable<DateTime> fecInicioDate { get; set; }
        public Nullable<DateTime> fecFinalDate { get; set; }

        public string fecInicio { get; set; }
        public string fecFinal { get; set; }
        public string codRegMoneda { get; set; }
        public bool indEstado { get; set; }
    }

    public class BaseFiltroTipoCambioPage : BEBuscadorBaseRequest
    {
        public BaseFiltroTipoCambioPage()
        {

        }
        public int? codTipoCambio { get; set; }
        public Nullable<DateTime> fecInicioDate { get; set; }
        public Nullable<DateTime> fecFinalDate { get; set; }

        public string fecInicio { get; set; }
        public string fecFinal { get; set; }
        public string codRegMoneda { get; set; }
        public bool indEstado { get; set; }
    }

    
    public class BaseFiltroCuentaCorrientePage : BEBuscadorBaseRequest
    {
        public BaseFiltroCuentaCorrientePage()
        {
            numDocumento = string.Empty;
            codParteDiario = string.Empty;
        }
        
        public DateTime? fecInicio { get; set; }
        public DateTime? fecFinal { get; set; }
        public string codPuntoVenta { get; set; }
        public string codPersonaEntidad { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string codRegDestinoDocum { get; set; }
        public int? codDocumReg { get; set; }
        public string codParteDiario { get; set; }


        [JsonIgnore]
        public string fecInicioStr { get; set; }
        [JsonIgnore]
        public string fecFinalStr { get; set; }

    }

    public static class ConstantesGC
    {
        /// <summary>
        /// GDSTC Documentos - Destino de comprobantes
        /// </summary>
        //public const string OPERACION_DESTINO_VENTAS = "GDSTC001";
        //public const string OPERACION_DESTINO_COMPRAS = "GDSTC002";
        //public const string OPERACION_DESTINO_INTERNO = "GDSTC003";

        /// <summary>
        /// Condiciones de Venta 
        /// </summary>
        public const Int32 CONDICION_VENTA_CONTADO = 1;
        public const Int32 CONDICION_VENTA_CREDITO = 2;

        /// <summary>
        /// Condiciones de Compra
        /// </summary>
        public const Int32 CONDICION_COMPRA_CONTADO = 4;
        public const Int32 CONDICION_COMPRA_CREDITO = 5;

        /// <summary>
        /// Estado Archivado de documentos
        /// </summary>
        public const string ESTADO_ARCHIVADO_COT = "GCMPB011004";
        public const string ESTADO_ARCHIVADO_GRE = "GCMPB009004";

        /// <summary>
        /// GMMOV	Productos - Kardex - Tipos de movimientos
        /// </summary>
        public const string TIPO_MOV_KARDEX_ENTRADA = "GMMOV001";           //  Entradas
        public const string TIPO_MOV_KARDEX_SALIDA = "GMMOV002";            //  Salidas
        public const string TIPO_MOV_KARDEX_SALDO_INICIAL = "GMMOV003";     //  Saldo Inicial
        public const string TIPO_MOV_KARDEX_CIERRE_INVENTARIO = "GMMOV004"; //  Cierre-Inventario
        public const string TIPO_MOV_KARDEX_DEVOLUCION = "GMMOV005";        //  Devolución

        // GTMOV	Documentos - Motivos de Movimientos
        public const string TIPO_MOV_DOCUME_VENTA = "GTMOV001";             //  Venta
        public const string TIPO_MOV_DOCUME_COMPRA = "GTMOV002";            //  Compra
        public const string TIPO_MOV_DOCUME_CONSIG_RECIBIDA = "GTMOV003";   //  Consignacion Recibida
        public const string TIPO_MOV_DOCUME_CONSIG_ENTREGADA = "GTMOV004";  //  Consignacion Entregada
        public const string TIPO_MOV_DOCUME_DEVOLU_RECIBIDA = "GTMOV005";   //  Devolución recibida
        public const string TIPO_MOV_DOCUME_DEVOLU_ENTREGADA = "GTMOV006";  //  Devolución entregada    
        public const string TIPO_MOV_DOCUME_PROMOCION = "GTMOV007";         //  Promoción
        public const string TIPO_MOV_DOCUME_PREMIO = "GTMOV008";            //	Premio
        public const string TIPO_MOV_DOCUME_DONACION = "GTMOV009";          //	Donación
        public const string TIPO_MOV_DOCUME_SALIDA_PRODUCCION = "GTMOV010"; //	Salida a Producción
        public const string TIPO_MOV_DOCUME_TRANSFER_ALMACEN = "GTMOV011";  //	Transferencia entre almacenes
        public const string TIPO_MOV_DOCUME_RETIRO = "GTMOV012";            //	Retiro
        public const string TIPO_MOV_DOCUME_MERMAS = "GTMOV013";            //	Mermas
        public const string TIPO_MOV_DOCUME_DESMEDROS = "GTMOV014";         //	Desmedros
        public const string TIPO_MOV_DOCUME_DESTRUCCION = "GTMOV015";       //	Destrucción
        public const string TIPO_MOV_DOCUME_SALDO_INICIAL = "GTMOV016";     //	Saldo Inicial
        public const string TIPO_MOV_DOCUME_OTROS = "GTMOV017";             //	Otros (Especificar)
        public const string TIPO_MOV_DOCUME_OPORTUNIDAD = "GTMOV018";       //	Oportunidad
        public const string TIPO_MOV_DOCUME_NotaCredDevol = "GTMOV022";     //  TIPO_MOV_DOCUME_NotaCredDevol ¿Quien lo usa?

        //  GMTGU	Documentos - Motivos de la Guia de Remisión
        public const string MOTIVO_GUIA_X_VENTA = "GMTGU001";	            //Venta
        public const string MOTIVO_GUIA_X_TRANSFORMACION = "GMTGU002";	    //Transformación
        public const string MOTIVO_GUIA_X_CONSIGNACION = "GMTGU003";	    //Consignación
        public const string MOTIVO_GUIA_X_TRASLADO_MISMA_EMPRESA = "GMTGU004";//Traslado entre Estableci. misma Empresa 
        public const string MOTIVO_GUIA_X_TRASLADO_EMISOR_ITINER = "GMTGU005";//Traslado por Emisor Itiner. de Comp
        public const string MOTIVO_GUIA_X_VENTA_A_CONFIRMAR = "GMTGU006";	//Venta sujeta a Confirmar
        public const string MOTIVO_GUIA_X_COMPRA = "GMTGU007";	            //Compra
        public const string MOTIVO_GUIA_X_DEVOLUCION = "GMTGU008";	        //Devolución
        public const string MOTIVO_GUIA_X_RECOJO_BIENES = "GMTGU009";	    //Recojo bienes Transformados
        public const string MOTIVO_GUIA_X_ZONA_PRIMARIA = "GMTGU010";	    //Zona Primaria
        public const string MOTIVO_GUIA_X_IMPORTACION = "GMTGU011";	        //Importación
        public const string MOTIVO_GUIA_X_EXPORTACION = "GMTGU012";	        //Exportación
        public const string MOTIVO_GUIA_X_OTROS = "GMTGU013";	            //Otros
        // VALORE
        public const string VALOR_SI = "S";	            //
        public const string VALOR_NO = "N";	            //
    }

    /// <summary>
    /// Enumeración de Estilos para Reportes GC
    /// </summary>
    /// <remarks>
    /// Creacion: 	
    /// </remarks>
    public enum EstilosReporteGC : int
    {
        FondoLila = 1,
        FondoBase = 2,
        FondoNegro = 3,
        FondoPost = 4,
        FondoPostPais = 5,
        FondoVerde = 6,
        FondoValorPagina = 7,
        ColorWorkingPage = 8,
        FondoDefecto = 9,
        CabeceraCuadro = 10,
        FondoGranate = 11,
        TituloReporte = 12
    }

}
