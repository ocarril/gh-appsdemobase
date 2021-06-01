using System;
using System.Collections.Generic;
using System.Demo.BusinessEntities.Maestros;
using System.Demo.DataAccess.maestros;
using System.Demo.Tools.entities;
using System.Demo.Tools.helpers;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.BusinessLogic.maestros
{
    public class MaestroLogic
    {
        private TablaData oTablaData = null;
        private RegistroData oTablaRegistroData = null;
        private ReturnValor oReturn = null;

        public MaestroLogic()
        {
            oTablaData = new TablaData();
            oTablaRegistroData = new RegistroData();
            oReturn = new ReturnValor();
        }

        public enum EstadoDetalle : int
        {
            Deshabilitado = 0,
            Habilitado = 1,
            PorValidar = 2,
            Todos = 3,
            Habilitado_PorValidar = 4
        }

        public List<BERegistro> ListarComboDetalle(string pCodTabla, string pCodArgu, int pNivel, EstadoDetalle pEstado,
                                           int pcodEmpresa, string pSegUsuario)
        {
            List<BERegistro> lista = null;
            try
            {
                lista = this.oTablaRegistroData.ListarCombo(Convert.ToInt32(pEstado) < 3 ? "=" : ">", pCodTabla, pCodArgu, pNivel, Convert.ToInt32(pEstado) < 3 ? Convert.ToInt32(pEstado) : Convert.ToInt32(pEstado) - 3);
                if (lista.Count == 0)
                {
                    lista.Add(new BERegistro() { CodigoTabla = "", CodigoArgumento = "", DescripcionCorta = "", DescripcionLarga = "" });
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

    }

    public class TablaLogicNx
    {

        public List<BERegistroNew> ListarRegistroCombo(BaseFiltroMaestro objFiltroMaestro)
        {
            RegistroData objRegistroDataNx = null;
            List<BERegistroNew> lstRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroData();
                lstRegistro = objRegistroDataNx.ListarCombo(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objRegistroDataNx != null)
                {
                    objRegistroDataNx.Dispose();
                    objRegistroDataNx = null;
                }
            }
            return lstRegistro;
        }


        public TablaBE BuscarTabla(string codTabla, int pcodEmpresa, string pSegUsuario)
        {
            TablaData objTablaDataNx = null;
            TablaBE objTabla = null;
            try
            {
                objTablaDataNx = new TablaData();
                objTabla = objTablaDataNx.Buscar(codTabla);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objTablaDataNx != null)
                {
                    objTablaDataNx.Dispose();
                    objTablaDataNx = null;
                }
            }
            return objTabla;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
