namespace System.Demo.BusinessLogic.comercial
{
    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Comercial;
    using System.Demo.DataAccess.comercial;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Reflection;
    using System.Transactions;


    public class TipoDeCambioLogic
    {
        private TipoDeCambioData oTipoDeCambioData = null;
        private ReturnValor oReturnValor = null;

        public TipoDeCambioLogic()
        {
            oTipoDeCambioData = new TipoDeCambioData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TipoDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="pTipoDeCambio"></param>
        /// <returns></returns>
        public ReturnValor Insert(BETipoDeCambio pTipoDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    BaseFiltroTipoCambio filtro = new BaseFiltroTipoCambio();
                    filtro.codEmpresa = pTipoDeCambio.codEmpresa;
                    filtro.fecInicio = HelpTime.ConvertYYYYMMDD(pTipoDeCambio.FechaProceso);
                    filtro.codRegMoneda = pTipoDeCambio.CodigoArguMoneda;
                    if (oTipoDeCambioData.Find(filtro) == null)
                    {
                        oReturnValor.codRetorno = oTipoDeCambioData.Insert(pTipoDeCambio);
                        if (oReturnValor.codRetorno != 0)
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                            tx.Complete();
                        }
                    }
                    else
                        oReturnValor.Message = ConstantMESSAGES.MESSAGE_TIPO_CAMBIO;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            pTipoDeCambio.segUsuarioCrea, pTipoDeCambio.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="pTipoDeCambio"></param>
        /// <returns></returns>
        public ReturnValor Update(BETipoDeCambio pTipoDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oTipoDeCambioData.Update(pTipoDeCambio);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            pTipoDeCambio.segUsuarioEdita, pTipoDeCambio.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="prm_codTipoCambio"></param>
        /// <returns></returns>
        public ReturnValor Delete(int pcodEmpresa, int prm_codTipoCambio, string segUsuarioActual)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oTipoDeCambioData.Delete(pcodEmpresa, prm_codTipoCambio);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            segUsuarioActual, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BETipoDeCambio> List(BaseFiltroTipoCambio pFiltro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new List<BETipoDeCambio>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstTipoDeCambio = oTipoDeCambioData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                            pFiltro.segUsuarioActual, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstTipoDeCambio;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BETipoDeCambio> ListPaged(BaseFiltroTipoCambioPage filtro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new List<BETipoDeCambio>();
            try
            {
                filtro.fecInicio = HelpTime.ConvertYYYYMMDD(filtro.fecInicioDate);
                filtro.fecFinal = HelpTime.ConvertYYYYMMDD(filtro.fecFinalDate);
                lstTipoDeCambio = oTipoDeCambioData.ListPaged(filtro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                        this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                        filtro.segUsuarioActual, filtro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstTipoDeCambio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public BETipoDeCambio Find(int pcodEmpresa, int prm_codTipoCambio)
        {
            BETipoDeCambio tiposDeCambio = new BETipoDeCambio();
            try
            {
                tiposDeCambio = oTipoDeCambioData.Find(pcodEmpresa, prm_codTipoCambio);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return tiposDeCambio;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BETipoDeCambio Find(BaseFiltroTipoCambio filtro)
        {
            BETipoDeCambio tiposDeCambio = new BETipoDeCambio();
            try
            {
                filtro.fecInicio = HelpTime.ConvertYYYYMMDD(filtro.fecInicioDate);
                tiposDeCambio = oTipoDeCambioData.Find(filtro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                  this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  filtro.segUsuarioActual, filtro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return tiposDeCambio;
        }

        #endregion

    }
}
