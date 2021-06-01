using System.Web;
using System.Web.Optimization;

namespace CROM.GC.web.application
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            System.Web.Optimization.BundleTable.EnableOptimizations = false;

            #region STYLES/JAVA SCRIPT - LOGIN

            bundles.Add(new StyleBundle("~/styles/stlogin").Include(
                               "~/Content/css/jquery-ui-1.10.4.custom.css",
                               "~/Content/login.css",
                               "~/Scripts/toastr/toastr.min.css",
                               "~/Scripts/JS/MessageBox/MessageBox.css"
                               ));

            bundles.Add(new ScriptBundle("~/scripts/jslogin").Include(
                                "~/Scripts/js/jquery-1.10.2.js",
                                "~/Scripts/js/jquery-ui-1.10.4.custom.js",
                                "~/Scripts/js/jquery.blockUI.js",
                                "~/Scripts/js/jquery.cookie.js",
                                "~/Scripts/js/Helper/AjaxHelper.js",
                                "~/Scripts/js/Helper/General.js",
                                "~/Scripts/js/Helper/CROMUtil.js",
                                "~/Scripts/js/MensajeCarga/MensajeCarga.js",
                                "~/Scripts/js/MessageBox/MessageBox.js",
                                "~/Scripts/js/Helper/json2.js"
                               ));

            bundles.Add(new ScriptBundle("~/scripts/jsloginpage").Include(
                                "~/Scripts/Views/AccesoCuenta/Login.js"
                               ));
            #endregion

            #region STYLES/JAVA SCRIPT - ROOT/MAIN

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/JS/jquery-1.10.2.min.js",
                     "~/Scripts/JS/jquery-ui-1.10.4.custom.js",
                     "~/Scripts/JS/jquery.blockUI.js",
                     "~/Scripts/JS/jquery.cookie.js",
                     "~/Scripts/JS/jquery-ui-timepicker-addon.js",
                     "~/Scripts/JS/jquery.ui.datepicker-es.js",
                     "~/Scripts/JS/Jqgrid/jquery.jqGrid.js",
                     "~/Scripts/JS/Jqgrid/grid.locale-es.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryref").Include(

                     "~/Scripts/JS/Jqfile/jquery.fileupload.js",
                     "~/Scripts/JS/Jqfile/jquery.iframe-transport.js",
                     "~/Scripts/JS/Jqfile/jquery.fileupload-process.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/helpers").Include(
                     "~/Scripts/JS/Helper/AjaxHelper.js",
                     "~/Scripts/JS/Helper/General.js",
                     "~/Scripts/JS/Helper/CROMUtil.js",                     
                     "~/Scripts/JS/MensajeCarga/MensajeCarga.js",
                     "~/Scripts/JS/MessageBox/MessageBox.js",
                     "~/Scripts/JS/Helper/ModalHelper.js",
                     "~/Scripts/JS/Helper/UploadHelper.js",
                     "~/Scripts/JS/Helper/DateTimeHelper.js",
                     "~/Scripts/toastr/toastr.min.js",
                     "~/Scripts/knockout-3.4.0.js",
                     "~/Content/js/util.js",
                     "~/Content/js/app.js",
                     "~/Scripts/JS/Helper/json2.js",
                     "~/Scripts/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/varios").Include(
                    "~/Scripts/JS/Otros/moment-with-locales.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/jquery-ui-1.10.4.custom.css",
                      "~/Content/css/ui.jqgrid.css",
                      "~/Scripts/toastr/toastr.min.css",
                      "~/Scripts/JS/MessageBox/MessageBox.css"
            ));

            #endregion

            #region JAVA/SCRIPT - TIPO DE CAMBIO

            bundles.Add(new ScriptBundle("~/bundles/tipocambio").Include(
                   "~/Scripts/Views/Comercial/TipoCambio.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/tipocambioreg").Include(
                   "~/Scripts/Views/Comercial/TipoCambioReg.js"
            ));

            #endregion

            #region JAVA/SCRIPT - CONFIGURACION

            bundles.Add(new ScriptBundle("~/bndlS/config").Include(
                   "~/Scripts/Views/Configuracion/puntoventa.js"
            ));

            bundles.Add(new ScriptBundle("~/bndlS/configreg").Include(
                   "~/Scripts/Views/Configuracion/indexreg.js"
            ));

            #endregion


        }
    }
}