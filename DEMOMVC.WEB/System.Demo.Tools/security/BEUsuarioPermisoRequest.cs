using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.security
{

    public class BEUsuarioPermisoRequest
    {
        public BEUsuarioPermisoRequest()
        {
            nomAction = string.Empty;
            tipoObjeto = string.Empty;
            desLogin = string.Empty;
            codSistema = string.Empty;
            token = string.Empty;
        }

        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codSistema { get; set; }

        [JsonIgnore]
        public string desLogin { get; set; }

        [JsonIgnore]
        public string token { get; set; }

        public string tipoObjeto { get; set; }

        public string nomAction { get; set; }


    }

}
