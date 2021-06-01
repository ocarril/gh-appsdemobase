using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.helpers
{
    public static class HelpTMaestras
    {
        /// <summary>
        /// Describen el nombre de las tablas Maestras
        /// </summary>
        public enum TM
        {
            AsistCalculoTiempos,    //ACALT	Cálculos de Tiempos
            DiasDeLaSemana,         //ADIAS	Días de la Semana
            PersonaAreasEmpresa,    //AREAS	Areas de Empresa
            AsistRelojes,           //ARELO	Relojes
            AsistTiposDeHorario,    //ATHOR	Tipos de Horarios
            PersonaCargos,          //CARGO	Cargos de Empleados
            PersonaCategorias,      //CATEG	CATEGORIAS DE EMPLEADOS
            PersonaTiposDeDocum,    //DOCUM	TIPOS DE DOCUMENTOS
            PersonaEstadosCivil,    //ESTCI	Estados Civiles
            GCMotivosAnulacion,     //GANLD	Motivos de Anulación de Documentos
            GCTiposDeImpuestos,     //GCIMP	Impuestos de Gestión Comercial
            GCDocumentosComproba,   //GCMPB	Comprobantes de Pago o Documentos
            GCDestinoDeDocumentos,  //GDSTC	Destino de Comprobantes
            GCTiposDeMovimiento,    //GMMOV	Tipos de Movimientos
            GCMotivosDeLaGuiaRE,    //GMTGU	Motivos de la Guia de Remisión
            ProducSectoresDeVenta,  //GSVTA	Sectores de Ventas
            GCTiposDeMoneda,        //GTMND	Tipos de MONEDAS
            GCMotivosMovimiento,    //GTMOV	Motivos de Movimientos
            GCTurnosComerciales,    //GTURN	Turnos Comerciales
            PersonaTiposDomicilio,  //MTDOM	Tipos de Domicilios
            PersonaAsignaciones,    //PASIG	Asignaciónes para Personas
            PersonaTipoAsignacion,  //PTIPO Tipo de Asignaciónes para Personas
            PersonaAtributos,       //PATRB	Atributos de Personas
            ProducAtributoParte,    //PATRI	Atributos de las Partes
            ProducCategorias,       //PCATE	Categoría de Productos
            ProducColores,          //PCLRP	Colores
            CentroDeCostos,         //PCNTC	Centros de Costos
            ProducionCentro,        //PCNTP	Centro de Producciónes
            GastosAduaneros,        //GADUA	Gastos aduaneros
            ProducGarantias,        //PGRNT	Tipos de Garantia a Productos
            ProducLineas,           //PLINE	Lineas de Productos
            ProducMateriales,       //PMATE	Materiales de Productos
            ProducUnidadMedida,     //PMEDI	Unidades de Medida
            ProducMetodosAlmac,     //PMTDA	Métodos de Almacenamiento
            ProducPartes,           //PPART	Partes del Producto
            PersonaProfesiones,     //PROFE	Profesiones de Empleados
            ProducSectoresAlmac,    //PSALM	Sectores de Almacenamiento
            ProducTipos,            //PTPRO	Tipo de Producto
            PersonaRubrosComerc,    //RUBRC	Rubros Comerciales
            PersonaGrupoSanguineo,  //PGRSN Grupos Sanguineos;
            TiposDeArchivos,        //TFILE	Tipos de Archivos
            TablaDePaises,          //TPAIS	TABLA DE PAISES
            SectoresZonasDeParqueo, //SCPQA	Sectores/Zonas de parqueo
            TiposDeVehiculos,       //TVEHI	Tipos de Vehículos
            GCEstadosLetraCambio,   //ESTLC Estados de la letra de cambio
            ProducEstadoMercaderia, //PETMC Estados de las mercaderias
            ImportCanalAduana,      //IMACN	Importación - Tipo de Canal de Aduana
            ImportNacionalización,  //IMNCN	Importación - Tipo de Nacionalización
            ImportTipoIncotermo,    //IMICT	Importación - Tipo de Incotermo
            ImportResCostoAduadero, //IMCST	Importación - Resumen de costos aduadero 
            TiposCuentasBancarias,  //TPCTA Caja-Banco - Tipos de Cuentas Bancarias
            TiposViasDomicilios,    //TVIDM	Personas - Tipos de vias para domicilios
            TiposZonasNucleoUrbano, //TZNDM	Personas - Tipos de zonas/nucleos urbanos para domicilios
            TiposPlazosDePago,      //TPLAZ Tipos de Plazos para los Pagos a credito
        }
        /// <summary>
        /// OBTIENE EL CODIGO DE LA TABLA MAESTRA
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string CodigoTabla(TM valor)
        {
            string CodigoTabla = string.Empty; ;
            switch (valor)
            {
                case TM.PersonaTipoAsignacion:  //PTIPO	Persona TIPO DE ASIGNACION
                    CodigoTabla = "PTIPO";
                    break;
                case TM.AsistCalculoTiempos:    //ACALT	Cálculos de Tiempos
                    CodigoTabla = "ACALT";
                    break;
                case TM.DiasDeLaSemana:         //ADIAS	Días de la Semana
                    CodigoTabla = "ADIAS";
                    break;
                case TM.PersonaAreasEmpresa:    //AREAS	Areas de Empresa
                    CodigoTabla = "AREAS";
                    break;
                case TM.AsistRelojes:           //ARELO	Relojes
                    CodigoTabla = "ARELO";
                    break;
                case TM.AsistTiposDeHorario:    //ATHOR	Tipos de Horarios
                    CodigoTabla = "ATHOR";
                    break;
                case TM.PersonaCargos:          //CARGO	Cargos de Empleados
                    CodigoTabla = "CARGO";
                    break;
                case TM.PersonaCategorias:      //CATEG	CATEGORIAS DE EMPLEADOS
                    CodigoTabla = "CATEG";
                    break;
                case TM.PersonaTiposDeDocum:    //DOCUM	TIPOS DE DOCUMENTOS
                    CodigoTabla = "DOCUM";
                    break;
                case TM.PersonaEstadosCivil:    //ESTCI	Estados Civiles
                    CodigoTabla = "ESTCI";
                    break;
                case TM.GCMotivosAnulacion:     //GANLD	Motivos de Anulación de Documentos
                    CodigoTabla = "GANLD";
                    break;
                case TM.GCTiposDeImpuestos:     //GCIMP	Impuestos de Gestión Comercial
                    CodigoTabla = "GCIMP";
                    break;
                case TM.GCDocumentosComproba:   //GCMPB	Comprobantes de Pago o Documentos
                    CodigoTabla = "GCMPB";
                    break;
                case TM.GCDestinoDeDocumentos:  //GDSTC	Destino de Comprobantes
                    CodigoTabla = "GDSTC";
                    break;
                case TM.GCTiposDeMovimiento:    //GMMOV	Tipos de Movimientos
                    CodigoTabla = "GMMOV";
                    break;
                case TM.GCMotivosDeLaGuiaRE:    //GMTGU	Motivos de la Guia de Remisión
                    CodigoTabla = "GMTGU";
                    break;
                case TM.ProducSectoresDeVenta:  //GSVTA	Sectores de Ventas
                    CodigoTabla = "GSVTA";
                    break;
                case TM.GCTiposDeMoneda:        //GTMND	Tipos de MONEDAS
                    CodigoTabla = "GTMND";
                    break;
                case TM.GCMotivosMovimiento:    //GTMOV	Motivos de Movimientos- TIPOS DE OPERACIONES
                    CodigoTabla = "GTMOV";
                    break;
                case TM.GCTurnosComerciales:    //GTURN	Turnos Comerciales
                    CodigoTabla = "GTURN";
                    break;
                case TM.PersonaTiposDomicilio:  //MTDOM	Tipos de Domicilios
                    CodigoTabla = "MTDOM";
                    break;
                case TM.PersonaAsignaciones:    //PASIG	Asignaciónes para Personas
                    CodigoTabla = "PASIG";
                    break;
                case TM.PersonaAtributos:       //PATRB	Atributos de Personas
                    CodigoTabla = "PATRB";
                    break;
                case TM.ProducAtributoParte:    //PATRI	Atributos de las Partes
                    CodigoTabla = "PATRI";
                    break;
                case TM.ProducCategorias:       //PCATE	Categoría de Productos
                    CodigoTabla = "PCATE";
                    break;
                case TM.ProducColores:          //PCLRP	Colores
                    CodigoTabla = "PCLRP";
                    break;
                case TM.CentroDeCostos:         //PCNTC	Centros de Costos
                    CodigoTabla = "PCNTC";
                    break;
                case TM.ProducionCentro:        //PCNTP	Centro de Producciónes
                    CodigoTabla = "PCNTP";
                    break;
                case TM.GastosAduaneros:        //GADUA	Gastos aduaneros
                    CodigoTabla = "GADUA";
                    break;
                case TM.ProducGarantias:        //PGRNT	Tipos de Garantia a Productos
                    CodigoTabla = "PGRNT";
                    break;
                case TM.ProducLineas:           //PLINE	Lineas de Productos
                    CodigoTabla = "PLINE";
                    break;
                case TM.ProducMateriales:       //PMATE	Materiales de Productos
                    CodigoTabla = "PMATE";
                    break;
                case TM.ProducUnidadMedida:     //PMEDI	Unidades de Medida
                    CodigoTabla = "PMEDI";
                    break;
                //case TM.ProducMarcas:           //PMRCA	Marcas y Modelos Registradas
                //    CodigoTabla = "PMRCA";
                //    break;
                case TM.ProducMetodosAlmac:     //PMTDA	Métodos de Almacenamiento
                    CodigoTabla = "PMTDA";
                    break;
                case TM.ProducPartes:           //PPART	Partes del Producto
                    CodigoTabla = "PPART";
                    break;
                case TM.PersonaProfesiones:     //PROFE	Profesiones de Empleados
                    CodigoTabla = "PROFE";
                    break;
                case TM.ProducSectoresAlmac:    //PSALM	Sectores de Almacenamiento
                    CodigoTabla = "PSALM";
                    break;
                case TM.ProducTipos:            //PTPRO	Tipo de Producto
                    CodigoTabla = "PTPRO";
                    break;
                case TM.PersonaRubrosComerc:    //RUBRC	Rubros Comerciales
                    CodigoTabla = "RUBRC";
                    break;
                case TM.PersonaGrupoSanguineo:  //PGRSN Grupos Sanguineos
                    CodigoTabla = "PGRSN";
                    break;
                case TM.TiposDeArchivos:        //TFILE	Tipos de Archivos
                    CodigoTabla = "TFILE";
                    break;
                case TM.TablaDePaises:         //UBIGE	UBIGEOS DE PAISES
                    CodigoTabla = "TPAIS";
                    break;
                case TM.SectoresZonasDeParqueo: //Sectores/Zonas de parqueo
                    CodigoTabla = "SCPQA";
                    break;
                case TM.TiposDeVehiculos:       // Tipos de Vehículos
                    CodigoTabla = "TVEHI";
                    break;
                case TM.GCEstadosLetraCambio:       // Estados de la letra de cambio
                    CodigoTabla = "ESTLC";
                    break;
                case TM.ProducEstadoMercaderia:
                    CodigoTabla = "PETMC";
                    break;
                case TM.ImportCanalAduana:      //IMACN	Importación - Tipo de Canal de Aduana
                    CodigoTabla = "IMACN";
                    break;
                case TM.ImportNacionalización:  //IMNCN	Importación - Tipo de Nacionalización
                    CodigoTabla = "IMNCN";
                    break;
                case TM.ImportTipoIncotermo:    //IMICT	Importación - Tipo de Incotermo
                    CodigoTabla = "IMICT";
                    break;
                case TM.ImportResCostoAduadero: //IMCST	Importación - Resumen de costos aduadero 
                    CodigoTabla = "IMCST";
                    break;
                case TM.TiposCuentasBancarias:  //TPCTA	Caja-Banco - Tipos de Cuentas Bancarias
                    CodigoTabla = "TPCTA";
                    break;
                case TM.TiposViasDomicilios:    //TVIDM	Personas - Tipos de vias para domicilios
                    CodigoTabla = "TVIDM";
                    break;
                case TM.TiposZonasNucleoUrbano: //TZNDM	Personas - Tipos de zonas/nucleos urbanos para domicilios
                    CodigoTabla = "TZNDM";
                    break;
                case TM.TiposPlazosDePago: //TZNDM	Personas - Tipos de zonas/nucleos urbanos para domicilios
                    CodigoTabla = "TPLAZ";
                    break;

            }
            return CodigoTabla;
        }

    }
}
