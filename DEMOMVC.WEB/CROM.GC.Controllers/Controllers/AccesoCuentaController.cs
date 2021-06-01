/************************************************************************
 Archivo    : AccesoCuentaController.cs
 Propósito  : Clase Controladora para el acceso al sistema
 Se asume   : N/A
 Efectos    : N/A
 Notas      : N/A
 Autor      : 
 Fecha/Hora de Creación :
 Fecha/Hora Modificado  : N/A
************************************************************************/
namespace CROM.GC.Controllers
{
    using CROM.GC.Controllers.HtmlMenuHelper;
    using CROM.GC.Controllers.Services;
    using CROM.GC.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Demo.Tools.constans;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.security;
    using System.Demo.Tools.settings;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    [Authorize]
    public class AccesoCuentaController : BaseController
    {
        private wcfSeguridad.AccessClient oIniciarSesion = null;

        public AccesoCuentaController()
        {

        }

        #region VISTAS - VIEWS

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                RedirectToAction("Login", "AccesoCuenta");
            }

            Dictionary<string, object>.ValueCollection data = ControllerContext.RouteData.Values.Values;
            ViewBag.nomFormulario = data.ElementAt(0).ToString() + "." + data.ElementAt(1).ToString();
            ViewBag.ReturnUrl = returnUrl;
           
            ViewBag.URLAPI_Seguridad = GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad();
            ViewBag.URLAPP_Comercial = GlobalSettings.GetDEFAULT_URL_WEBAPP_Comercial();

