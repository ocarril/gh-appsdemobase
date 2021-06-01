using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.security
{
    public class BEUsuarioPermisoResponse
    {

        public BEUsuarioPermisoResponse()
        {
            codOpcionNombre = string.Empty;
            codOpcionPadreNombre = string.Empty;
            lstSubMenus = new List<BEUsuarioPermisoResponse>();
        }

        
        [JsonProperty("codOpcion")]
        public string codOpcion { get; set; }

        
        [JsonProperty("codOpcionPadre")]
        public string codOpcionPadre { get; set; }

        
        [JsonProperty("codOpcionNombre")]
        public string codOpcionNombre { get; set; }

        
        [JsonProperty("codOpcionDescripcion")]
        public string codOpcionDescripcion { get; set; }

        
        [JsonProperty("codOpcionPadreNombre")]
        public string codOpcionPadreNombre { get; set; }

        
        [JsonProperty("desEnlaceURL")]
        public string desEnlaceURL { get; set; }

        
        [JsonProperty("desEnlaceWIN")]
        public string desEnlaceWIN { get; set; }


        
        [JsonProperty("desEnlacePadre")]
        public string desEnlacePadre { get; set; }


        
        [JsonProperty("indVer")]
        public bool indVer { get; set; }
        
        [JsonProperty("indNuevo")]
        public bool indNuevo { get; set; }
        
        [JsonProperty("indEditar")]
        public bool indEditar { get; set; }
        
        [JsonProperty("indEliminar")]
        public bool indEliminar { get; set; }
        
        [JsonProperty("indImprime")]
        public bool indImprime { get; set; }
        
        [JsonProperty("indImporta")]
        public bool indImporta { get; set; }
        
        [JsonProperty("indExporta")]
        public bool indExporta { get; set; }
        
        [JsonProperty("indOtro")]
        public bool indOtro { get; set; }


        
        [JsonProperty("nomIcono")]
        public string nomIcono { get; set; }



        
        [JsonProperty("codSistema")]
        public string codSistema { get; set; }


        [JsonProperty("indTipoObjeto")]
        public string indTipoObjeto { get; set; }

        
        [JsonProperty("numOrden")]
        public int numOrden { get; set; }

        [JsonProperty("numOrdenPadre")]
        public int numOrdenPadre { get; set; }

        
        [JsonProperty("codElementoID")]
        public string codElementoID { get; set; }


        [JsonProperty("lstSubMenus")]
        public List<BEUsuarioPermisoResponse> lstSubMenus { get; set; }

    }
}
