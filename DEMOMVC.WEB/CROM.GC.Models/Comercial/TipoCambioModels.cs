namespace CROM.GC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class mvcTipoCambio
    {
        public int codTipoCambio { get; set; }
        public string fecProceso { get; set; }
        public string codRegMoneda { get; set; }
        public decimal monCompraGOB { get; set; }
        public decimal monVentaGOB { get; set; }
        public decimal monCompraPRL { get; set; }
        public decimal monVentaPRL { get; set; }

        public string Estado { get; set; }
        public string UsuModi { get; set; }
        public string FeModi { get; set; }

        public int TOTALROWS { get; set; }
    }
}
