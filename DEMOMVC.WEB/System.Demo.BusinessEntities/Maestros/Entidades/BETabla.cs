namespace System.Demo.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestros 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Entidad de negocio
    /// Archivo     : TablasMaestras.cs
    /// </summary>
    public class BETablaMaestra: BEBaseMaestro
    {
        public BETablaMaestra()
        {
            CodigoTabla = string.Empty;
            NombreTabla = string.Empty;
            DescripcionTabla = string.Empty;
            TipoArgumento = "A";
            TipoGeneracion = "A";
        }

        public string CodigoTabla { get; set; }

        public bool Niveles { get; set; }

        public int LongitudNivel { get; set; }

        public string NombreTabla { get; set; }

        public string DescripcionTabla { get; set; }

        public string TipoArgumento { get; set; }

        public string TipoGeneracion { get; set; }

        public string Idioma { get; set; }

        public long ROW { get; set; }

        public int TOTALROWS { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestros 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Entidad de negocio
    /// Archivo     : Tabla.cs
    /// </summary>
    public class TablaBE : BEBase
    {
        public TablaBE()
        {

        }
        public string codTabla { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indNivel { get; set; }
        public int numLongitudNivel { get; set; }
        public bool indActivo { get; set; }

    }
}
