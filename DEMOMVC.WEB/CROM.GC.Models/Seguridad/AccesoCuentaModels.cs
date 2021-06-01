namespace CROM.GC.Models
{



    using Newtonsoft.Json;

    #region Models



    public class LoginModel
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool OlvidoContrasenia { get; set; }
        public int indOlvContrasenia { get; set; }
        public string rutaURL { get; set; }
    }

    public class UsuarioModel
    {
        public string desLogin { get; set; }
        public string desNombre { get; set; }
        public string desApellidos { get; set; }
        public string desCorreo { get; set; }
        public string codEmpleado { get; set; }
        public string clvPassword { get; set; }
        public string desPregunta { get; set; }
        public string desRespuesta { get; set; }
        public string desTelefono { get; set; }

        public string clvPasswordNue { get; set; }
    }


    public class BEUsuarioValido
    {
        public BEUsuarioValido()
        {
            
        }


        [JsonProperty("codUsuario")]
        public string codUsuario { get; set; }


        [JsonProperty("desCorreo")]
        public string desCorreo { get; set; }


        [JsonProperty("codEmpresa")]
        public int codEmpresa { get; set; }


        [JsonProperty("codEmpresaNombre")]
        public string codEmpresaNombre { get; set; }


        [JsonProperty("codEmpleado")]
        public string codEmpleado { get; set; }


        [JsonProperty("desLogin")]
        public string desLogin { get; set; }


        [JsonProperty("codSistema")]
        public string codSistema { get; set; }


        [JsonProperty("codSistemaNombre")]
        public string codSistemaNombre { get; set; }


        [JsonProperty("codRol")]
        public string codRol { get; set; }


        [JsonProperty("codRolNombre")]
        public string codRolNombre { get; set; }


        [JsonProperty("desNombreUsuario")]
        public string desNombreUsuario { get; set; }


        [JsonProperty("desApellido")]
        public string desApellido { get; set; }


        [JsonProperty("desNombre")]
        public string desNombre { get; set; }


        [JsonProperty("token")]
        public string Token { get; set; }


        [JsonProperty("desTelefono")]
        public string desTelefono { get; set; }


        [JsonProperty("indVendedor")]
        public bool indVendedor { get; set; }



        [JsonProperty("indCambioPrecio")]
        public bool indCambioPrecio { get; set; }


        [JsonProperty("indAccesoGerencial")]
        public bool indAccesoGerencial { get; set; }


        [JsonProperty("indCambiaDescuento")]
        public bool indCambiaDescuento { get; set; }



        [JsonProperty("indCambiaCodPersona")]
        public bool indCambiaCodPersona { get; set; }



        [JsonProperty("indJefeCaja")]
        public bool indJefeCaja { get; set; }



        [JsonProperty("indUsuarioSistema")]
        public bool indUsuarioSistema { get; set; }


        [JsonProperty("numRUC")]
        public string numRUC { get; set; }


        [JsonIgnore]
        public bool ResultIndValido { get; set; }

        [JsonIgnore]
        public string ResultIMessage { get; set; }
    }

    
    #endregion

}
