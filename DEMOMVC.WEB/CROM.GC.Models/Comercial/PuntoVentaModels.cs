namespace CROM.GC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class mvcPuntoVenta
    {
        public string codPuntoVenta { get; set; }
        public int codEmpresa { get; set; }
        public string codEmpresaRUC { get; set; }
        public string codResponsable { get; set; }
        public string desNombre { get; set; }
        public string desPathFiles { get; set; }

        public string indActivo { get; set; }
        public string segUsuarioEdita { get; set; }
        public string segFechaEdita { get; set; }

        public int TOTALROWS { get; set; }
    }
}
