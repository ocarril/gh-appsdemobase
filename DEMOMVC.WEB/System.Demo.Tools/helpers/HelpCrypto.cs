using System;
using System.Collections.Generic;
using System.Demo.Tools.constans;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Demo.Tools.helpers
{
    public static class HelpCrypto
    {


        public static string GetAccessToken(HttpRequestMessage request, bool indConPrefijo)
        {
            string accessToken = string.Empty;
            if (!request.Headers.Contains("Authorization")) return accessToken;
            var TOKEN = request.Headers.GetValues("Authorization");
            if (TOKEN != null)
            {

                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? strToken.Substring(WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1,
                                                   strToken.Length - (WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1)) :
                                  strToken);

                }
            }
            return accessToken;
        }

        public static string GetAccessToken(HttpRequestBase request, bool indConPrefijo)
        {

            string accessToken = string.Empty;
            if (request.Headers.GetValues("Authorization") == null)
                return accessToken;

            var TOKEN = request.Headers.GetValues("Authorization");
            if (TOKEN != null)
            {

                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? strToken.Substring(WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1,
                                                   strToken.Length - (WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1)) :
                                  strToken);

                }
            }
            return accessToken;
        }

    }
}
