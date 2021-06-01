namespace CROM.GC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Demo.Tools.settings;
    using System.Linq;
    using System.Web.Mvc;


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenido al sistema de gestión comercial: Módulo de MVC.!";

            ViewBag.fecEmision = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).AddDays(0 * (-1)).Date.ToShortDateString();
            return View();
        }

        public ActionResult DashBoard()
        {
            Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
            ViewBag.nomController = data.ElementAt(0).ToString();
            ViewBag.nomAction = data.ElementAt(1).ToString();

            ViewBag.fecInicio = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).AddDays(0 * (-1)).Date.ToShortDateString();

            ViewBag.fecFinal = DateTime.Now.ToShortDateString();
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
    }
}
