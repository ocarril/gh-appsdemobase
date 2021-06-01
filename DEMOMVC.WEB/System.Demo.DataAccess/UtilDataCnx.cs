using System;
using System.Collections.Generic;
using System.Demo.Tools.settings;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.DataAccess
{
    public static class UtilDataCnx
    {
        public static string ConexionBD()
        {
            string strCnxDB;
            try
            {
                strCnxDB = GlobalSettings.GetBDCadenaConexion("cnxDEMO_MVC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strCnxDB;
        }
    }
}