            return View();
        }


        public ActionResult UsuarioRegistro()
        {
            return View();
        }

        public ActionResult ContraseniaOlvido()
        {
            return View();
        }

        public ActionResult ContraseniaCambiar()
        {
            return View();
        }

        #endregion

        #region SERVICIOS DEL SISTEMA


        [HttpPost]
        public ActionResult ContraseniaCambiarGuardar(UsuarioModel objUser)
        {
            object jsonResponse = null;
            object DataDevol = null;
            string tipoDevol = null;
            try
            {
                oIniciarSesion = new wcfSeguridad.AccessClient();
                bool blnSucede = oIniciarSesion.UpdatePassword(objUser.desLogin, objUser.clvPasswordNue, true);
                if (blnSucede)
                {
                    tipoDevol = "C";
                    DataDevol = "La contraseña ha sido cambiada correctamente...";
                }
                else
                {
                    tipoDevol = "I";
                    DataDevol = "La contraseña NO ha sido cambiada...";
                }
                HelpLogging.Write(TraceLevel.Error, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                  String.Format(DataDevol + "Usuario: {0}, Fecha de Suceso: {1}", User.Identity.Name,
                                  DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString()));

            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult ContraseniaOlvidoGuardar()
        {
            object jsonResponse = null;
            object DataDevol = null;
            string tipoDevol = null;
            try
            {
                tipoDevol = "C";
                DataDevol = "Se ha enviado la contraseña su correo electronico...";
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult UsuarioGuardar(UsuarioModel usuario)
        {
            object jsonResponse = null;
            object DataDevol = null;
            string tipoDevol = null;
            try
            {
                oIniciarSesion = new wcfSeguridad.AccessClient();
                wcfSeguridad.UsuarioIngreso objUsuarioIngreso = new  wcfSeguridad.UsuarioIngreso();
                objUsuarioIngreso.codSistema="003";
                oIniciarSesion.InsertUsuarioIngreso(objUsuarioIngreso);
                tipoDevol = "C";
                DataDevol = "Los datos del usuario se guardaron correctamente...";
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult IniciarSesion(LoginModel plogin)
        {
            object jsonResponse = null;
            object DataDevol = null;
            string tipoDevol = null;
            string tokenUser = string.Empty;
            try
            {
                /* Aqui se realiza la validación del usuario conla aplicación de SEGURIDAD */
                BEUsuarioValido usuarioValidado =  ApiServiceSeguridad.ValidarInicioSesion(plogin);

                if (usuarioValidado.ResultIndValido)
                {
                    NameValueCollection RutaQuery = HttpUtility.ParseQueryString(HttpContext.Request.UrlReferrer.Query);

                    SetAuthCookieFromUsuario(usuarioValidado);

                    TempData.Clear();
                    TempData.Add("showToken", true);
                    TempData.Add("token", usuarioValidado.Token);

                    var menuJson = GetMenuJson(usuarioValidado);
                    HttpContext.Session.Add("mainMenu", menuJson);
                    TempData.Add("menu", menuJson);

                    FormsAuthentication.SetAuthCookie(usuarioValidado.desLogin, true);
                    SesionUsuario.objUsuario = usuarioValidado;

                    var menuJSONContext = HttpContext.Session["mainMenu"] as string;

                    SesionUsuario.MenuRoot = AccesoCuentaController.SetearMenus(false, menuJSONContext);

                    tipoDevol = "C";
                    DataDevol = GlobalSettings.GetDEFAULT_URL_WEBAPP_Comercial(); 
                    tokenUser = usuarioValidado.Token;
                    HelpLogging.Write(TraceLevel.Info, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                      String.Format("Usuario se autenticó correctamente : {0}, Fecha de Suceso: {1}", plogin.Usuario,
                                      DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString()),
                                      usuarioValidado.desLogin, usuarioValidado.codEmpresa.ToString());

                }
                else
                {
                    tipoDevol = "I";
                    DataDevol = usuarioValidado.ResultIMessage; 
                    HelpLogging.Write(TraceLevel.Warning, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                      String.Format(DataDevol + "- Usuario: {0}, Fecha de Suceso: {1}", plogin.Usuario,
                                      DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString()),
                                      plogin.Usuario, plogin.Contrasenia);
                }
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = plogin.rutaURL; ;
                HelpLogging.Write(TraceLevel.Error, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                  String.Format(DataDevol + "- Usuario: {0}, Fecha de Suceso: {1}, Error:{2}", 
                                                plogin.Usuario + " - " + plogin.rutaURL, DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString(), ex.Message),
                                                plogin.Usuario, "-");
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                    TokenUser = tokenUser
                };
            }
            return Json(jsonResponse);
        }


        #endregion

        public static string GetMenuJson(BEUsuarioValido pUserValid)
        {

            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();
            try
            {
                var dataPermiso = new BEUsuarioPermisoRequest
                {
                    codEmpresa = pUserValid.codEmpresa,
                    codSistema = pUserValid.codSistema,
                    desLogin = pUserValid.desLogin,
                    tipoObjeto = WebConstants.TipoOpcionPermiso.MENU.ToString().ToUpper(),
                    token = pUserValid.Token
                };

                lstPermisos = ApiServiceSeguridad.ListUserObjectGrants(dataPermiso);

                return JsonConvert.SerializeObject(lstPermisos);
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("AccountController.", MethodBase.GetCurrentMethod().Name), ex,
                                  pUserValid.desLogin, pUserValid.codEmpresa.ToString());
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }
        }
        
        private void SetAuthCookieFromUsuario(BEUsuarioValido usuarioValidado)
        {
            var now = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            var ticket = new FormsAuthenticationTicket(
                1,
                usuarioValidado.desLogin,
                now,
                now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                false,
                JsonConvert.SerializeObject(usuarioValidado));

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Domain = FormsAuthentication.CookieDomain,
            };

            HttpContext.Response.SetCookie(cookie);
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            HelpLogging.Write(TraceLevel.Error, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                              String.Format("Se esta cerrando la sesiòn del systema - Usuario: {0}, Fecha de Suceso: {1}", 
                                            User.Identity.Name + " - ", DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString()), 
                                            User.Identity.Name, "ID");
            return RedirectToAction("Login", "AccesoCuenta");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            SesionUsuario.objUsuario = null;
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "AccesoCuenta");
        }

        [HttpPost]
        public JsonResult CheckLogonUser()
        {
            object jsonResponse = null;
            object DataDevol = null;
            string pageValue = null;
            string tipoDevol = null;
            string UserName = null;
            string FullName = null;
            string UserIsAutenticated = null;
            try
            {
                pageValue = "AccesoCuenta/Login";
                tipoDevol = "C";
                UserName = ""; 
                HelpLogging.Write(TraceLevel.Info, String.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                  String.Format("Se valido el evento CheckLogonUser - Usuario: {0}, Fecha de Suceso: {1}", User.Identity.Name, 
                                  DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString()));
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Page = pageValue,
                    Data = DataDevol,
                    UserName = UserName,
                    FullName = FullName,
                    UserIsAutenticated = UserIsAutenticated
                };
            }
            return Json(jsonResponse);
        }


        #region Helpers
        

        private const string XsrfKey = "XsrfId";


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                
            }
        }

        public static List<BEUsuarioPermisoResponse> SetearMenu(bool padre, int pcodEmpresa, string pcodSistema, string pdesLogin, string pToken)
        {
            List<BEUsuarioPermisoResponse> menuArbol = new List<BEUsuarioPermisoResponse>();
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();
            try
            {
                var dataPermiso = new BEUsuarioPermisoRequest
                {
                    codEmpresa = pcodEmpresa,
                    codSistema = pcodSistema,
                    desLogin = pdesLogin,
                    tipoObjeto = WebConstants.TipoOpcionPermiso.MENU.ToString().ToUpper(),
                    token = pToken
                };

                lstPermisos = ApiServiceSeguridad.ListUserObjectGrants(dataPermiso);


                if (lstPermisos.Count > 0)
                {
                    
                    foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre == null)))
                    {
                        AsignarMenu(menuArbol, menu);
                    }

                    if (!padre)
                    {
                        foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre != null)))
                        {
                            AsignarMenu(menuArbol, menu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("AccountController.", MethodBase.GetCurrentMethod().Name), ex);
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }
            return menuArbol;
        }

        public static List<BEUsuarioPermisoResponse> SetearMenus(bool padre, string menuJson)
        {
            List<BEUsuarioPermisoResponse> menuArbol = new List<BEUsuarioPermisoResponse>();
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();
            try
            {

                lstPermisos = JsonConvert.DeserializeObject<List<BEUsuarioPermisoResponse>>(menuJson); 


                if (lstPermisos.Count > 0)
                {
                    foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre == null)))
                    {
                        AsignarMenu(menuArbol, menu);
                    }
                    //seteamos los hijos
                    if (!padre)
                    {
                        foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre != null)))
                        {
                            AsignarMenu(menuArbol, menu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("AccountController.", MethodBase.GetCurrentMethod().Name), ex);
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }
            return menuArbol;
        }

        public static async Task<List<BEUsuarioPermisoResponse>> SetearMenuAsync(bool padre, int codEmpresa, string pcodSistema, 
                                                                     string pdesLogin, string pcodRol)
        {
            List<BEUsuarioPermisoResponse> menuArbol = new List<BEUsuarioPermisoResponse>();
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();
            try
            {
                var dataPermiso = new BEUsuarioPermisoRequest
                {
                    codSistema = pcodSistema,
                    desLogin = pdesLogin,
                    tipoObjeto = WebConstants.TipoOpcionPermiso.MENU.ToString().ToUpper()
                };

                OperationResult operationResult = await ApiServiceSeguridad.ListUserObjectGrantsAsync(dataPermiso);

                if (operationResult.isValid)
                {
                    lstPermisos = JsonConvert.DeserializeObject<List<BEUsuarioPermisoResponse>>(operationResult.data);
                    foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre == "")))
                    {
                        AsignarMenu(menuArbol, menu);
                    }
                    //seteamos los hijos
                    if (!padre)
                    {
                        foreach (BEUsuarioPermisoResponse menu in lstPermisos.Where(x => (x.codOpcionPadre != "")))
                        {
                            AsignarMenu(menuArbol, menu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("AccountController.", MethodBase.GetCurrentMethod().Name), ex);
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }
            return menuArbol;
        }

        // Arma el arbol de menus del usuario.
        private static bool AsignarMenu(List<BEUsuarioPermisoResponse> menuLista, BEUsuarioPermisoResponse objeto)
        {
            if (menuLista == null)
                return false;

            if (objeto.codOpcionPadre == null)
            {
                menuLista.Add(objeto);
                return true;
            }

            bool agregado = false;
            foreach (var m in menuLista)
            {
                if (m.codOpcion == objeto.codOpcionPadre)
                {
                    if (m.lstSubMenus == null)
                        m.lstSubMenus = new List<BEUsuarioPermisoResponse>();
                    m.lstSubMenus.Add(objeto);
                    agregado = true;
                    break;
                }
            }

            if (!agregado)
            {
                foreach (var m in menuLista)
                {
                    agregado = AsignarMenu(m.lstSubMenus, objeto);
                    if (agregado)
                        break;
                }
            }

            return agregado;
        }

        private static OpcionModels PasarMenuAModelo(BEUsuarioPermisoResponse pObjeto)
        {
            OpcionModels opcion = new OpcionModels
            {
                codOpcion = pObjeto.codOpcion,
                codOpcionPadre = pObjeto.codOpcionPadre,
                desEnlaceURL = pObjeto.desEnlaceURL,
                desNombre = pObjeto.codOpcionNombre,
                nomController = pObjeto.desEnlaceURL,
                gloDescripcion = pObjeto.codOpcionPadreNombre
            };
            return opcion;
        }

        #endregion

    }
}
