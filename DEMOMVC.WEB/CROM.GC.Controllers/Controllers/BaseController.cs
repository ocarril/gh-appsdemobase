namespace CROM.GC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data.Entity.Infrastructure;
    using System.Demo.BusinessEntities.Comercial;
    using System.Demo.BusinessEntities.Maestros;
    using System.Demo.BusinessLogic.comercial;
    using System.Demo.BusinessLogic.maestros;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.security;
    using System.Linq;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;

    [HandleError(ExceptionType = typeof(DbUpdateException), View = "Errores/Errores")]
    public abstract class BaseController : Controller, IAuthorizationFilter
    {
        protected AccessTokenUtil _tokenValidation;
        protected string MessageValidation;

        protected static string keyDato;

        protected void ValidateToken(HttpRequestBase Request)
        {
            string accessToken = HelpCrypto.GetAccessToken(Request, false);
            _tokenValidation = new AccessTokenUtil(accessToken);
        }

        protected HttpStatusCodeResult ValidateTokenResult(HttpRequestBase Request)
        {
            string accessToken = HelpCrypto.GetAccessToken(Request, false);
            _tokenValidation = new AccessTokenUtil(accessToken);
            if (!_tokenValidation.isValid())
            {
 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, _tokenValidation.MessageValidation);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Continue, _tokenValidation.MessageValidation);
        }

        public AuthenticationHeaderValue ReturnHeader(string pMessage)
        {

            return AuthenticationHeaderValue.Parse(string.IsNullOrEmpty(pMessage) ? "TOKEN no es valido o ha expirado." : pMessage);
        }

        public object RetornarTokenInvalido(string message)
        {
            object jsonResponse;
            jsonResponse = new
            {
                Type = "E",
                Data = message,
            };
            return jsonResponse;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var httpContext = filterContext.HttpContext;
            if (httpContext.Items.Count > 0)
            {

                NameValueCollection headers = httpContext.Request.Headers;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                var vUrl = httpContext.Request.CurrentExecutionFilePath;
                var vRequestVerificationToken = httpContext.Request.Headers["__RequestVerificationToken"];
                var vX_CSRF_TOKEN = httpContext.Request.Headers["Authorization"];

                keyDato = vX_CSRF_TOKEN;

                string accessToken = HelpCrypto.GetAccessToken(Request, false);
                _tokenValidation = new AccessTokenUtil(accessToken);

            

                if (httpContext.Request.HttpMethod.ToLower() == "post")
                {

                }
                else if (httpContext.Request.HttpMethod.ToLower() == "get")
                {
                    Dictionary<string, object>.ValueCollection data = filterContext.RouteData.Values.Values;
                    string strNomtroller = data.ElementAt(0).ToString();
                    string strNomAction = strNomtroller + "/" + data.ElementAt(1).ToString();


                    if (strNomAction.IndexOf("AccesoCuenta/Login") == -1)
                    {
                        
                    }
                }
            }
        }


        private ConfiguracionLogic cnf = null;
        private TablaLogicNx objTablaLogicNx = null;
        private BaseFiltroMaestro objFiltroMaestro = null;
       

        protected object ListarDocumentoEstado(string codDocumento, string codEstado)
        {
            DocumentoEstadoLogic documentoEstadoLogic = new DocumentoEstadoLogic();
            IEnumerable<BEDocumentoEstado> lstDocumentoEstado;
            lstDocumentoEstado = documentoEstadoLogic.List(new BaseFiltro { codRegDocumento = codDocumento, codRegEstado = codEstado });
            object lstParaCombos = from item in lstDocumentoEstado
                                   select new
                                   {
                                       value = item.codDocumentoEstado,
                                       text = item.auxcodRegEstado
                                   };
            return lstParaCombos;
        }

        protected object LlenarTabla(TablaBE objTabla, string codTabla = null, int nivel = 1, string codRegTabla = null)
        {
            objTablaLogicNx = new TablaLogicNx();
            objFiltroMaestro = new BaseFiltroMaestro();
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            if (nivel == 0)
                nivel = 1;
            /* Obtener - la longitud por nivel */
            int cntLongitud = 5 + ((objTabla.numLongitudNivel * nivel) - objTabla.numLongitudNivel);
            objFiltroMaestro.codTabla = objTabla.codTabla;
            objFiltroMaestro.codReg = codRegTabla.Substring(0, cntLongitud);
            objFiltroMaestro.numNivel = nivel;
            objFiltroMaestro.indActivo = true;

            lstRegistro = objTablaLogicNx.ListarRegistroCombo(objFiltroMaestro);
            object lstParaCombos = from item in lstRegistro
                                   select new { value = item.codRegistro, text = item.desNombre };
            return lstParaCombos;
        }

        protected object LlenarListaJQ(HelpTMaestras.TM tabla, string codTabla = null, int numNivel = 1)
        {
            objTablaLogicNx = new TablaLogicNx();
            objFiltroMaestro = new BaseFiltroMaestro();
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            objFiltroMaestro.codTabla = !string.IsNullOrEmpty(codTabla) ? codTabla.Substring(0, 5) : HelpTMaestras.CodigoTabla(tabla);
            objFiltroMaestro.codRegistro = !string.IsNullOrEmpty(codTabla) ? codTabla : string.Empty;
            objFiltroMaestro.codReg = !string.IsNullOrEmpty(codTabla) ? codTabla : string.Empty;
            objFiltroMaestro.numNivel = numNivel;
            objFiltroMaestro.indActivo = true;

            lstRegistro = objTablaLogicNx.ListarRegistroCombo(objFiltroMaestro).OrderBy(reg=>reg.desNombre).ToList();
            object lstParaCombos = from item in lstRegistro
                                   select new
                                   {
                                       value = item.codRegistro,
                                       text = item.desNombre
                                   };
            return lstParaCombos;
        }


        protected SelectList ListarDocumentoEstados(string codDocumento, string codEstado, bool todos = true)
        {
            DocumentoEstadoLogic documentoEstadoLogic = new DocumentoEstadoLogic();
            List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
            lstDocumentoEstado = documentoEstadoLogic.List(new BaseFiltro { codRegDocumento = codDocumento, codRegEstado = codEstado });
            lstDocumentoEstado.Insert(0, (todos == true ? new BEDocumentoEstado { auxcodRegEstado = "-- Todos --" } :
                                                          new BEDocumentoEstado { auxcodRegEstado = "-- Seleccionar --" }));

            SelectList lstParaCombos = new SelectList(lstDocumentoEstado, "codDocumentoEstado", "auxcodRegEstado");
            return lstParaCombos;
        }

       
        protected SelectList LlenarLista(HelpTMaestras.TM tabla, string codTabla = null, int numNivel = 1, int todos = 1)
        {
            MaestroLogic maestroLogic = new MaestroLogic();
            List<BERegistro> lstGenerica = new List<BERegistro>();
            if (!string.IsNullOrEmpty(codTabla))
                lstGenerica = maestroLogic.ListarComboDetalle(codTabla, string.Empty, numNivel, MaestroLogic.EstadoDetalle.Habilitado,
                                                              _tokenValidation.codEmpresa, _tokenValidation.desLogin);
            else
                lstGenerica = maestroLogic.ListarComboDetalle(HelpTMaestras.CodigoTabla(tabla), string.Empty, numNivel, 
                                                              MaestroLogic.EstadoDetalle.Habilitado,
                                                              0, "APPWEB");
            if (todos == 1)
                lstGenerica.Insert(0, new BERegistro { DescripcionCorta = "-- Todos --" });
            if (todos == 2)
                lstGenerica.Insert(0, new BERegistro { DescripcionCorta = "-- Seleccionar --" });

            SelectList lstParaCombos = new SelectList(lstGenerica, "CodigoArgumento", "DescripcionCorta");
            return lstParaCombos;
        }


        #region Método para subir archivos

        #endregion

        #region Métodos relacionados con SEGURIDAD S.I.S.

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            string str1 = context.Request.ServerVariables["REMOTE_USER"];
            string str2 = context.Request.ServerVariables["AUTH_USER"];
            string str3 = context.Request.ServerVariables["REMOTE_HOST"];
            return str3; 
        }

        #endregion
    }
}