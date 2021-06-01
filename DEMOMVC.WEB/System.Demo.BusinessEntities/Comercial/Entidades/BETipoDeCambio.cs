namespace System.Demo.BusinessEntities.Comercial
{
    using System;
    using System.Demo.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : 
    /// Fecha       : 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.TiposdeCambio.cs]
    /// </summary>
    public class BETipoDeCambio : BEBase
    {
        public BETipoDeCambio()
        {
            objMoneda = new BERegistroNew();
        }

        public int codTipoCambio { get; set; }
        public DateTime FechaProceso { get; set; }
        public string CodigoArguMoneda { get; set; }
        public decimal CambioCompraGOB { get; set; }
        public decimal CambioVentasGOB { get; set; }
        public decimal CambioCompraPRL { get; set; }
        public decimal CambioVentasPRL { get; set; }
        public bool Estado { get; set; }

        public BERegistroNew objMoneda { get; set; }

        public string CodigoArguMonedaNombre { get; set; }
    }
} 
