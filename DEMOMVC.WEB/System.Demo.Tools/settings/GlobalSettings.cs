namespace System.Demo.Tools.settings
{
    using System.Configuration;


    public static class GlobalSettings
    {

        public static string GetDEFAULT_TipoException()
        {
            return ConfigurationManager.AppSettings["Default_TipoException"].ToString();
        }


        public static string GetDEFAULT_ValorTimeout()
        {

            string valorConfig = Convert.ToString(ConfigurationManager.AppSettings["DEFAULT_ValorTimeout"]);

            return valorConfig;
        }


        public static int GetDEFAULT_HorasFechaActualCloud()
        {

            int valorConfig = Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_HorasFechaActualCloud"]);

            return valorConfig;
        }


        public static string GetDEFAULT_URL_WS_API_Seguridad()
        {

            string valorConfig = Convert.ToString(ConfigurationManager.AppSettings["DEFAULT_URL_WS_API_Seguridad"]);

            return valorConfig;
        }


        public static string GetDEFAULT_URL_WEBAPP_Comercial()
        {

            string valorConfig = Convert.ToString(ConfigurationManager.AppSettings["DEFAULT_URL_WEBAPP_Comercial"]);

            return valorConfig;
        }


        public static string GetBDCadenaConexion(string cnxName)
        {
            return ConfigurationManager.ConnectionStrings[cnxName].ConnectionString;

        }

        public static string GetDEFAULT_SistemaInicio()
        {
            return Convert.ToString(ConfigurationManager.AppSettings["DEFAULT_SistemaInicio"].ToString());
        }

        public static string GetDEFAULT_LinkTipoCambio()
        {
            return ConfigurationManager.AppSettings["DEFAULT_LinkTipoCambio"].ToString();
        }

        public static string GetDEFAULT_KEY_SYSTEM()
        {
            return ConfigurationManager.AppSettings["DEFAULT_KEY_SYSTEM"].ToString();

        }

    }
}
