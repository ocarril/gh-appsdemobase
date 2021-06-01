namespace CROM.GC.Controllers.Services
{
    using CROM.GC.Models;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Demo.Tools.constans;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.security;
    using System.Demo.Tools.settings;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class ApiServiceSeguridad
    {


        public static BEUsuarioValido ValidarInicioSesion(LoginModel plogin)
        {
            BEUsuarioValido pUserValido = new BEUsuarioValido();

            try
            {
                var BELogueo = new
                {
                    Login = plogin.Usuario,
                    Contrasenia = plogin.Contrasenia,
                    KeySistema = GlobalSettings.GetDEFAULT_KEY_SYSTEM()
                };

                bool hasError = false;
                Uri uriURL = new Uri(string.Concat(GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad(), "api/security/getvalidateuser"));

                string responseBody = HelperWeb.ProcessRequest(uriURL.AbsoluteUri, WebConstants.METHOD_POST,
                                                          JsonConvert.SerializeObject(BELogueo),
                                                          WebConstants.CONTENT_TYPE_JSON, ref hasError);

                if (!hasError)
                {

                    pUserValido = JsonConvert.DeserializeObject<BEUsuarioValido>(responseBody);
                    pUserValido.ResultIndValido = true;
                }
                else
                {
                    ResponseHttpClient jsonResul = JsonConvert.DeserializeObject<ResponseHttpClient>(responseBody);
                    pUserValido.ResultIndValido = jsonResul.IsSuccess;
                    pUserValido.ResultIMessage = jsonResul.Message;
                    return pUserValido;
                }
                
            }
            catch (Exception ex)
            {
                var oReturnValor = HelpException.mTraerMensaje(ex, true, string.Concat("ValidarInicioSesion.", MethodBase.GetCurrentMethod().Name), plogin.Usuario);
                throw new Exception(oReturnValor.Message);
            }
            return pUserValido;
        }

        public static async Task<BEUsuarioValido> ValidarInicioSesionAsync(LoginModel plogin)
        {
            BEUsuarioValido pUserValido = new BEUsuarioValido();

            try
            {
                var BELogueo = new
                {
                    Login = plogin.Usuario,
                    Contrasenia = plogin.Contrasenia,
                    KeySistema = GlobalSettings.GetDEFAULT_KEY_SYSTEM()
                };

                using (var client = new HttpClient())
                {

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(BELogueo), Encoding.UTF8, "application/json");
                    Uri uriURL = new Uri(string.Concat(GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad(), "api/security/getvalidateuser"));
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = uriURL,
                        Content = content,
                    };

                    HttpResponseMessage result = await client.SendAsync(request);

                    var responseBody = await result.Content.ReadAsStringAsync();
                    ResponseHttpClient jsonResul = JsonConvert.DeserializeObject<ResponseHttpClient>(responseBody);

                    if (!result.IsSuccessStatusCode)
                    {

                        pUserValido.ResultIndValido = jsonResul.IsSuccess;
                        pUserValido.ResultIMessage = jsonResul.Message;
                        return pUserValido;
                    }

                    pUserValido = JsonConvert.DeserializeObject<BEUsuarioValido>(responseBody);
                    pUserValido.ResultIndValido = true;
                }
            }
            catch (Exception ex)
            {
                var oReturnValor = HelpException.mTraerMensaje(ex, true, string.Concat("ValidarInicioSesion.", MethodBase.GetCurrentMethod().Name), plogin.Usuario);
                throw new Exception(oReturnValor.Message);
            }
            return pUserValido;
        }

        public static  List<BEUsuarioPermisoResponse> ListUserObjectGrants(BEUsuarioPermisoRequest pDataPermiso)
        {
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();
            OperationResult resultClient = new OperationResult();
            try
            {

                bool hasError = false;
                Uri uriURL = new Uri(string.Concat(GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad(),
                                WebConstants.URI_SEGURIDAD_POST_LIST_USER_OBJECTS_GRANTS));

                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", pDataPermiso.token);
                string responseBody = HelperWeb.ProcessRequest(uriURL.AbsoluteUri,
                                                                         WebConstants.METHOD_POST,
                                                                         JsonConvert.SerializeObject(pDataPermiso),
                                                                         WebConstants.CONTENT_TYPE_JSON,headers,
                                                                         string.Empty, string.Empty,
                                                                         ref hasError);


                lstPermisos = JsonConvert.DeserializeObject<List<BEUsuarioPermisoResponse>>(responseBody);

            }
            catch (Exception ex)
            {
                var oReturnValor = HelpException.mTraerMensaje(ex, true, string.Concat("ListUserObjectGrants.", MethodBase.GetCurrentMethod().Name), pDataPermiso.desLogin);
            }

            
            return lstPermisos;
        }

        public static async Task<OperationResult> ListUserObjectGrantsAsync(BEUsuarioPermisoRequest pDataPermiso)
        {
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(pDataPermiso),
                                                    Encoding.UTF8,
                                                    WebConstants.CONTENT_TYPE_JSON);

            Uri uriURL = new Uri(string.Concat(GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad(),
                                 WebConstants.URI_SEGURIDAD_POST_LIST_USER_OBJECTS_GRANTS));

            OperationResult resultClient = await HelperWeb.ProcessHttpClientRequest(content,
                                                                                    WebConstants.METHOD_POST,
                                                                                    WebConstants.CONTENT_TYPE_JSON, 
                                                                                    uriURL);

            return resultClient;
        }
    }
}
