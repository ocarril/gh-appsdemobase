using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Demo.Tools.constans;
using System.Demo.Tools.entities;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace System.Demo.Tools.helpers
{
    public static class HelperWeb
    {

        public static string GetClientIpAddressHttpContext(this System.Web.HttpRequestBase context)
        {

            string ipAddress = context.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.ServerVariables["REMOTE_ADDR"];
        }

        public static string ProcessRequest(string url, string method, string postData, string contentType,
                                            ref bool hasErrors)
        {
            hasErrors = false;
            byte[] byteData = (!string.IsNullOrWhiteSpace(postData) ? Encoding.UTF8.GetBytes(postData) : null);

            return ProcessRequest(url, method, byteData, contentType, null, null, null, ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, byte[] byteData, string contentType,
                                            ref bool hasErrors)
        {
            hasErrors = false;

            return ProcessRequest(url, method, byteData, contentType, null, null, null, ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, string postData, string contentType,
                                            Dictionary<string, string> requestHeaders,
                                            string credentialUserName,
                                            string credentialPassword,
                                            ref bool hasErrors)
        {
            hasErrors = false;
            byte[] byteData = (!string.IsNullOrWhiteSpace(postData) ? Encoding.UTF8.GetBytes(postData) : null);

            return ProcessRequest(url, method, byteData, contentType, requestHeaders, credentialUserName,
                credentialPassword, ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, byte[] byteData, string contentType,
                                            Dictionary<string, string> requestHeaders,
                                            string credentialUserName,
                                            string credentialPassword,
                                            ref bool hasErrors)
        {
            hasErrors = false;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.Timeout = System.Threading.Timeout.Infinite;
            myHttpWebRequest.Method = method;

            if (!string.IsNullOrWhiteSpace(credentialUserName) && !string.IsNullOrWhiteSpace(credentialPassword))
            {
                myHttpWebRequest.Credentials = new NetworkCredential(credentialUserName, credentialPassword);
            }
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                myHttpWebRequest.ContentType = contentType;
            }
            if (requestHeaders != null)
            {
                foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
                {
                    myHttpWebRequest.Headers.Add(requestHeader.Key, requestHeader.Value);
                }
            }
            if ((method.ToLower() == WebConstants.METHOD_POST.ToLower() ||
                method.ToLower() == WebConstants.METHOD_PUT.ToLower()) &&
                byteData != null)
            {

                myHttpWebRequest.ContentLength = byteData.Length;

                using (Stream requestStream = myHttpWebRequest.GetRequestStream())
                {
                    requestStream.Write(byteData, 0, byteData.Length);
                }
            }

            try
            {
                using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                {
                    using (Stream responseStream = myHttpWebResponse.GetResponseStream())
                    {
                        if (responseStream == null)
                        {
                            return null;
                        }
                        using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            return myStreamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {

                HttpWebResponse resp = ex.Response as HttpWebResponse;
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                string respStr = reader.ReadToEnd();
                reader.Close();
                if (string.IsNullOrEmpty(respStr))
                    respStr = ex.Message;

                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return respStr;
            }
            catch (OutOfMemoryException ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return null;
            }
            catch (IOException ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<OperationResult> ProcessHttpClientRequest(object pContent, string pMetodo, string pMediaType, Uri pURLWS)
        {
            OperationResult rptaResponse = new OperationResult();
            try
            {
                using (var client = new HttpClient())
                {

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(pContent),
                                                            Encoding.UTF8,
                                                            pMediaType);
                    var metodo = HttpMethod.Get;
                    switch (pMetodo.ToUpper())
                    {
                        case WebConstants.METHOD_POST:
                            metodo = HttpMethod.Post;
                            break;
                        case WebConstants.METHOD_PUT:
                            metodo = HttpMethod.Put;
                            break;
                        case WebConstants.METHOD_DELETE:
                            metodo = HttpMethod.Delete;
                            break;
                    }

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = metodo,
                        RequestUri = pURLWS,
                        Content = content,
                    };

                    HttpResponseMessage result = await client.SendAsync(request);
                    var responseBody = await result.Content.ReadAsStringAsync();

                    rptaResponse.isValid = result.IsSuccessStatusCode;
                    rptaResponse.data = responseBody;

                    if (!result.IsSuccessStatusCode)
                    {
                        ResponseHttpClient jsonResul = JsonConvert.DeserializeObject<ResponseHttpClient>(responseBody);
                        rptaResponse.brokenRulesCollection.Add(new BrokenRule
                        {
                            description = jsonResul.Message,
                            severity = RuleSeverity.Error,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("ProcessHttpClientRequest.", MethodBase.GetCurrentMethod().Name), ex);
                rptaResponse.brokenRulesCollection.Add(new BrokenRule
                {
                    description = ex.Message,
                    severity = RuleSeverity.Error,

                });
            }
            return rptaResponse;
        }
    }
}
