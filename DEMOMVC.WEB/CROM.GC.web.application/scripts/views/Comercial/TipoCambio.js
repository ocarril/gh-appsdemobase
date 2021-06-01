/***********************************************************************
Modulo	   : Gestion Comercial - Comercial
Método     : TipoCambio.js
Propósito  : Manejo de la pagina listado de TipoCambio
Se asume   : N/A
Efectos    : N/A
Notas      : N/A
Autor      : 
Fecha/Hora de Creación :
Modificado : N/A
Fecha/Hora : N/A
***********************************************************************/
$(document).ready(function () {

    $('#btnLimpiar').bind('click', function (event) {

        $('#dataForm').find('input[type=text], select').val('');
    });

    $('#btnBuscar').bind('click', function (event) {

        $.f_reloadGrid('gridEntidad');
    });

    $('#btnNuevo').bind('click', function (event) {

        $.f_redireccionarURL('/Comercial/TipoCambioReg?pID=-1');
    });

    $('#btnSalir').bind('click', function (event) {

        $.f_redireccionarURL('Home/Index/');
    });

    $.fnc_configuraGrillaEntidad();
    $.f_formatoFechas("txtfecInicio");
    $.f_formatoFechas("txtfecFinal");

    $('#txtfecInicio').val(moment($('#hddfecInicio').val(), "DD-MM-YYYY").format("DD-MM-YYYY"));
    $('#txtfecFinal').val(moment($('#hddfecFinal').val(), "DD-MM-YYYY").format("DD-MM-YYYY"));

});

/**********************************************************************
 Nombre: configuraGrilla
 Funcion: Configuración de grilla
**********************************************************************/
(function ($) {
    $.fnc_configuraGrillaEntidad = function () {
        'use strict'

        var gridWidth = window.screen.width * 0.9 - 55;
        $('[id*=gridEntidad]').jqGrid({
            width: gridWidth,
            autowidth: true,
            shrinkToFit: false,
            datatype: $.fnc_getDataEntidad,
            jsonReader:
            {
                root: "Items",
                page: "CurrentPage",
                total: "PageCount",
                records: "RecordCount",
                repeatitems: true,
                cell: "Row",
                id: "ID"
            },
            mtype: 'POST',
            colNames: ['', '', 'FECHA PROCESO', 'MONEDA', 'VALOR COMPRA', 'VALOR VENTA', 'ACTIVO', 'EDITADO POR', 'ACTUALIZADO EL'],
            colModel: [
                { name: '', index: '', width: 35, align: 'center', editable: false, formatter: $.fnc_formatEditEntidad, sortable: false, search: false },
                { name: '', index: '', width: 35, align: 'center', editable: false, formatter: $.fnc_formatDeleteEntidad, sortable: false, search: false },
                { name: 'fecProceso', index: 'fecProceso', editable: true, width: 110, align: 'center', search: false },
                { name: 'codRegMoneda', index: 'codRegMoneda', editable: true, width: 140, align: 'left', search: false },
                { name: 'monCompraGOB', index: 'monCompraGOB', editable: true, width: 120, align: 'center', search: false },
                { name: 'monVentaGOB', index: 'monVentaGOB', editable: true, width: 120, align: 'center', search: false },
                { name: 'Estado', index: 'Estado', width: 90, align: 'center', editable: false, formatter: $.fnc_formatEstadoRegistroAcIn, sortable: false, search: false },
                { name: 'UsuModi', index: 'UsuModi', editable: true, width: 140, align: 'left', search: false },
                { name: 'FeModi', index: 'FeModi', editable: true, width: 155, align: 'left', search: false }
            ],
            pager: 'pagerEntidad',
            pagerpos: "center",
            loadtext: 'Cargando datos...',
            recordtext: "{0} - {1} de {2}",
            emptyrecords: 'No se encontraron registros..',
            pgtext: 'Pág: {0} de {1}',
            rowNum: 10,
            rowList: [5,10, 20, 40, 80, 100],
            sortname: 'fecProceso',
            sortorder: "desc",
            viewrecords: true,
            caption: 'Resultados de la búsqueda',
            height: 'auto',
            rownumbers: true,
            altRows: true
        }).jqGrid('filterToolbar', { stringResult: true, searchOnEnter: true });

       
    }
})(jQuery);

 /**********************************************************************
  Nombre: $.fnc_getDataEntidad
  Funcion: Se dispara para realizar una petición de la data actualizada del jQGrid de la entidad
 ***********************************************************************/
