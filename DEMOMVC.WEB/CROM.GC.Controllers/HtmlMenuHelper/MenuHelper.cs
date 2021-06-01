namespace CROM.GC.Controllers.HtmlMenuHelper
{
    using CROM.GC.Controllers.HtmlMenuHelper.Base;
    using CROM.GC.Models;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.security;
    using System.Demo.Tools.settings;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public static class MenuHelper
    {
        public static bool IsValidMenu(this HtmlHelper helper)
        {
            var menuJson = HttpContext.Current.Session["mainMenu"] as string;
            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) 
                    return false;

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var usuario = JsonConvert.DeserializeObject<dynamic>(ticket.UserData);
                if (usuario != null)
                {
                    var token = usuario.Token.ToString();
                    menuJson = AccesoCuentaController.GetMenuJson(token);
                    HttpContext.Current.Session["mainMenu"] = menuJson;
                }
            }

            return !string.IsNullOrWhiteSpace(menuJson) && !menuJson.Contains("errorDescription");
        }

        public static string GetMenuHtml(this HtmlHelper helper, string HelperType)
        {
            MenuViewModel<MvcMenuItem> model = null;
            HtmlBuilder builder = new HtmlBuilder(helper);
            model = Menu.CreateModel(HelperType);
            builder.BuildTreeStruct(model);
            return builder.Build();
        }

        public static IEnumerable<BEUsuarioPermisoResponse> GetMenu(this HtmlHelper helper)
        {
            var menuJson = HttpContext.Current.Session["mainMenu"] as string;

            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                    return null;

                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var usuario = JsonConvert.DeserializeObject<dynamic>(ticket.UserData);
                var token = usuario.Token.ToString();
                HttpContext.Current.Session["mainMenu"] = menuJson;
            }
            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpContext.Current.Response.RedirectLocation = "http://google.com.pe";
            }
            var menus = JsonConvert.DeserializeObject<IEnumerable<BEUsuarioPermisoResponse>>(menuJson);

            return menus;
        }


        public class Menu
        {
            public static MenuViewModel<MvcMenuItem> CreateModel(string HelperType)
            {
                MenuViewModel<MvcMenuItem> mod = new MenuViewModel<MvcMenuItem>();
                try
                {

                    if (SesionUsuario.objUsuario == null)
                    {
                        return mod;
                    }

                    List<BEUsuarioPermisoResponse> listaMenus = null;
                    BEUsuarioValido objUsuario = SesionUsuario.objUsuario;
                    string pcodSistema = GlobalSettings.GetDEFAULT_SistemaInicio();
                    
                    var menuJSONContext = SesionUsuario.MenuRoot
                                               .Where(MX => MX.codOpcionNombre == HelperType)
                                               .FirstOrDefault();

                    listaMenus = menuJSONContext.lstSubMenus;

                    if (listaMenus.Count > 0)
                    {
                        
                        List<BEUsuarioPermisoResponse> listaMenuPadre = listaMenus; 

                        MvcMenuItem itemRoot = new MvcMenuItem() { MnuTyp = MenuType.Top };
                        itemRoot.Text = menuJSONContext.codOpcionNombre;

                        List<BEUsuarioPermisoResponse> listaHijos = listaMenus;

                        foreach (BEUsuarioPermisoResponse hijo in listaHijos)
                        {

                            if (hijo.desEnlaceURL.IndexOf('*') > -1)
                            {
                                MvcMenuItem menuHijo = new MvcMenuItem()
                                {
                                    Text = hijo.codOpcionNombre,
                                    MnuTyp = MenuType.submenu
                                };
                                menuHijo.Controller = hijo.desEnlaceURL.Split('*')[1];
                                menuHijo.Action = hijo.desEnlaceURL.Split('*')[0];
                                menuHijo.IconImage = hijo.nomIcono;

                                List<BEUsuarioPermisoResponse> listaNietos = (from lstn in listaMenus
                                                                              where lstn.codOpcionPadre == hijo.codOpcion
                                                                              select lstn).ToList<BEUsuarioPermisoResponse>();

                                itemRoot.MenuChildren.Add(menuHijo);

                                foreach (BEUsuarioPermisoResponse nieto in listaNietos)
                                {
                                    MvcMenuItem menuNieto = menuHijo.AddItem(nieto.codOpcionNombre);
                                    menuNieto.MnuTyp = MenuType.submenu;
                                    menuNieto.Controller = nieto.desEnlaceURL.Split('*')[1];
                                    menuNieto.Action = nieto.desEnlaceURL.Split('*')[0];
                                    menuNieto.IconImage = nieto.nomIcono;
                                }
                            }
                        }
                        mod.MenuItems.Add(itemRoot);
                     
                    }
                }
                catch (Exception ex)
                {
                    HelpLogging.Write(TraceLevel.Error, string.Concat("MenuHelper.", MethodBase.GetCurrentMethod().Name), ex, HelperType);

                }
                return mod;
            }

        }

        public static MvcHtmlString SetTokenSessionStorage(this HtmlHelper helper)
        {

            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\"> ");
            sb.AppendLine(" var tokenKey = 'geoToken'; var tokenValue =''; var menuKey = 'menuKey'");
            var showToken = helper.ViewContext.Controller.TempData["showToken"];
            if (showToken != null && (bool)showToken)
            {
                var token = helper.ViewContext.Controller.TempData["token"];
                var menu = helper.ViewContext.Controller.TempData["menu"];
                sb.AppendLine("tokenValue = '" + token + "'");
                sb.AppendLine("sessionStorage.setItem(tokenKey, tokenValue ); ");
                sb.AppendLine("menuValue = '" + menu + "'");
                sb.AppendLine("sessionStorage.setItem(menuKey, menuValue ); ");
            }

            sb.Append("</script>");

            return MvcHtmlString.Create(sb.ToString());

        }

        public static void RedirectToLoginSIS(this HtmlHelper helper)
        {

            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var url = urlHelper.Action("Index", "Account");

            var HttpEquiv = "Refresh";

            var Content = "2,url=" + FormsAuthentication.LoginUrl;
            HttpContext.Current.Response.Headers.Add(HttpEquiv, Content);

        }
    }
}