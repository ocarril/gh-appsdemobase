namespace System.Demo.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestros Detalle
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Entidad de negocio
    /// Archivo     : TablaMaestraRegistro.cs
    /// </summary>
    public class BERegistro
    {
        public string CodigoTabla { get; set; }
        public string CodigoArgumento { get; set; }
        public int NivelDetalle { get; set; }
        public string DescripcionLarga { get; set; }
        public string DescripcionCorta { get; set; }
        public decimal ValorDecimal { get; set; }
        public string ValorCadena { get; set; }
        public bool ValorBoolean { get; set; }
        public int ValorEntero { get; set; }
        public Nullable<DateTime> ValorFecha { get; set; }
        public bool Estado { get; set; }
        public int Dependencia { get; set; }
        public string AgregaQuitaDependencia { get; set; }
        public string Idioma { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }
        public Nullable<DateTime> SegFechaHoraCrea { get; set; }
        public Nullable<DateTime> SegFechaHoraEdita { get; set; }

        public long ROW { get; set; }
        public int TOTALROWS { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestros Detalle
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Entidad de negocio
    /// Archivo     : Registro.cs
    /// </summary>
    public class BERegistroNew : BEBase
    {
        public BERegistroNew()
        {
            objTabla = new TablaBE();
        }

        public string codRegistro { get; set; }
        public string codTabla { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public int numNivel { get; set; }
        public int numLongitudNivel { get; set; }
        public decimal? desValorDecimal { get; set; }
        public string desValorCadena { get; set; }
        public bool? desValorLogico { get; set; }
        public int? desValorEntero { get; set; }
        public Nullable<DateTime> desValorFecha { get; set; }
        public bool indActivo { get; set; }

        public TablaBE objTabla { get; set; }
    }
}
