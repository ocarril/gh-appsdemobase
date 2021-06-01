namespace System.Demo.BusinessLogic.maestros
{
    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Maestros;
    using System.Demo.DataAccess.maestros;
    using System.Demo.Tools.config;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Reflection;
    using System.Transactions;


    public class ConfiguracionLogic
    {
        private ConfiguracionData oConfiguracionData = null;
        private ReturnValor oReturnValor = null;

        public ConfiguracionLogic()
        {
            oConfiguracionData = new ConfiguracionData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        public List<BEConfiguracion> List(BaseFiltroConfiguracion pFiltroConfig)
        {
            List<BEConfiguracion> lstConfiguracion = new List<BEConfiguracion>();
            try
            {
                lstConfiguracion = oConfiguracionData.List(pFiltroConfig);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                  this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pFiltroConfig.segUsuarioActual, pFiltroConfig.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstConfiguracion;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="pFiltroConfig"></param>
        /// <returns></returns>
        public List<BEConfiguracion> ListPaginado(BaseFiltroConfiguracion pFiltroConfig)
        {
            List<BEConfiguracion> lstConfiguracion = new List<BEConfiguracion>();
            try
            {
                lstConfiguracion = oConfiguracionData.ListPaginado(pFiltroConfig);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                  this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pFiltroConfig.segUsuarioActual, pFiltroConfig.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstConfiguracion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="pIdConfiguracion"></param>
        /// <returns></returns>
        public BEConfiguracion Find(int pcodEmpresa, int pIdConfiguracion)
        {
            BEConfiguracion configuracion = new BEConfiguracion();
            try
            {
                configuracion = oConfiguracionData.Find(pcodEmpresa, pIdConfiguracion);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                  this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return configuracion;
        }

        public BEConfiguracion Find(int pcodEmpresa, ConfigTool pcodKeyConfig)
        {
            BEConfiguracion configuracion = new BEConfiguracion();
            try
            {
                configuracion = oConfiguracionData.Find(pcodEmpresa, pcodKeyConfig.ToString());
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                                  this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return configuracion;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEConfiguracion configuracion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oConfiguracionData.Insert(configuracion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = ConstantMESSAGES.MESSAGE_NEW;
                        oReturnValor.codRetorno = configuracion.codConfiguracion;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            configuracion.segUsuarioCrea, configuracion.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>
        public ReturnValor UpdateUsuario(BEConfiguracion configuracion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    BEConfiguracion configActual = oConfiguracionData.Find(configuracion.codEmpresa,
                                                                           configuracion.codConfiguracion);

                    configuracion.codKeyConfig = configActual.codKeyConfig;
                    configuracion.codTabla = configActual.codTabla;
                    configuracion.numNivel = configActual.numNivel;
                    configuracion.indTipoValor = configActual.indTipoValor;

                    oReturnValor.Exitosa = oConfiguracionData.Update(configuracion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = ConstantMESSAGES.MESSAGE_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            configuracion.segUsuarioCrea, configuracion.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>
        public ReturnValor UpdateAdmin(BEConfiguracion configuracion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oConfiguracionData.Update(configuracion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = ConstantMESSAGES.MESSAGE_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            configuracion.segUsuarioCrea, configuracion.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateConfig(BEConfiguracion configuracion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    BEConfiguracion configuracionBuscada = oConfiguracionData.Find(configuracion.codEmpresa,
                                                                                   configuracion.codKeyConfig);

                    if (configuracionBuscada != null)
                    {
                        oReturnValor.Exitosa = oConfiguracionData.UpdateConfig(configuracion);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = ConstantMESSAGES.MESSAGE_EDIT;
                            tx.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            configuracion.segUsuarioCrea, configuracion.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name="p_Configuracion"></param>
        /// <returns></returns>
        public ReturnValor Delete(BEConfiguracion pConfiguracion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oConfiguracionData.Delete(pConfiguracion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = ConstantMESSAGES.MESSAGE_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                            this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            pConfiguracion.segUsuarioElimina, pConfiguracion.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion


    }
}
