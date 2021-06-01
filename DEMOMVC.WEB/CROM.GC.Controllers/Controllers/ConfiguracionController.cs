namespace CROM.GC.Controllers
{
    using CROM.GC.Models;

    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Maestros;
    using System.Demo.BusinessLogic.maestros;
    using System.Demo.Tools.entities;
    using System.Demo.Tools.settings;
    using System.Linq;
    using System.Web.Mvc;

    public class ConfiguracionController : BaseController
    {
        ConfiguracionLogic configLogic = null;
        TablaLogicNx objTablaLogicNx = null;
        BaseFiltroMaestro objFiltroMaestro = null;

        List<mvcConfiguracion> lstModelo = new List<mvcConfiguracion>();

        public ActionResult Index()
        {
            try
            {
                Dictionary<string, object>.ValueCollection data = this.ControllerContext.RouteData.Values.Values;
                ViewBag.nomController = data.ElementAt(0).ToString();
                ViewBag.nomAction = data.ElementAt(1).ToString();
                ViewBag.ValorTimeout = GlobalSettings.GetDEFAULT_ValorTimeout();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        public ActionResult IndexReg(int pID)
        {
            ViewBag.codConfiguracion = pID;
            return View();
        }

        [HttpPost]
        public ActionResult ListarConfig(Parametro parametro)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;

            object jsonResponse;
            try
            {
                configLogic = new ConfiguracionLogic();
                var lista = ListarConfiguraciones(configLogic.ListPaginado(new BaseFiltroConfiguracion
                {
                    jqCurrentPage = parametro.jqCurrentPage,
                    jqPageSize = parametro.jqPageSize,
                    jqSortColumn = parametro.jqSortColumn,
                    jqSortOrder = parametro.jqSortOrder,

                    codEmpresa = _tokenValidation.codEmpresa,
                    segUsuarioActual = _tokenValidation.desLogin,
                    desNombre = parametro.desNombre,
                    codKeyConfig = parametro.codKeyConfig,
                    codTabla = parametro.codTabla,
                    desValor = parametro.desValor,
                    indActivo = parametro.indActivo
                }));

                long totalRecords = lista.Select(x => x.TOTALROWS).FirstOrDefault();
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
                            ID = item.codConfiguracion,
                            Row = new string[] {item.codConfiguracion.ToString()
                                              , item.indOrden.ToString()
                                              , item.codKeyConfig
                                              , item.desValor
                                              , item.numNivel.ToString()
                                              , item.desNombre
                                              , item.desGrupo
                                              , item.indActivo.ToString()
                                              , item.fechaEdita
                                              , item.usuarioEdita
                                              
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
        public ActionResult ObtenerConfiguracion(int pId)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            mvcConfiguracion configuracion = new mvcConfiguracion();
            string tipoDevol = null;
            object DataDevol = null;

            object jsonResponse;
            try
            {
                objTablaLogicNx = new TablaLogicNx();
                objFiltroMaestro = new BaseFiltroMaestro();
                configLogic = new ConfiguracionLogic();
                configuracion = LlenarConfiguracion(configLogic.Find(_tokenValidation.codEmpresa,
                                                                     pId));
                object tablaReg = null;
                TablaBE objTabla = new TablaBE();
                if (!string.IsNullOrEmpty(configuracion.codTabla))
                {
                    objTabla = objTablaLogicNx.BuscarTabla(configuracion.codTabla,
                                                          _tokenValidation.codEmpresa, 
                                                          _tokenValidation.desLogin);

                    tablaReg = LlenarTabla(objTabla, configuracion.codTabla, configuracion.numNivel, configuracion.desValor);
                }
                DataDevol = new
                {
                    Tabla = tablaReg,
                    Data = configuracion,
                };
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
                };
            }
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GuardarConfiguracion(BEConfiguracion pConfiguracion)
        {
            ValidateToken(Request);
            if (!_tokenValidation.isValid())
                return Json(_tokenValidation.MessageValidation);

            string tipoDevol = null;
            object DataDevol = null;
            object jsonResponse;
            try
            {

                pConfiguracion.segUsuarioCrea = _tokenValidation.desLogin;
                pConfiguracion.segUsuarioEdita = _tokenValidation.desLogin;
                pConfiguracion.segMaquinaCrea = GetIPAddress();
                pConfiguracion.segMaquinaEdita = GetIPAddress();
                pConfiguracion.codEmpresa = _tokenValidation.codEmpresa;
                pConfiguracion.codEmpresaRUC = _tokenValidation.numRUC;
                ReturnValor returnValor = new ReturnValor();
                ConfiguracionLogic configuracionLogic = new ConfiguracionLogic();
                if (pConfiguracion.codConfiguracion == 0)
                    returnValor = configuracionLogic.Insert(pConfiguracion);
                else
                    returnValor = configuracionLogic.UpdateUsuario(pConfiguracion);

                tipoDevol = returnValor.Exitosa? "C": "I";
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


        private List<mvcConfiguracion> ListarConfiguraciones(List<BEConfiguracion> lstConfiguracion)
        {
            foreach (BEConfiguracion model in lstConfiguracion)
                lstModelo.Add(new mvcConfiguracion
                {
                    codConfiguracion = model.codConfiguracion,
                    codTabla = model.codTabla,
                    numNivel = model.numNivel,
                    codKeyConfig = model.codKeyConfig,
                    indActivo = model.indActivo,
                    desNombre = model.desNombre,
                    desGrupo = model.desGrupo,
                    desValor = model.desValor,
                    indOrden = model.indOrden,
                    fechaEdita = model.segFechaEdita.HasValue ? model.segFechaEdita.Value.ToString() : model.segFechaCrea.ToString(),
                    usuarioEdita = string.IsNullOrEmpty(model.segUsuarioEdita) ? model.segUsuarioCrea : model.segUsuarioEdita,
                    TOTALROWS = model.TOTALROWS
                });
            return lstModelo;
        }

        private mvcConfiguracion LlenarConfiguracion(BEConfiguracion pConfiguracion)
        {
            mvcConfiguracion itemConfig = new mvcConfiguracion
            {
                codTabla = pConfiguracion.codTabla,
                numNivel = pConfiguracion.numNivel,
                codConfiguracion = pConfiguracion.codConfiguracion,
                codKeyConfig = pConfiguracion.codKeyConfig,
                indTipoValor = pConfiguracion.indTipoValor,
                gloDescripcion = pConfiguracion.gloDescripcion,
                indGenerico = pConfiguracion.indGenerico,
                desGrupo = pConfiguracion.desGrupo,
                indActivo = pConfiguracion.indActivo,
                desNombre = pConfiguracion.desNombre,
                desValor = pConfiguracion.desValor,
                indOrden = pConfiguracion.indOrden,
                fechaEdita = pConfiguracion.segFechaEdita.HasValue ? pConfiguracion.segFechaEdita.Value.ToString() : pConfiguracion.segFechaCrea.ToString(),
                usuarioEdita = string.IsNullOrEmpty(pConfiguracion.segUsuarioEdita) ? pConfiguracion.segUsuarioCrea : pConfiguracion.segUsuarioEdita,
            };
            return itemConfig;
        }
    }
}
