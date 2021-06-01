using System;
using System.Collections.Generic;
using System.Demo.Tools.settings;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.config
{
    public static class ConfigCROM
    {
        #region /* Proceso de SELECT BY ID CODE */
        public static string cnxNombre { get; set; }
        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>Entidad</returns>
        public static string AppConfig(int codEmpresa, ConfigTool pcodKeyConfig)
        {
            ConfigValor configuracion = new ConfigValor();
            try
            {
                string conexion = GlobalSettings.GetBDCadenaConexion("cnxDEMO_MVC");
                using (_DBML_ConfigdataDataContext SQLDC = new _DBML_ConfigdataDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_Configuracion(codEmpresa, null, pcodKeyConfig.ToString(), null, null);
                    foreach (var item in resul)
                    {
                        configuracion = new ConfigValor()
                        {
                            desValor = item.desValor,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                configuracion.desValor = string.IsNullOrEmpty(configuracion.desValor) ? string.Empty : configuracion.desValor;
            }
            return configuracion.desValor;
        }

        public static List<ConfigValor> ListAppConfig(int codEmpresa)
        {
            List<ConfigValor> lstConfigValor = new List<ConfigValor>();
            ConfigValor configuracion = new ConfigValor();
            try
            {
                string conexion = GlobalSettings.GetBDCadenaConexion("cnxDEMO_MVC");
                using (_DBML_ConfigdataDataContext SQLDC = new _DBML_ConfigdataDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_Configuracion(codEmpresa, null, string.Empty, null, true);
                    foreach (var item in resul)
                    {

                        lstConfigValor.Add(new ConfigValor()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            desValor = item.desValor,
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstConfigValor;
        }




        #endregion

    }
}
