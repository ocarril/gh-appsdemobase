using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.entities
{
    public class ReturnValor
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Respuesta"/> is exitosa.
        /// </summary>
        /// <value><c>true</c> if exitosa; otherwise, <c>false</c>.</value>
        public bool Exitosa { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the el codigo de retorno.
        /// </summary>
        public string CodigoRetorno { get; set; }

        /// <summary>
        /// Gets or sets the el codigo de retorno Int.
        /// </summary>
        public int codRetorno { get; set; }

        /// <summary>
        /// Gets or sets the el Codigo de error.
        /// </summary>
        public string ErrorCode { get; set; }
    }

    public class ResponseHttpClient
    {
        public ResponseHttpClient()
        {
            IsSuccess = false;
            Message = string.Empty;
            ResponseData = null;
        }

        public ResponseHttpClient(bool status, string message, object data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ResponseData { get; set; }
    }
}
