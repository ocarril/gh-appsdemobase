namespace CROM.GC.Controllers.HtmlMenuHelper
{
    using CROM.GC.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Demo.Tools.security;
    using System.Web;


    public static class SesionUsuario
    {

        public static BEUsuarioValido objUsuario
        {
            get
            {
                return Obtener<BEUsuarioValido>("entrada");
            }
            set { Asignar("entrada", value); }
        }

        public static List<BEUsuarioPermisoResponse> MenuRoot 
        {
            get { return Obtener<List<BEUsuarioPermisoResponse>>("MenuRoot"); }
            set { Asignar("MenuRoot", value); }
        }

        public static String UrlSite
        {
            get { return ConfigurationManager.AppSettings["urlSite"].ToString(); }
        }

        #region "Metodos"


        private static void Asignar(string key, object value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T Obtener<T>(string key)
        {
            var x = new HttpContextWrapper(HttpContext.Current);
            var y = x.Session[key];

            return (T)HttpContext.Current.Session[key];
        }

        #endregion

    }
}