(function ($) {
    $.fnc_getDataEntidad = function (postData) {
        'use strict'

        var strcodRegMoneda = $('#cboMonedas').val();
        var indActivo = document.getElementsByName("chkEstadoBus")[0].checked;
        var parametros = Object();
        parametros["jqPageSize"] = postData.rows;
        parametros["jqCurrentPage"] = postData.page;
        parametros["jqSortColumn"] = postData.sidx;
        parametros["jqSortOrder"] = postData.sord;

        parametros["fechaInicio"] = $('#txtfecInicio').val();
        parametros["fechaFinal"] = $('#txtfecFinal').val();
        parametros["codRegMoneda"] = strcodRegMoneda;
        parametros["indActivo"] = indActivo;

        var prmAjax = Object();
        prmAjax["url"] = '/Comercial/TipoCambioListar';
        prmAjax["data"] = JSON.stringify(parametros);
        prmAjax["ajaxMessage"] = 'Listando tipos de cambio...';
        prmAjax["success"] = $.fnc_getDataEntidadSuccess;

        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_getDataEntidadSuccess
 Funcion: Función callback luego de solicitar data para el jQGrid de la entidad
 **********************************************************************/
(function ($) {
    $.fnc_getDataEntidadSuccess = function (response, status) {
        'use strict'

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == 'E')
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == 'I')
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == 'C') {
                $("#gridEntidad")[0].addJSONData(mensaje);
                $.fnc_AjustarJQGrid('gridEntidad', 'divLista');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/***********************************************************************
  Nombre: $.fnc_formatEditEntidad
  Funcion: Formatea columna de edición de la grilla entidad
************************************************************************/
(function ($) {
    $.fnc_formatEditEntidad = function (cellvalue, options, rowObject) {
        'use strict'

        var srcImage = '../Content/Images/imgEditar.svg';
        var image;
        image = "<a href='#' onclick=\"$.fnc_editEntidad('" + options.rowId + "');\"><img title='Editar'   src='" + srcImage +
            "' border='0' style='height:22px;'   id='imgEditarEntidad' /></a>";
        return image;
    }
})(jQuery);

/***********************************************************************
Nombre: $.fnc_formatDeleteEntidad 
Funcion: Formatea columna de eliminación de la grilla de ENTIDAD
************************************************************************/
(function ($) {
    $.fnc_formatDeleteEntidad = function (cellvalue, options, rowObject) {
        'use strict'

        var srcImage = '../Content/Images/icoEliminar.png';
        var image;
        image = "<a href='#' onclick=\"$.fnc_deleteEntidad('" + options.rowId + "');\"><img title='Eliminar' src='" + srcImage + "' border='0' id='imgEliminarEntidad' /></a>";
        return image;
    }
})(jQuery);


/**********************************************************************
 Nombre: $.fnc_editEntidad
 Funcion: Se dispara cuando se hace click sobre el ícono editar de la grilla 
**********************************************************************/
(function ($) {
    $.fnc_editEntidad = function (pID) {
        'use strict'

        $.f_redireccionarURL('/Comercial/TipoCambioReg?pID=' + pID);
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_deleteEntidad
Funcion: Se dispara cuando se hace click sobre el ícono eliminar de la grilla
**********************************************************************/
(function ($) {
    $.fnc_deleteEntidad = function (pID) {
    'use strict'

        var mensajeOK = new CROMMessageBox({
            contenido: '¿Está seguro de eliminar registro seleccionado?',
            tipo: 4,
            botones: [
                    {
                        Etiqueta: "Aceptar",
                        Click: function () { 
                                var paramAjax = {};
                                paramAjax['url'] = '/Comercial/TipoCambioEliminar?pID=' + pID;
                                paramAjax['ajaxMessage'] = 'Eliminando registro seleccionado...';
                                paramAjax['success'] = $.fnc_deleteEntidadSuccess; /*Función callback*/
                                $.f_ajaxRespuesta(paramAjax);
                        }
                    },
                    {
                        Etiqueta: "Cancelar"
                    }]
        });
        mensajeOK.Mostrar();
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_deleteEntidadSuccess
Funcion: Función callback luego de solicitar la eliminación de un registro 
**********************************************************************/
(function ($) {
    $.fnc_deleteEntidadSuccess = function (response, status) {
    'use strict'

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == "C") {
                $.f_Mensaje(mensaje, true, true, 3);
                $.f_reloadGrid('gridEntidad');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);
