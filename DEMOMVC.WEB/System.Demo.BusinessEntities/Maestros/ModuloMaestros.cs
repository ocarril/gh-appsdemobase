namespace System.Demo.BusinessEntities.Maestros
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.SysAuditoria.cs]
    /// </summary>
    public class sysEntidadesTablas
    {
        public sysEntidadesTablas()
        {
        }

        public string Item { get; set; }
        public string Campo001 { get; set; }
        public string Campo002 { get; set; }
        public string Campo003 { get; set; }
        public string Campo004 { get; set; }
        public string Campo005 { get; set; }

        public override string ToString()
        {
            return Item;
        }

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class SysTablas
    {
        public string Item { get; set; }
        public string EsquemaNombreTabla { get; set; }
        public string NombreTabla { get; set; }

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.SysReportes.cs]
    /// </summary>
    public class SysReportesParametros
    {
        public string prm_FechaInicio { get; set; }
        public string prm_FechaFinal { get; set; }
        public string prm_Documento { get; set; }
        public string prm_DocumentoEstado { get; set; }
        public string prm_Entidad { get; set; }
        public string prm_Producto { get; set; }
        public string prm_DestinoDocumento { get; set; }
        public string prm_Operacion { get; set; }
        public string prm_TituloReporte { get; set; }
        public string prm_EmpresaNombre { get; set; }
        public string prm_EmpresaPuntoVta { get; set; }
        public string prm_EmpresaRuc { get; set; }
        public string prm_EmpresaDireccion { get; set; }
        public string prm_Periodo { get; set; }
        public string prm_Deposito { get; set; }
        public string prm_Cancelado { get; set; }
        public string prm_GastoAduanero { get; set; }
        public string prm_EntidadVendedor { get; set; }
        public string prm_AtendidoPor { get; set; }
        public string prm_TipoDeMoneda { get; set; }
        public string prm_CompraInternacional { get; set; }
        public bool prm_IndicadorReporte { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltros.cs]
    /// </summary>
    public class BaseFiltroMaestro
    {
        public BaseFiltroMaestro()
        {
            codigoEntidad = string.Empty;
            desNombre = string.Empty;
            codKeyConfig = string.Empty;
            segUsuario = string.Empty;
            codTabla = string.Empty;
            desValor = string.Empty;
            codReg = string.Empty;
            codTipo01 = string.Empty;
            codRegTipoEntidad = string.Empty;
            codRegAsignacion = string.Empty;
            codPerEmpresa = string.Empty;
            codRegAreaEmpresa = string.Empty;
            codRegCategoria = string.Empty;
            codRegTipoAtributo = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string numRUC { get; set; }
        public int GNumPagina { get; set; }
        public int GTamPagina { get; set; }
        public string GOrdenPor { get; set; }
        public string GOrdenTipo { get; set; }

        public int? codEntidad { get; set; }
        public int? codConfiguracion { get; set; }
        public string codigoEntidad { get; set; }
        public string desNombre { get; set; }
        public bool? indActivo { get; set; }
        public string codKeyConfig { get; set; }
        public string segUsuario { get; set; }
        public string codTabla { get; set; }
        public string desValor { get; set; }

        public int codCaso { get; set; }
        public int numNivel { get; set; }
        public string codReg { get; set; }
        public string codTipo01 { get; set; }

        public string codRegTipoEntidad { get; set; }
        public string codRegAsignacion { get; set; }
        public string codPerEmpresa { get; set; }
        public string codRegAreaEmpresa { get; set; }
        public string codRegCategoria { get; set; }
        public string codRegTipoAtributo { get; set; }

        public string codRegistro { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public string segMaquinaOrigen { get; set; }

        public int numLongitudNivel { get; set; }
        public string codRegistroPadre { get; set; }
    }

    public class BaseFiltroConfiguracion: BEBuscadorBaseRequest
    {
        public BaseFiltroConfiguracion()
        {
            numRUCEmpresa = string.Empty;
            codKeyConfig = string.Empty;
            segUsuarioActual = string.Empty;
            codTabla = string.Empty;
            segUsuarioActual = string.Empty;
            desValor = string.Empty;
            desNombre = string.Empty;
        }

        public int codConfiguracion { get; set; }

        public bool? indActivo { get; set; }

        public string desNombre { get; set; }

        public string codKeyConfig { get; set; }

        public string desValor { get; set; }

        public string codTabla { get; set; }

        [JsonIgnore]
        public string numRUCEmpresa { get; set; }

    }

    public class BaseFiltroEmpresaConfig
    {
        public BaseFiltroEmpresaConfig()
        {
            numRUCEmpresa = string.Empty;
            codKeyConfig = string.Empty;
            segUsuarioActual = string.Empty;
            codRegTipoEntidad = string.Empty;
            segUsuarioActual = string.Empty;
        }

        public bool? indActivo { get; set; }

        public string codKeyConfig { get; set; }
  
        public string codRegTipoEntidad { get; set; }
     
        [JsonIgnore]
        public string segUsuarioActual { get; set; }
 
        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string numRUCEmpresa { get; set; }
       
    }

    public class BaseFiltroPersona : BEBuscadorBaseRequest
    {
        public BaseFiltroPersona()
        {
            codigoEntidad = string.Empty;
            desNombre = string.Empty;
            codRegTipoEntidad = string.Empty;
            codRegAsignacion = string.Empty;
            codPersonaRefer = string.Empty;
            codRegAreaEmpresa = string.Empty;
            codRegCategoria = string.Empty;
            codRegTipoAtributo = string.Empty;
        }

        public string codPersonaRefer { get; set; }

        public string codigoEntidad { get; set; }
        public string desNombre { get; set; }
        public bool? indActivo { get; set; }
        public string desValor { get; set; }

        public string codRegTipoEntidad { get; set; }
        public string codRegAsignacion { get; set; }
        public string codRegAreaEmpresa { get; set; }
        public string codRegCategoria { get; set; }
        public string codRegTipoAtributo { get; set; }

    }

    public class BaseFiltroPersonaDomicilio : BEBuscadorBaseRequest
    {
        public BaseFiltroPersonaDomicilio()
        {
            codigoEntidad = string.Empty;
            desDireccion = string.Empty;
            codRegTipoEntidad = string.Empty;
            codRegAsignacion = string.Empty;
            codPersona = string.Empty;
            codRegAreaEmpresa = string.Empty;
            codRegCategoria = string.Empty;
            codRegTipoAtributo = string.Empty;
        }

        public string codPersona { get; set; }

        public string codigoEntidad { get; set; }
        public string desDireccion { get; set; }
        public bool? indActivo { get; set; }
        public string desValor { get; set; }

        public string codRegTipoEntidad { get; set; }
        public string codRegAsignacion { get; set; }
        public string codRegAreaEmpresa { get; set; }
        public string codRegCategoria { get; set; }
        public string codRegTipoAtributo { get; set; }

    }
}
