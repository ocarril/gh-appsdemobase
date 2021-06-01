namespace System.Demo.Tools.security
{
    using System;
    using System.Demo.Tools.constans;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;


    public static class StringExtensions
    {

        public static string CipherMd5(this string str)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            int i;

            for (i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static DateTime StringToDate(this string str)
        {
            var fecha = new DateTime();
            if (DateTime.TryParse(str, new CultureInfo("es-PE"), DateTimeStyles.None, out fecha))
            {
                return fecha;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static string OfuscateUrl(this string paramUrlt)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(paramUrlt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey,
                    new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    paramUrlt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return paramUrlt;
        }

        public static string DeOfuscateUrl(this string paramUrl)
        {
            string returnValue = string.Empty;
            try
            {
                string encryptionKey = "MAKV2SPBNI99212";
                paramUrl = paramUrl.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(paramUrl);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey,
                        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (
                            CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            //cs.Close();
                        }
                        returnValue = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                returnValue = string.Empty;
            }
            return returnValue;
        }

        public static string GetAccessToken(HttpRequestMessage request, bool indConPrefijo)
        {
            string accessToken = string.Empty;
            if (!request.Headers.Contains("Authorization")) return accessToken;
            var TOKEN = request.Headers.GetValues("Authorization");
            //var TOKEN = request.Headers.GetValues("Authorization");
            //if (request.Headers.Count != 0)
            if (TOKEN != null)
            {
                //if (!string.IsNullOrWhiteSpace(request.Headers.Authorization.Scheme) &&
                //    request.Headers.Authorization.Scheme.ToLower() == WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower() &&
                //    !string.IsNullOrWhiteSpace(request.Headers.Authorization.Parameter))
                //{
                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower() + " " : "") +
                                  strToken;
                    //  request.Headers.Authorization.Parameter;
                    //}
                }
            }
            return accessToken;
        }
    }
}
