using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CROM.GC.Models
{
    public class MenuSystemModels
    {
        public MenuSystemModels()
        {
            SubMenu = new List<MenuSystemModels>();
        }

        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool Selected { get; set; }

        public List<MenuSystemModels> SubMenu { get; set; }

    }

    public class OpcionModels
    {
        public OpcionModels()
        {
            lstSubMenus = new List<OpcionModels>();
        }

        public string codOpcion { get; set; }
        public string codOpcionPadre { get; set; }
        public int codSistema { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public string desEnlaceURL { get; set; }
        public string nomController { get; set; }
        public bool indMenu { get; set; }
        public int numOrden { get; set; }

        public string codOpcionPadreNombre { get; set; }
        public List<OpcionModels> lstSubMenus { get; set; }
    }

}