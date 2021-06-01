namespace CROM.GC.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Demo.Tools.settings;
    using System.Web.Mvc;

    #region MODELO DocumentoEstado

    public class DocumentoEstadoIndexModels
    {
        public DocumentoEstadoIndexModels()
        {
            lstmvcDocumentoEstado = new List<mvcDocumentoEstado>();
        }

        /// <summary>
        /// Listado del modelo mvcDocumentoEstado
        /// </summary>
        public List<mvcDocumentoEstado> lstmvcDocumentoEstado { get; set; }
        /// <summary>
        /// Listado de los tipos de documentos
        /// </summary>
        public SelectList lstDocumentos { get; set; }
        /// <summary>
        /// Listado de los tipos de estados para los documentos
        /// </summary>
        public SelectList lstEstados { get; set; }

    }
    public class DocumentoEstadoRegistroModels
    {
        public DocumentoEstadoRegistroModels()
        {
            mvcDocumentoEstado = new mvcDocumentoEstado();
            mvcDocumentoEstado.fechaEdita = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            mvcDocumentoEstado.indActivo = true;
        }

        /// <summary>
        /// Registro/Item de DocumentoEstado
        /// </summary>
        public mvcDocumentoEstado mvcDocumentoEstado { get; set; }
        /// <summary>
        /// Listado de los tipos de documentos
        /// </summary>
        public SelectList lstDocumentos { get; set; }
        /// <summary>
        /// Listado de los tipos de estados para los documentos
        /// </summary>
        public SelectList lstEstados { get; set; }

    }
    public class mvcDocumentoEstado
    {
        public mvcDocumentoEstado()
        {
            indActivo = true;
            fechaEdita = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            fechaEditas = string.Concat( DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToShortDateString()," ", DateTime.Now.ToShortTimeString());
            codRegEstadoColor = string.Empty;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int codDocumentoEstado { get; set; }

        [Required(ErrorMessage = "Seleccionar tipo de documento")]
        [StringLength(8, ErrorMessage = "Código de tipo de documento no es correcto")]
        [DataType(DataType.Text)]
        [Display(Name = "Tipo de documento")]
        public string codRegDocumento { get; set; }

        [Required(ErrorMessage = "Seleccionar tipo de estado")]
        [StringLength(8, ErrorMessage = "Código de tipo de estado no es correcto")]
        [DataType(DataType.Text)]
        [Display(Name = "Estado de documento")]
        public string codRegEstado { get; set; }

        public int codEstado { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Activo")]
        public bool indActivo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario edita")]
        public string usuarioEdita { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha edicion")]
        public Nullable<DateTime> fechaEdita { get; set; }

        public string fechaEditas { get; set; }

        public string codRegDocumentoDesc { get; set; }

        public string codRegEstadoDesc { get; set; }

        public string codRegEstadoColor { get; set; }

    }

    #endregion

}