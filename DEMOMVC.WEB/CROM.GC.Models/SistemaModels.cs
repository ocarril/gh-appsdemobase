using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROM.GC.Models
{
    /// <summary>
    /// Proyecto    : Modulo de Importaciones : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Modelo 
    /// Archivo     : [MenuModels.cs]
    /// </summary>
    public class MenuModels
    {
        public MenuModels()
        {
            SubMenu = new List<MenuModels>();
        }

        public string Texto { get; set; }
        public string Controller { get; set; }
        public string Accion { get; set; }
        public bool Seleccionado { get; set; }

        public List<MenuModels> SubMenu { get; set; }

    }

    public class VersionModels
    {
        public string strNombre { get; set; }
        public string strVersion { get; set; }
        public string strFecha { get; set; }
    }

    public class SistemaModels
    {
        public string strLogotipo { get; set; }
        public string strTitulo { get; set; }
    }
}