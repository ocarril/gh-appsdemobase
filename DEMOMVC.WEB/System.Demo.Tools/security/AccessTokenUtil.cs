using System;
using System.Collections.Generic;
using System.Demo.Tools.constans;
using System.Demo.Tools.helpers;
using System.Demo.Tools.settings;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Demo.Tools.security
{

    public class AccessTokenUtil
    {
        //private const string CONTEXTO_APK = "APK";

        public AccessTokenUtil(string accessToken)
        {
            Token = accessToken;
            //Init();
        }

        private void Init()
        {
            Token = string.Empty;
            codUsuario = string.Empty;
            codEmpresa = 0;
            codSistema = string.Empty;
            IsValid = false;
            IdSesion = 0;
            codSistema = string.Empty;
            numRUC = string.Empty;
        }

        public string CleanToken
        {
            get
            {
                return string.IsNullOrWhiteSpace(Token) ? string.Empty : HttpUtility.UrlDecode(Token).DeOfuscateUrl();
            }
        }

        public string Token { get; set; }

        /// <summary>
        /// Obtiene o establece el ID de Usuario
        /// </summary>
        public string codUsuario { get; set; }

        public string codEmpleado { get; set; }

        public string desLogin { get; set; }

        public string desCorreo { get; set; }

        public string desNombreUsuario { get; set; }


        /// <summary>
        /// Obtiene o establece el ID de la empresa
        /// </summary>
        public int codEmpresa { get; set; }

        public string codEmpresaNombre { get; set; }

        public string numRUC { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del Sistema
        /// </summary>
        public string codSistema { get; set; }

        public string codSistemaNombre { get; set; }

        public string codRol { get; set; }

        public string codRolNombre { get; set; }

        /// <summary>
        /// Obtiene o establece la Fecha en el cual Fue generado el Token
        /// </summary>
        public DateTime FechaHoraToken { get; set; }

        public string MessageValidation { get; set; }

        /// <summary>
        /// Obtiene o establece la valides de los Parametros del Token
        /// </summary>
        public bool IsValid { get; set; }


        private bool isValidTokenParams()
        {
            bool isValid = false;

            string cleanToken = CleanToken;

            if (!string.IsNullOrWhiteSpace(cleanToken))
            {
                string[] partes = cleanToken.Split('|');
                int id = -1;

                /*
                * Verificamos que el Array tenga al menos 4 partes:
                * Parte 00: COD Usuario
                * Parte 01: COD Empleado
                * Parte 02: LOGIN del usuario
                * Parte 03: CORREO del usuario
                * Parte 04: NOMBRE del usuario
                * Parte 05: COD Empresa
                * Parte 06: NOMBRE Empresa
                * Parte 07: N° RUC DE LA EMPRESA
                * Parte 08: COD Sistema
                * Parte 19: Nombre de Sistema
                * Parte 10: COD de Rol
                * Parte 11: NOMBRE de Rol
                * Parte 12: Fecha Hora donde termina la vigencia del Token
                * 
                * Parte 13: Id de Licencia
                */

                try
                {


                    //4 elementos es la cantidad minima que debe tener el Token
                    if (partes.Length >= 4)
                    {
                        /*Validamos que el ID de Usuario sea un Numero Valido*/
                        if (!string.IsNullOrEmpty(partes[0]))
                        {
                            codUsuario = partes[0];
                        }

                        /*Validamos que el ID de Empresa sea un Numero Valido*/
                        if (int.TryParse(partes[5], out id))
                        {
                            codEmpresa = id;
                        }

                        /*Validamos que el ID de Sistema sea un Numero Valido*/
                        if (!string.IsNullOrEmpty(partes[7]))
                        {
                            numRUC = partes[7];
                        }

                        /*Validamos que el ID de Sistema sea un Numero Valido*/
                        if (!string.IsNullOrEmpty(partes[8]))
                        {
                            codSistema = partes[8];
                        }

                        /*Validamos que el ID de Sistema sea un Numero Valido*/
                        if (!string.IsNullOrEmpty(partes[10]))
                        {
                            codRol = partes[10];
                        }

                        /*Validamos que el ID de Sistema sea un Numero Valido*/
                        if (!string.IsNullOrEmpty(partes[11]))
                        {
                            codRol = partes[10];
                        }

                        /*Validacion de la Fecha*/
                        DateTime currentDate = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
                        //Convertimos la fecha a Unix Time Milisecond
                        ulong currentUnixDate = HelpTime.DateTimeToUnixTimestamp(currentDate);

                        //convertimos la fecha hora de generado el token a DateTime
                        ulong fechaToken = 0, fechaTokenValue = 0;
                        if (ulong.TryParse(partes[12], out fechaToken))
                        {
                            //La fecha indicada en el Token es la fecha y hora hasta donde es valido el Token
                            FechaHoraToken = HelpTime.UnixTimeStampToDateTime(fechaToken);

                            //DateTime dateTokenValue = FechaHoraToken.AddHours(1);
                            fechaTokenValue = HelpTime.DateTimeToUnixTimestamp(FechaHoraToken);

                            //validamos el Token con la Fecha Hora Generada
                            if (currentUnixDate <= fechaTokenValue)
                            {
                                isValid = true;
                            }
                            else
                                MessageValidation = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2014).Value;
                        }

                        /*Tomar el Contexto*/
                        if (partes.Length >= 5)
                        {
                            if (partes[1] != null)
                            {
                                codEmpleado = partes[1];
                            }

                            if (partes[2] != null)
                            {
                                desLogin = partes[2];
                            }

                            if (partes[3] != null)
                            {
                                desCorreo = partes[3];
                            }

                            if (partes[4] != null)
                            {
                                desNombreUsuario = partes[4];
                            }

                            if (partes[6] != null)
                            {
                                codEmpresaNombre = partes[6];
                            }

                            if (partes[7] != null)
                            {
                                numRUC = partes[7];
                            }

                            if (partes[8] != null)
                            {
                                codSistemaNombre = partes[8];
                            }

                            if (partes[11] != null)
                            {
                                codRolNombre = partes[11];
                            }

                            //Validar el contexto
                            if (!string.IsNullOrEmpty(codRolNombre) &&
                                !string.IsNullOrEmpty(codEmpresaNombre) &&
                                !string.IsNullOrEmpty(numRUC) &&
                                !string.IsNullOrEmpty(codSistemaNombre) &&
                                !string.IsNullOrEmpty(desLogin) &&
                                !string.IsNullOrEmpty(desNombreUsuario) &&
                                !string.IsNullOrEmpty(desCorreo) &&
                                codEmpleado != "EXT" && isValid)
                            {

                                //Si el contexto DE LOS DATOS DEL TOKEN no son vacios
                                isValid = true;

                            }
                            else if (!string.IsNullOrEmpty(codRolNombre) &&
                                     !string.IsNullOrEmpty(codSistemaNombre) &&
                                     !string.IsNullOrEmpty(desLogin) &&
                                     !string.IsNullOrEmpty(desNombreUsuario) &&
                                     !string.IsNullOrEmpty(desCorreo) &&
                                     codEmpleado == "EXT" && isValid)
                            {

                                //Si el contexto DE LOS DATOS DEL TOKEN no son vacios
                                isValid = true;

                            }



                            //if (partes[6] != null)
                            //{
                            //    TipoLicencia = partes[6];
                            //}


                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageValidation = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2014).Value;
                }

            }
            else
                MessageValidation = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2014).Value;


            return isValid;
        }


        public bool isValid()
        {
            bool isValid = isValidTokenParams();

            if (!isValid)
                return isValid;
            if (codEmpleado != "EXT")
                return (codUsuario.Length > 0 && codEmpresa > 0 && codSistema.Length > 0) && isValid;

            return (codUsuario.Length > 0 && codSistema.Length > 0) && isValid;
        }



        /// <summary>
        /// Obtiene o establece el Contexto
        /// </summary>
        public string Contexto { get; set; }

        /// <summary>
        /// Obtiene o establece el Tipo de Licencia
        /// </summary>
        public string TipoLicencia { get; set; }
        /// <summary>
        /// Obtiene o establece el Id de Sesion (Para uso propio de cada Modulo)
        /// </summary>
        public int IdSesion { get; set; }



    }


}
