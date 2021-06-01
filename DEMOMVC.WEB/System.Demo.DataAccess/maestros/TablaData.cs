using System;
using System.Collections.Generic;
using System.Demo.BusinessEntities.Maestros;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.DataAccess.maestros
{
    public class TablaData
    {
        private string conexion = string.Empty;
        public TablaData()
        {
            conexion = UtilDataCnx.ConexionBD();
        }

        public TablaBE Buscar(string codTabla)
        {
            TablaBE objTabla = null;
            try
            {
                using (_DBMLDataMaestrosDataContext tablasMaestrosDC = new _DBMLDataMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.demo_mvc_S_Tabla(codTabla, string.Empty, null);
                    foreach (var item in query)
                    {
                        objTabla = new TablaBE()
                        {
                            codTabla = item.codTabla,
                            indNivel = item.indNivel,
                            numLongitudNivel = item.numLongitudNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTabla;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
