using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CROM.GC.Models
{
    #region MODELO Configuracion

    public class ConfiguracionIndexModels
    {
        public ConfiguracionIndexModels()
        {
            lstConfiguracion = new List<mvcConfiguracion>();
        }

        public string findcodKeyConfig { get; set; }
        public string findcodTabla { get; set; }
        /// <summary>
        /// Listado del modelo mvcConfiguracion
        /// </summary>
        public List<mvcConfiguracion> lstConfiguracion { get; set; }
    }

    public class mvcConfiguracion
    {
        public int codConfiguracion { get; set; }
        public string codKeyConfig { get; set; }
        public string codTabla { get; set; }
        public int numNivel { get; set; }
        public string indOrden { get; set; }
        public string indTipoValor { get; set; }
        public string desValor { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indGenerico { get; set; }
        public string desGrupo { get; set; }
        public bool indActivo { get; set; }
        public string usuarioEdita { get; set; }
        public string fechaEdita { get; set; }

        public int TOTALROWS { get; set; }
    }

    public class mvcTabla
    {
        public string codTabla { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public string indNivel { get; set; }
        public int numLongitudNivel { get; set; }
        public string indActivo { get; set; }
        public string segUsuModi { get; set; }
        public string segFecModi { get; set; }

        public int TOTALROWS { get; set; }
    }

    public class mvcRegistro
    {
        public string codRegistro { get; set; }
        public string codTabla { get; set; }
        public int numNivel { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }

        public decimal? desValorDecimal { get; set; }
        public string desValorCadena { get; set; }
        public string desValorLogico { get; set; }
        public int? desValorEntero { get; set; }
        public string desValorFecha { get; set; }

        public string indActivo { get; set; }
        public string segUsuModi { get; set; }
        public string segFecModi { get; set; }

        public bool indTieneNiveles { get; set; }

        public int TOTALROWS { get; set; }
    }


    public class PersonaModels
    {

        public SelectList lstTipoPersona { get; set; }

    }
    
    public class mvcPersona
    {
        public mvcPersona()
        {
            lstPersonaAsignacion = new List<mvcPersonaAsignacion>();
        }
        public string codPersona { get; set; }
        public string codRegTipoPersona { get; set; }

        public string desRazonSocial { get; set; }
        public string desNombreComercial { get; set; }

        public string desApePaterno { get; set; }
        public string desApeMaterno { get; set; }
        public string desNombre1 { get; set; }
        public string desNombre2 { get; set; }
        public string codEmpresa { get; set; }

        public string gloObservacion { get; set; }

        public string codRegRubro { get; set; }
        public bool Estado { get; set; }
        public string UsuModi { get; set; }
        public string FeModi { get; set; }


        public string CodigoPersonaEmpresa { get; set; }
        public string CodigoPersonaEmpresaNombre { get; set; }

        public string CodigoArguAreaEmpleado { get; set; }

        public List<mvcPersonaAsignacion> lstPersonaAsignacion { get; set; }
        public int TOTALROWS { get; set; }

        public string desNumDocumento { get; set; }

        public string desDomicilio { get; set; }

        public string desTelefono { get; set; }
    }

    public class mvcPersonaAtributo
    {
        public string codPersona { get; set; }
        public string codRegAtributoDato { get; set; }
        public string desNombre { get; set; }

        public string codRegUbigeo { get; set; }
        public string Estado { get; set; }
        public string UsuModi { get; set; }
        public string FeModi { get; set; }

        public string codRegAtributo { get; set; }
        public string codRegTipoAtributo { get; set; }
        public string desRegAtributo { get; set; }
        public string desRegTipoAtributo { get; set; }

        public string indProceso { get; set; }
        public int TOTALROWS { get; set; }
    }

    public class mvcPersonaAsignacion
    {
        public string codPersona { get; set; }
        public string codRegAsignacion { get; set; }
        public string Estado { get; set; }
    }

    public class mvcPersonaLogoFoto
    {
        public string codPersona { get; set; }
        public string nomArchivo { get; set; }
        public long tamArchivo { get; set; }
        public DateTime fecCreado { get; set; }
        public DateTime fecEditado { get; set; }
    }

    #endregion
}