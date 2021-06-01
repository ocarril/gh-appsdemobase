using System;
using System.Collections.Generic;
using System.Demo.BusinessEntities.Comercial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.DataAccess.comercial
{
    public class TipoDeCambioData
    {
        private string conexion = string.Empty;

        public TipoDeCambioData()
        {
            conexion = UtilDataCnx.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="pTipoDeCambio"></param>
        /// <returns></returns>
        public int Insert(BETipoDeCambio pTipoDeCambio)
        {
            int? codigoRetorno = null;
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    SQLDC.demo_mvc_I_TipoDeCambio(
                       ref codigoRetorno,
                       pTipoDeCambio.codEmpresa,
                       pTipoDeCambio.FechaProceso,
                       pTipoDeCambio.CodigoArguMoneda,
                       pTipoDeCambio.CambioCompraGOB,
                       pTipoDeCambio.CambioVentasGOB,
                       pTipoDeCambio.CambioCompraPRL,
                       pTipoDeCambio.CambioVentasPRL,
                       pTipoDeCambio.Estado,
                       pTipoDeCambio.segUsuarioCrea,
                       pTipoDeCambio.segMaquinaCrea);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="pTipoDeCambio"></param>
        /// <returns></returns>
        public bool Update(BETipoDeCambio pTipoDeCambio)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    SQLDC.demo_mvc_U_TipoDeCambio(
                        pTipoDeCambio.codEmpresa,
                        pTipoDeCambio.codTipoCambio,
                        pTipoDeCambio.FechaProceso,
                        pTipoDeCambio.CodigoArguMoneda,
                        pTipoDeCambio.CambioCompraGOB,
                        pTipoDeCambio.CambioVentasGOB,
                        pTipoDeCambio.CambioCompraPRL,
                        pTipoDeCambio.CambioVentasPRL,
                        pTipoDeCambio.Estado,
                        pTipoDeCambio.segUsuarioEdita,
                        pTipoDeCambio.segMaquinaEdita);
                    codigoRetorno = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="prm_codTipoCambio"></param>
        /// <returns>Valor bool</returns>
        public bool Delete(int pcodEmpresa, int prm_codTipoCambio)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    SQLDC.demo_mvc_D_TipoDeCambio(pcodEmpresa, prm_codTipoCambio);
                    codigoRetorno = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TipodeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro">Contenedor de parametros de filtro</param>
        /// <returns>Colección de la entidad TipoDeCambio</returns>
        public List<BETipoDeCambio> List(BaseFiltroTipoCambio filtro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new List<BETipoDeCambio>();
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_TipoDeCambio(filtro.codEmpresa,
                                                          filtro.codTipoCambio,
                                                          filtro.fecInicio,
                                                          filtro.fecFinal,
                                                          filtro.codRegMoneda,
                                                          filtro.indEstado);
                    foreach (var item in resul)
                    {
                        lstTipoDeCambio.Add(new BETipoDeCambio()
                        {
                            codTipoCambio = item.codTipoCambio,
                            FechaProceso = item.FechaProceso,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CambioCompraGOB = item.CambioCompraGOB,
                            CambioVentasGOB = item.CambioVentasGOB,
                            CambioCompraPRL = item.CambioCompraPRL,
                            CambioVentasPRL = item.CambioVentasPRL,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstTipoDeCambio;
        }

        public List<BETipoDeCambio> ListPaged(BaseFiltroTipoCambioPage pFiltro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new List<BETipoDeCambio>();
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_TipoDeCambio_Paged(pFiltro.jqCurrentPage
                                                               , pFiltro.jqPageSize
                                                               , pFiltro.jqSortColumn
                                                               , pFiltro.jqSortOrder
                                                               , pFiltro.codEmpresa
                                                               , pFiltro.fecInicio
                                                               , pFiltro.fecFinal
                                                               , pFiltro.codRegMoneda
                                                               , pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstTipoDeCambio.Add(new BETipoDeCambio()
                        {
                            codTipoCambio = item.codTipoCambio,
                            FechaProceso = item.FechaProceso,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CambioCompraGOB = item.CambioCompraGOB,
                            CambioVentasGOB = item.CambioVentasGOB,
                            CambioCompraPRL = item.CambioCompraPRL,
                            CambioVentasPRL = item.CambioVentasPRL,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstTipoDeCambio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="prm_codTipoCambio">Key de la Tabla</param>
        /// <returns>La entidad TiposDeCambio </returns>
        public BETipoDeCambio Find(int pcodEmpresa, int prm_codTipoCambio)
        {
            BETipoDeCambio objTipoDeCambio = null;
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_TipoDeCambio(pcodEmpresa, prm_codTipoCambio, null, null, null, null);
                    foreach (var item in resul)
                    {
                        objTipoDeCambio = new BETipoDeCambio()
                        {
                            codEmpresa = pcodEmpresa,
                            codTipoCambio = item.codTipoCambio,
                            FechaProceso = item.FechaProceso,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CambioCompraGOB = item.CambioCompraGOB,
                            CambioVentasGOB = item.CambioVentasGOB,
                            CambioCompraPRL = item.CambioCompraPRL,
                            CambioVentasPRL = item.CambioVentasPRL,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipoDeCambio;
        }

        public BETipoDeCambio Find(BaseFiltroTipoCambio filtro)
        {
            BETipoDeCambio objTipoDeCambio = null;
            try
            {
                using (_DBMLDataComercialDataContext SQLDC = new _DBMLDataComercialDataContext(conexion))
                {
                    var resul = SQLDC.demo_mvc_S_TipoDeCambio(filtro.codEmpresa, null, filtro.fecInicio
                                                          , filtro.fecInicio
                                                          , filtro.codRegMoneda, null);
                    foreach (var item in resul)
                    {
                        objTipoDeCambio = new BETipoDeCambio()
                        {
                            codEmpresa = filtro.codEmpresa,
                            codTipoCambio = item.codTipoCambio,
                            FechaProceso = item.FechaProceso,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CambioCompraGOB = item.CambioCompraGOB,
                            CambioVentasGOB = item.CambioVentasGOB,
                            CambioCompraPRL = item.CambioCompraPRL,
                            CambioVentasPRL = item.CambioVentasPRL,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipoDeCambio;
        }

        #endregion

    }

}
