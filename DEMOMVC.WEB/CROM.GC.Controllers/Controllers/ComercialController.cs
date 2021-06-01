namespace CROM.GC.Controllers
{
    using CROM.GC.Models;

    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Comercial;
    using System.Demo.BusinessLogic.comercial;
    using System.Demo.BusinessLogic.maestros;
    using System.Demo.Tools.config;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.helpers;
    using System.Demo.Tools.settings;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("comercial")]
    public class ComercialController : BaseController
    {
        private DocumentoEstadoLogic objDocumentoEstadoLogic = null;
        private TipoDeCambioLogic objTipoDeCambioLogic = null;
        private ConfiguracionLogic objConfiguracionLogic = null;
        private ReturnValor objReturnValor = null;

        #region INICIO: ActionResult de la entidad BEDocumentoEstado

        public ActionResult DocumentoEstado()
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();
                ViewBag.ValorTimeout = GlobalSettings.GetDEFAULT_ValorTimeout();

                ViewBag.cboDocumentos = LlenarLista(HelpTMaestras.TM.GCDocumentosComproba);
                ViewBag.cboEstados = LlenarLista(HelpTMaestras.TM.GCEstadosLetraCambio);

                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult DocumentoEstadoListar(Parametro parametro)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;

            object jsonResponse;
            try
            {
                objDocumentoEstadoLogic = new DocumentoEstadoLogic();
                List<mvcDocumentoEstado> lstDocumentoEstado = new List<mvcDocumentoEstado>();

                var lista = objDocumentoEstadoLogic.ListPaged(new BaseFiltro
                {
                    grcurrentPage = parametro.jqCurrentPage,
                    grpageSize = parametro.jqPageSize,
                    grsortColumn = parametro.jqSortColumn,
                    grsortOrder = parametro.jqSortOrder,
                    codDocumentoEstado = null,
                    codRegDocumento = parametro.codRegDocumento,
                    codRegEstado = parametro.codRegEstado,
                });

                long totalRecords = lista.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)parametro.jqPageSize);

                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = parametro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in DocumentoEstadoPasarLista(lista)
                        select new
                        {
                            ID = item.codDocumentoEstado,
                            Row = new string[] {"",""
                                              , item.indActivo.ToString()
                                              , item.codRegDocumentoDesc
                                              , item.codRegEstadoDesc
                                              , item.codRegEstadoColor
                                              , item.codEstado.ToString()
                                              , item.fechaEditas.ToString()
                                              , item.usuarioEdita
                                              , item.codRegDocumento
                                              , item.codRegEstado
                                              }
                        }).ToArray()
                };

                tipoDevol = "C";
                DataDevol = jsonGrid;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public JsonResult DocumentoEstadoBuscar(int pId)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object lstDocumentos = null;
            object lstEstados = null;
            object jsonResponse;
            try
            {
                objDocumentoEstadoLogic = new DocumentoEstadoLogic();
                mvcDocumentoEstado documentoEstado = DocumentoEstadoPasar(objDocumentoEstadoLogic.Find(new BaseFiltro { codDocumentoEstado = pId }));

                lstDocumentos = LlenarListaJQ(HelpTMaestras.TM.GCDocumentosComproba);
                lstEstados = LlenarListaJQ(HelpTMaestras.TM.GCEstadosLetraCambio);

                DataDevol = documentoEstado;
                tipoDevol = "C";
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                    Documentos = lstDocumentos,
                    Estados = lstEstados
                };
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DocumentoEstadoGuardar(BEDocumentoEstado pData)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object jsonResponse;
            try
            {
                objDocumentoEstadoLogic = new DocumentoEstadoLogic();
                pData.segUsuarioCrea = HttpContext.User.Identity.Name;
                pData.segUsuarioEdita = HttpContext.User.Identity.Name;
                ReturnValor returnValor = new ReturnValor();
                if (pData.codDocumentoEstado == 0)
                    returnValor = objDocumentoEstadoLogic.Insert(pData);
                else
                    returnValor = objDocumentoEstadoLogic.Update(pData);
                if (!returnValor.Exitosa)
                {
                    tipoDevol = "I";
                    DataDevol = returnValor.Message;
                }
                else
                {
                    tipoDevol = "C";
                    DataDevol = returnValor.Message;
                }
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DocumentoEstadoEliminar(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object jsonResponse;
            try
            {
                objDocumentoEstadoLogic = new DocumentoEstadoLogic();
                ReturnValor returnValor = new ReturnValor();
                returnValor = objDocumentoEstadoLogic.Delete(lstDocumentoEstado);
                tipoDevol = "C";
                DataDevol = returnValor.Message;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        private mvcDocumentoEstado DocumentoEstadoPasar(BEDocumentoEstado pEntidad)
        {
            mvcDocumentoEstado documentoEstado = new mvcDocumentoEstado();
            documentoEstado.indActivo = true;

            if (pEntidad != null)
                documentoEstado = new mvcDocumentoEstado
                {
                    codDocumentoEstado = pEntidad.codDocumentoEstado,
                    codRegDocumentoDesc = pEntidad.auxcodRegDocumento,
                    codRegEstadoDesc = pEntidad.auxcodRegEstado,
                    codRegDocumento = pEntidad.codRegDocumento,
                    codRegEstadoColor = pEntidad.codRegEstadoColor,
                    codRegEstado = pEntidad.codRegEstado,
                    indActivo = pEntidad.indActivo,
                    fechaEditas = pEntidad.segFechaEdita == null ? string.Empty : pEntidad.segFechaEdita.ToString(),
                    usuarioEdita = pEntidad.segUsuarioEdita
                };

            return documentoEstado;
        }

        private List<mvcDocumentoEstado> DocumentoEstadoPasarLista(List<BEDocumentoEstado> lstEntidad)
        {
            List<mvcDocumentoEstado> lstdocumentoEstado = new List<mvcDocumentoEstado>();

            foreach (BEDocumentoEstado pEntidad in lstEntidad)
            {
                mvcDocumentoEstado documentoEstado = new mvcDocumentoEstado
                {
                    codDocumentoEstado = pEntidad.codDocumentoEstado,
                    codRegDocumentoDesc = pEntidad.auxcodRegDocumento,
                    codRegEstadoDesc = pEntidad.auxcodRegEstado,
                    codRegDocumento = pEntidad.codRegDocumento,
                    codRegEstadoColor = pEntidad.codRegEstadoColor,
                    codEstado = pEntidad.codEstado,
                    indActivo = pEntidad.indActivo,
                    fechaEditas = pEntidad.segFechaEdita == null ? string.Empty : pEntidad.segFechaEdita.ToString(),
                    usuarioEdita = pEntidad.segUsuarioEdita
                };
                lstdocumentoEstado.Add(documentoEstado);
            }
            return lstdocumentoEstado;
        }

        #endregion FINAL:  ActionResult de la entidad BEDocumentoEstado

        #region INICIO: ActionResult de la entidad TIPOCAMBIO

        public ActionResult TipoCambio()
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();

                int numDias = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Day;
                ViewBag.fecInicio = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).AddDays(numDias * (-1)).Date.ToShortDateString();
                ViewBag.fecFinal = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).AddDays(0).Date.ToShortDateString();

                objConfiguracionLogic = new ConfiguracionLogic();
                ViewBag.webTipoCambio = GlobalSettings.GetDEFAULT_LinkTipoCambio();
                ViewBag.cboMonedas = LlenarLista(HelpTMaestras.TM.GCTiposDeMoneda);
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult TipoCambioReg(int pID)
        {
            objConfiguracionLogic = new ConfiguracionLogic();
            ViewBag.webTipoCambio = GlobalSettings.GetDEFAULT_LinkTipoCambio();
            ViewBag.cboMonedas = LlenarLista(HelpTMaestras.TM.GCTiposDeMoneda);
            ViewBag.codTipoCambio = pID;
            return View();
        }

        [HttpPost]
        public ActionResult TipoCambioBuscar(string pID)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object lstMonedas = null;
            string codRegMonedaExt = null;

            object jsonResponse;
            try
            {
                objTipoDeCambioLogic = new TipoDeCambioLogic();
                int codTipoCambio = string.IsNullOrEmpty(pID) ? 0 : Convert.ToInt32(pID);
                var regTipoCambio = PasarAModeloTipoCambio(objTipoDeCambioLogic.Find(_tokenValidation.codEmpresa,
                                                                                     codTipoCambio));
                codRegMonedaExt = ConfigCROM.AppConfig(_tokenValidation.codEmpresa, ConfigTool.DEFAULT_MonedaInt);
                lstMonedas = LlenarListaJQ(HelpTMaestras.TM.GCTiposDeMoneda);
                tipoDevol = "C";
                DataDevol = regTipoCambio;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    codRegMonedaExt = codRegMonedaExt,
                    Data = DataDevol,
                    Monedas = lstMonedas
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult TipoCambioListar(Parametro parametro)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;

            object jsonResponse;
            try
            {
                objTipoDeCambioLogic = new TipoDeCambioLogic();
                BETipoDeCambio objTipoDeCambio = new BETipoDeCambio();
                Nullable<DateTime> fechaNula = null;

                int p_PAGESIZE = parametro.jqPageSize;
                int p_CURRENTPAGE = parametro.jqCurrentPage;
                string p_SORTCOLUMN = parametro.jqSortColumn;
                string p_SORTORDER = parametro.jqSortOrder;

                var lista = PasarAModeloTipoCambio(
                            objTipoDeCambioLogic.ListPaged(new
                            BaseFiltroTipoCambioPage
                            {
                                codEmpresa = _tokenValidation.codEmpresa,
                                fecInicioDate = string.IsNullOrEmpty(parametro.fechaInicio) ? fechaNula : Convert.ToDateTime(parametro.fechaInicio),
                                fecFinalDate = string.IsNullOrEmpty(parametro.fechaFinal) ? fechaNula : Convert.ToDateTime(parametro.fechaFinal),
                                codRegMoneda = parametro.codRegMoneda,
                                indEstado = parametro.indActivo,
                                jqPageSize = p_PAGESIZE,
                                jqCurrentPage = p_CURRENTPAGE,
                                jqSortColumn = p_SORTCOLUMN,
                                jqSortOrder = p_SORTORDER
                            }));

                int totalRecords = lista.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)parametro.jqPageSize);

                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = parametro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lista
                        select new
                        {
                            ID = item.codTipoCambio,
                            Row = new string[] {item.codTipoCambio.ToString()
                                              , item.codTipoCambio.ToString()
                                              , item.fecProceso
                                              , item.codRegMoneda
                                              , item.monCompraGOB.ToString("N3")
                                              , item.monVentaGOB.ToString("N3")
                                              , (item.Estado.ToString()=="1"?true:false).ToString()
                                              , item.UsuModi
                                              , item.FeModi }
                        }).ToArray()
                };

                tipoDevol = "C";
                DataDevol = jsonGrid;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult TipoCambioEliminar(string pID)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object jsonResponse;
            try
            {
                objTipoDeCambioLogic = new TipoDeCambioLogic();
                int codTipoCambio = string.IsNullOrEmpty(pID) ? 0 : Convert.ToInt32(pID);
                objReturnValor = objTipoDeCambioLogic.Delete(_tokenValidation.codEmpresa,
                                                            codTipoCambio,
                                                            _tokenValidation.desLogin);
                if (objReturnValor.Exitosa)
                    tipoDevol = "C";
                else
                    tipoDevol = "I";
                DataDevol = objReturnValor.Message;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol
                };
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult TipoCambioGuardar(BETipoDeCambio objTipoDeCambio)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object jsonResponse;
            try
            {
                objTipoDeCambioLogic = new TipoDeCambioLogic();
                objTipoDeCambio.codEmpresa = _tokenValidation.codEmpresa;
                objTipoDeCambio.segFechaEdita = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
                objTipoDeCambio.segUsuarioEdita = User.Identity.Name;
                objTipoDeCambio.segUsuarioCrea = User.Identity.Name;
                objTipoDeCambio.segMaquinaCrea = User.Identity.Name;
                objTipoDeCambio.segMaquinaEdita = User.Identity.Name;

                if (objTipoDeCambio.codTipoCambio <= 0)
                    objReturnValor = objTipoDeCambioLogic.Insert(objTipoDeCambio);
                else
                    objReturnValor = objTipoDeCambioLogic.Update(objTipoDeCambio);
                if (objReturnValor.Exitosa)
                    tipoDevol = "C";
                else
                    tipoDevol = "I";
                DataDevol = objReturnValor.Message;
            }
            catch (Exception ex)
            {
                tipoDevol = "E";
                DataDevol = ex.Message;
            }
            finally
            {
                jsonResponse = new
                {
                    Type = tipoDevol,
                    Data = DataDevol,
                };
            }
            return Json(jsonResponse);
        }

        private List<mvcTipoCambio> PasarAModeloTipoCambio(List<BETipoDeCambio> list)
        {
            List<mvcTipoCambio> lstTipoCambio = new List<mvcTipoCambio>();
            foreach (BETipoDeCambio objTipoCambio in list)
                lstTipoCambio.Add(new mvcTipoCambio
                {
                    
                    codTipoCambio = objTipoCambio.codTipoCambio,
                    fecProceso = objTipoCambio.FechaProceso.ToShortDateString(),
                    codRegMoneda = objTipoCambio.CodigoArguMonedaNombre,
                    monCompraGOB = objTipoCambio.CambioCompraGOB,
                    monVentaGOB = objTipoCambio.CambioVentasGOB,
                    monCompraPRL = objTipoCambio.CambioCompraPRL,
                    monVentaPRL = objTipoCambio.CambioVentasPRL,
                    FeModi = objTipoCambio.segFechaEdita.HasValue ? objTipoCambio.segFechaEdita.Value.ToString() : objTipoCambio.segFechaCrea.ToString(),
                    UsuModi = string.IsNullOrEmpty(objTipoCambio.segUsuarioEdita) ? objTipoCambio.segUsuarioCrea : objTipoCambio.segUsuarioEdita,
                    Estado = objTipoCambio.Estado ? "1" : "0",

                    TOTALROWS = objTipoCambio.TOTALROWS,
                });
            return lstTipoCambio;
        }

        private mvcTipoCambio PasarAModeloTipoCambio(BETipoDeCambio objTipoDeCambio)
        {
            mvcTipoCambio itemTipoCambio = null;
            if (objTipoDeCambio != null)
                itemTipoCambio = new mvcTipoCambio
                {
                    codTipoCambio = objTipoDeCambio.codTipoCambio,
                    fecProceso = objTipoDeCambio.FechaProceso.ToShortDateString(),
                    codRegMoneda = objTipoDeCambio.CodigoArguMoneda,
                    monCompraGOB = objTipoDeCambio.CambioCompraGOB,
                    monVentaGOB = objTipoDeCambio.CambioVentasGOB,
                    monCompraPRL = objTipoDeCambio.CambioCompraPRL,
                    monVentaPRL = objTipoDeCambio.CambioVentasPRL,
                    FeModi = objTipoDeCambio.segFechaEdita.HasValue ? objTipoDeCambio.segFechaEdita.Value.ToString() : objTipoDeCambio.segFechaCrea.ToString(),
                    UsuModi = string.IsNullOrEmpty(objTipoDeCambio.segUsuarioEdita) ? objTipoDeCambio.segUsuarioCrea : objTipoDeCambio.segUsuarioEdita,
                    Estado = objTipoDeCambio.Estado ? "1" : "0",
                };
            else
                itemTipoCambio = new mvcTipoCambio
                {
                    fecProceso = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToShortDateString(),
                    FeModi = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToString(),
                    UsuModi = User.Identity.Name,
                    Estado = "1",
                    codTipoCambio = -1
                };
            return itemTipoCambio;
        }

        #endregion FINAL:  ActionResult de la entidad TIPOCAMBIO

    }
}
