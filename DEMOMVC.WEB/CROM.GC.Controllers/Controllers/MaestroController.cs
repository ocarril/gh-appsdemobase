namespace CROM.GC.Controllers
{
    using CROM.GC.Models;
    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Maestros;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.settings;
    using System.Linq;
    using System.Web.Mvc;

    public class MaestroController : BaseController
    {

        string strMensaje = string.Empty;

        #region INICIO: ActionResult de la entidad TABLAMAESTRA

        public ActionResult Tabla()
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();
                ViewBag.ValorTimeout = GlobalSettings.GetDEFAULT_ValorTimeout();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }       

        private List<mvcRegistro> PasarAModeloRegistro(List<BERegistroNew> lstRegistro)
        {
            List<mvcRegistro> lstmvcRegistro = new List<mvcRegistro>();
            foreach (BERegistroNew objRegistro in lstRegistro)
            {
                mvcRegistro objmvcRegistro = new mvcRegistro();

                objmvcRegistro.codRegistro = objRegistro.codRegistro;
                objmvcRegistro.codTabla = objRegistro.codTabla;
                objmvcRegistro.desNombre = objRegistro.desNombre;
                objmvcRegistro.gloDescripcion = objRegistro.gloDescripcion;
                objmvcRegistro.desValorCadena = objRegistro.desValorCadena;
                objmvcRegistro.desValorDecimal = objRegistro.desValorDecimal;
                objmvcRegistro.desValorEntero = objRegistro.desValorEntero;
                objmvcRegistro.desValorFecha = objRegistro.desValorFecha.HasValue ? objRegistro.desValorFecha.Value.ToShortDateString() : string.Empty;
                objmvcRegistro.desValorLogico = objRegistro.desValorLogico.HasValue ? (objRegistro.desValorLogico.Value ? "1" : "0") : "0";
                objmvcRegistro.numNivel = objRegistro.numNivel;
                objmvcRegistro.segFecModi = objRegistro.segFechaEdita.HasValue ? objRegistro.segFechaEdita.Value.ToString() : "";
                objmvcRegistro.segUsuModi = objRegistro.segUsuarioEdita;
                objmvcRegistro.indActivo = objRegistro.indActivo ? "1" : "0";

                objmvcRegistro.TOTALROWS = objRegistro.TOTALROWS;
                lstmvcRegistro.Add(objmvcRegistro);
            }
            return lstmvcRegistro;
        }
        private List<mvcTabla> PasarAModeloTabla(List<TablaBE> lstTabla)
        {
            List<mvcTabla> lstmvcTabla = new List<mvcTabla>();
            foreach (TablaBE objTabla in lstTabla)
            {
                mvcTabla objmvcTabla = new mvcTabla();

                objmvcTabla.codTabla = objTabla.codTabla;
                objmvcTabla.desNombre = objTabla.desNombre;
                objmvcTabla.gloDescripcion = objTabla.gloDescripcion;
                objmvcTabla.numLongitudNivel = objTabla.numLongitudNivel;
                objmvcTabla.indNivel = objTabla.indNivel ? "1" : "0";
                objmvcTabla.segFecModi = objTabla.segFechaEdita.HasValue ? objTabla.segFechaEdita.Value.ToString() : "";
                objmvcTabla.segUsuModi = objTabla.segUsuarioEdita;
                objmvcTabla.indActivo = objTabla.indActivo ? "1" : "0";

                objmvcTabla.TOTALROWS = objTabla.TOTALROWS;
                lstmvcTabla.Add(objmvcTabla);
            }
            return lstmvcTabla;
        }

        #endregion FINAL: ActionResult de la entidad TABLA MAESTRA

        #region INICIO: ActionResult de la entidad PERSONA

        public ActionResult Persona()
        {
            ViewBag.cboTipoPersona = LlenarLista(HelpTMaestras.TM.PersonaAsignaciones);
            ViewBag.cboAsignacion = LlenarLista(HelpTMaestras.TM.PersonaTipoAsignacion, null, 1);
            ViewBag.cboCategoria = LlenarLista(HelpTMaestras.TM.PersonaCategorias);
            ViewBag.cboArea = LlenarLista(HelpTMaestras.TM.PersonaAreasEmpresa);
            return View();
        }


        #region METODOS PRIVADOS

        #endregion

        #endregion FINAL: ActionResult de la entidad PERSONA
    }
}
