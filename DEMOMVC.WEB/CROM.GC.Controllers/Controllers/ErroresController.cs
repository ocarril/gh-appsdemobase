namespace CROM.GC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Demo.Tools.helpers;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;


    [Authorize]
    public class ErroresController : Controller
    {

        public ActionResult Errores(string dataMensa)
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();
                ViewBag.desMensaje = dataMensa;
                ViewBag.Message = !string.IsNullOrEmpty(dataMensa) ? "Página o ruta no encontrada..." : "Consulte con el administrador del sistema..";
                ViewBag.Title = dataMensa;
                HelpLogging.TraceError(string.Concat( this.GetType().Name , "." , MethodBase.GetCurrentMethod().Name),
                                      dataMensa,"user");

            }
            catch (Exception ex)
            {
                HelpLogging.TraceError(string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name), ex, "User");
            }
            return View();
        }

        public ActionResult Index(string aspxerrorpath)
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();
                ViewBag.desMensaje = aspxerrorpath;
                ViewBag.Message = !string.IsNullOrEmpty(aspxerrorpath) ? "Página o ruta no encontrada..." : "Consulte con el administrador del sistema..";
                ViewBag.Title = aspxerrorpath;
                HelpLogging.TraceError(string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                      aspxerrorpath, "user");

            }
            catch (Exception ex)
            {
                HelpLogging.TraceError(string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name), ex, "User");
            }
            return View();
        }

        public ActionResult Index(int error = 0)
        {

            Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
            ViewBag.nomController = data.ElementAt(0).ToString();
            ViewBag.nomAction = data.ElementAt(1).ToString();
            ViewBag.Message = "Consulte con el administrador del sistema..";

            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.desMensaje = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.desMensaje = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.desMensaje = "Algo salio muy mal :( ..";
                    break;
            }

            return View("~/views/errores/_ErrorPage.cshtml");

        }
    }
}