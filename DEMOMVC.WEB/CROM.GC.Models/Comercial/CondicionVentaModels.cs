namespace CROM.GC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class mvcCondicionVenta
    {
        public int codCondicion { get; set; }
        public string desNombre { get; set; }

        public int numCuotas { get; set; }
        public int numDiasVCtaCte { get; set; }
        public int numDiasCVcto { get; set; }
        public int numDecimalRedondeo { get; set; }
        public string indEsGravaCtaCte { get; set; }
        public string indEsPredeterminado { get; set; }
        public string indEsContraEntrega { get; set; }
        public string indEsEnCuotas { get; set; }
        public string indEsVenta { get; set; }

        public string indActivo { get; set; }
        public string segUsuarioEdita { get; set; }
        public string segFechaEdita { get; set; }

        public int TOTALROWS { get; set; }
    }
}
