namespace System.Demo.DataAccess.maestros
{
    using System;
    using System.Collections.Generic;
    using System.Demo.BusinessEntities.Maestros;


    public class RegistroData
    {

        private string conexion = string.Empty;
        public RegistroData()
        {
            conexion = UtilDataCnx.ConexionBD();
        }

        public List<BERegistro> ListarCombo(string pCaso, string pCodTabla, string pCodArgu, int pNivel, int pEstado)
        {
            List<BERegistro> lstRegistro = new List<BERegistro>();
            try
            {
                using (_DBMLDataMaestrosDataContext tablaDetalleDC = new _DBMLDataMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.demo_mvc_S_Registro_Combo(pCodTabla, pCodArgu, pNivel, pEstado == 1 ? true : false);
                    foreach (var item in query)
                    {
                        lstRegistro.Add(new BERegistro()
                        {
                            CodigoTabla = item.codTabla,
                            CodigoArgumento = item.codRegistro,
                            NivelDetalle = item.numNivel,
                            DescripcionCorta = item.desNombre,
                            DescripcionLarga = item.gloDescripcion,
                            Estado = Convert.ToBoolean(item.indActivo),
                            ValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            ValorCadena = item.desValorCadena,
                            ValorBoolean = Convert.ToBoolean(item.desValorLogico),
                            ValorEntero = Convert.ToInt32(item.desValorEntero),
                            ValorFecha = item.desValorFecha
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRegistro;
        }

        public List<BERegistroNew> ListarCombo(BaseFiltroMaestro objFiltro)
        {
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            try
            {
                using (_DBMLDataMaestrosDataContext tablaDetalleDC = new _DBMLDataMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.demo_mvc_S_Registro_Combo(objFiltro.codTabla,
                                                                         objFiltro.codReg,
                                                                         objFiltro.numNivel,
                                                                         objFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lstRegistro.Add(new BERegistroNew()
                        {
                            codTabla = item.codTabla,
                            codRegistro = item.codRegistro,
                            numNivel = item.numNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            desValorDecimal = item.desValorDecimal,
                            desValorCadena = item.desValorCadena,
                            desValorLogico = item.desValorLogico,
                            desValorEntero = item.desValorEntero,
                            desValorFecha = item.desValorFecha
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRegistro;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
