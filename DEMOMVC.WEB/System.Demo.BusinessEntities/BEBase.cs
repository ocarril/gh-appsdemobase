namespace System.Demo.BusinessEntities
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Entidad que sera heredada en todas las entidades
    /// </summary>
    public class BEBase
    {
        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        public string segUsuarioCrea { get; set; }

        public string segUsuarioEdita { get; set; }

        public string segUsuarioElimina { get; set; }

        public DateTime segFechaCrea { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }

        public Nullable<DateTime> segFechaElimina { get; set; }

        public string segMaquinaCrea { get; set; }

        public string segMaquinaEdita { get; set; }

        public string segMaquinaElimina { get; set; }

        public long ROW { get; set; }

        public int TOTALROWS { get; set; }
    }

    public class BEBaseEntidad
    {
        public BEBaseEntidad()
        {
            segUsuarioCrea = string.Empty;
            segUsuarioEdita = string.Empty;
            segUsuarioElimina = string.Empty;
            segMaquinaCrea = string.Empty;
            segMaquinaEdita = string.Empty;
            segMaquinaElimina = string.Empty;
        }

        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        public string segUsuarioCrea { get; set; }

        public string segUsuarioEdita { get; set; }

        public string segUsuarioElimina { get; set; }


        public DateTime segFechaCrea { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }

        public Nullable<DateTime> segFechaElimina { get; set; }

        public string segMaquinaCrea { get; set; }

        public string segMaquinaEdita { get; set; }

        public string segMaquinaElimina { get; set; }
        
        public bool indActivo { get; set; }

    }

    public class BEBaseMaestro
    {
        public BEBaseMaestro()
        {
            SegUsuarioCrea = string.Empty;
            SegUsuarioEdita = string.Empty;
            SegMaquinaOrigen = string.Empty;
            SegFechaHoraCrea = DateTime.Now;
            SegFechaHoraCrea = DateTime.Now;
        }

        public int codEmpresa { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public Nullable<DateTime> SegFechaHoraEdita { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public string SegMaquinaOrigen { get; set; }
        public bool SegEliminado { get; set; }
    }

    public class BEBaseEntidadItem
    {
        
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        public bool indActivo { get; set; }

        public string segUsuarioEdita { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }

        public string segMaquinaEdita { get; set; }

    }


    public class BEBasePagedResponse
    {
        public BEBasePagedResponse()
        {
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public bool Estado { get; set; }

        public bool indActivo { get; set; }

        public string segUsuarioEdita { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }
        
        public string segMaquinaEdita { get; set; }
        
        public long ROWNUM { get; set; }

        public int TOTALROWS { get; set; }
    }

    public class BEBaseEntidadRequest
    {
        public BEBaseEntidadRequest()
        {
            segUsuarioCrea = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaCrea = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        [JsonIgnore]
        public string segUsuarioCrea { get; set; }

        [JsonIgnore]
        public string segUsuarioEdita { get; set; }

        [JsonIgnore]
        public DateTime segFechaCrea { get; set; }

        [JsonIgnore]
        public Nullable<DateTime> segFechaEdita { get; set; }

        [JsonIgnore]
        public string segMaquinaCrea { get; set; }

        [JsonIgnore]
        public string segMaquinaEdita { get; set; }

    }

    public class BEBuscadorBase
    {
        public BEBuscadorBase()
        {
            segUsuarioActual = string.Empty;
            segIPMaquinaPC = string.Empty;
        }


        [JsonProperty("codEmpresa")]
        public int codEmpresa { get; set; }


        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        [JsonIgnore]
        public string segUsuarioActual { get; set; }


        [JsonIgnore]
        public string segIPMaquinaPC { get; set; }
    }


    public class EntidadId
    {
        public EntidadId()
        {
            Name = string.Empty;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [ConfiguracionSistema.cs]
    /// </summary>
    public class ConfiguracionSistema
    {
        //  Valores del Acceso a segurdad 
        public bool DEFAULT_EncryptaCONFIG { get; set; }/*SE QUEDA EN EL CONFIG*/
        public bool DEFAULT_ServicioWEB { get; set; }/*SE QUEDA EN EL CONFIG*/

        /// <summary>
        /// EXTDLL = DLL HelpSeguridad en  Assembly
        /// </summary>
        public string DEFAULT_Encriptacion { get; set; }/*SE QUEDA EN EL CONFIG*/
        
        //  Valores del SISTEMA
        public string DEFAULT_SistemaInicio { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string DEFAULT_NameSystem { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string DEFAULT_Idioma { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string DEFAULT_TipoException { get; set; }/*SE QUEDA EN EL CONFIG*/
        public bool DEFAULT_AutenticacionWindow { get; set; } /*SE QUEDA EN EL CONFIG*/
        public bool DEFAULT_VerificaTablasInici { get; set; }/*SE QUEDA EN EL CONFIG*/
        public bool DEFAULT_ConfiguraMonedaInicio { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string DEFAULT_NombreEventLog { get; set; }/*SE QUEDA EN EL CONFIG*/

        //  Valores para envio de CORREO ELECTRONICOS
        public string EMAIL_Host { get; set; }  /*SE QUEDA EN EL CONFIG*/
        //public string EMAIL_DeEnvio { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string EMAIL_CredencialUser { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string EMAIL_CredencialPass { get; set; }/*SE QUEDA EN EL CONFIG*/
        public int EMAIL_SmtpPort { get; set; }/*SE QUEDA EN EL CONFIG*/
        public bool EMAIL_enabledSSL { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string EMAIL_Asunto { get; set; }/*SE QUEDA EN EL CONFIG*/

        // Valores de Configuraciójn Regional
        public string DEFAULT_DatePattern{ get; set; }
        public string DEFAULT_ShortTimePattern{ get; set; }
        public string DEFAULT_LongTimePattern{ get; set; }

        public bool DEFAULT_GuardaConfig { get; set; }

        //  Valores para envio de CADENA DE CONEXION
        public string CNX_System_ServerDB { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_System_DataBase { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_System_UserDBas { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_System_Password { get; set; }/*SE QUEDA EN EL CONFIG*/

        public string CNX_Security_ServerDB { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_Security_DataBase { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_Security_UserDBas { get; set; }/*SE QUEDA EN EL CONFIG*/
        public string CNX_Security_Password { get; set; }/*SE QUEDA EN EL CONFIG*/

    }

}

