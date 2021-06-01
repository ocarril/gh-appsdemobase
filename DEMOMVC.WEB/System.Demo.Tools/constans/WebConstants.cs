using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.constans
{
    public static class WebConstants
    {
        public const string REQUEST_HEADER_AUTHORIZATION_SCHEME = "Bearer";

        public const string URI_SEGURIDAD_POST_VALIDATE_USER = "/api/security/getvalidateuser";
        public const string URI_SEGURIDAD_POST_LIST_USER_OBJECTS_GRANTS = "/api/security/listuserobjectsgrants";


        public const string METHOD_POST = "POST";
        public const string METHOD_GET = "GET";
        public const string METHOD_PUT = "PUT";
        public const string METHOD_DELETE = "DELETE";

        public const string CONTENT_TYPE_JSON = "application/json";

        public enum TipoOpcionPermiso
        {
            MENU = 1,
            CONTROL = 2,
            PAGINA = 3,
            ACTION = 4
        }

        public static Dictionary<int, string> ValidacionDatosSEGURIDAD = new Dictionary<int, string>()
        {
          { 2000,  "Ingreso al sistema satisfactoriamente."},
          { 2001,  "Datos no identificados." },
          { 2002,  "Ingresar login/cuenta de usuario." },
          { 2003,  "Ingresar contraseña de usuario." },
          { 2004,  "Cuenta de usuario y/o contraseña inválida." },
          { 2005,  "Datos no identificados." },
          { 2006,  "Usuario no esta asignado a una empresa." },
          { 2007,  "Usuario no esta asignado a un sistema." },
          { 2008,  "Usuario no esta asignado a un rol." },
          { 2009,  "Sistema no identificado." },
          { 2010,  "Sistema no identificado para la empresa." },
          { 2011,  "Licencia vencida para la empresa: {0} - Hasta : {1}" },
          { 2012,  "Usuario de sistema no tiene rol asignado." },
          { 2013,  "Esta intentando : [ {0} ] veces ingresar al sistema. Credenciales incorrectas." },
          { 2014,  "TOKEN no ha sido validado."},
          { 2015,  "Usuario identificado no pertenece a la empresa."},
          { 2016,  "No existe configurado empresa como cliente en la base de datos."},
          { 2017,  "El usuario no se encuentra registrado."},
          { 2018,  "Ingresar nueva contraseña de usuario." },
          { 2019,  "Ingresar confirmación de contraseña." },
          { 2020,  "Contraseña de confirmación es incorrecta." },
          { 2021,  "Se cambio la contraseña de usuario con exito." },
          { 2022,  "Se produjo un error al modificar el Password. consulte con el administrador." },
          { 2023,  "Se envió correo de cambio de contraseña con exito." },
          { 2024,  "Correo de solicitud no se envió con éxito." },
          { 2025,  "Cuenta de usuario se encuentra bloqueada desde [ {0} ]." },
          { 2026,  "Cuenta de usuario esta pendiente de cambio de contraseña." },
          { 2027,  "Contraseña de usuario es inválida." },

        };
    }
}
