namespace CROM.GC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;



    #region MODELO Orden de Importación

    /// <summary>
    /// Proyecto    : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Modelo 
    /// Archivo     : [Parametro.cs]
    /// </summary>
    public class Parametro
    {

        public int jqPageSize { get; set; }
        public int jqCurrentPage { get; set; }
        public string jqSortColumn { get; set; }
        public string jqSortOrder { get; set; }

        public string desCliente { get; set; }
        public string desArchivo { get; set; }
        public string desGlosa { get; set; }

        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public string codProveedor { get; set; }

        public string desNombre { get; set; }
        public string codKeyConfig { get; set; }
        public string codTabla { get; set; }
        public string desValor { get; set; }
        public string codTipo01 { get; set; }

        public bool indActivo { get; set; }
        public bool indDestinoVenta { get; set; }
        public string codEmpresa { get; set; }
        public string codPuntoVenta { get; set; }

        public string codDeposito { get; set; }
        public string codGrupo { get; set; }
        public string codRegCateg { get; set; }
        public string codProducto { get; set; }
        public string codReporte { get; set; }

        public int numNivel { get; set; }
        public string codReg { get; set; }

        public string codRegAsignacion { get; set; }
        public string codEntidad { get; set; }
        public string codRegArea { get; set; }
        public string codRegTipoAtributo { get; set; }
        public string codRegMoneda { get; set; }

        public string codNacionalizacion { get; set; }
        public string codIncoterm { get; set; }
        public string codResumenCosto { get; set; }
        public string numOI { get; set; }
        public string numDUA { get; set; }
        public int codDocumentoEstado { get; set; }

        public string codRegDocumento { get; set; }
        public string codRegEstado { get; set; }
        public string codRegCanal { get; set; }
        public string codRegDestino { get; set; }
        public string codDocumento{ get; set; }

        public int? codProyecto { get; set; }
        public int codPyDocumReg { get; set; }
        public int? codPyEquipo { get; set; }

        public string codPeriodo { get; set; }
        public int codInventario { get; set; }

        public string codPersonaRefer { get; set; }
    }

    #endregion

}