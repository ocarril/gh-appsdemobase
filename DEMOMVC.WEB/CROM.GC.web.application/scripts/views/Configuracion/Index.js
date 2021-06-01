/***********************************************************************
Modulo	   : Gestion Configuración - Config
Método     : Index.js
Propósito  : Manejo de la pagina listado de valores de Configuracion
Se asume   : N/A
Efectos    : N/A
Notas      : N/A
Autor      : 
Fecha/Hora de Creación : 
Modificado : N/A
Fecha/Hora : N/A
***********************************************************************/
$(document).ready(function () {
    'use strict';

    $('#btnLimpiar').bind('click', function (event) {
        $('#dataForm').find('input[type=text], select').val('');
    });

    $('#btnBuscar').bind('click', function (event) {
        $.f_reloadGrid('gridConfig');
    });

    $('#btnSalir').bind('click', function (event) {

        $.f_redireccionarURL('Home/Index/');
    });

    $.configuraGridConfig();

    $.fnc_AplicarSeguridadControl($('#hddnomController').val(), $('#hddnomAction').val(), true);
});

/**********************************************************************
Nombre: configuraGridConfig
Funcion: Configuración de grilla
**********************************************************************/
(function ($) {
    $.configuraGridConfig = function () {
        var gridWidth = window.screen.width * 0.9 - 55;
        $('[id*=gridConfig]').jqGrid({
            width: gridWidth,
            autowidth: true,
            shrinkToFit: false,
            datatype: $.getDataConfig,
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
            colNames: ['', 'ORDEN', 'KEY-CONFIG.', 'VALOR', 'N° NIVEL', 'NOMBRE', 'GRUPO', 'ACTIVO', 'EDITADO EL ', 'EDITADO POR'],
            colModel: [
                { name: '', index: '', width: 40, align: 'center', editable: false, formatter: $.formatEditar, sortable: false, search: false},
                { name: 'indOrden', index: 'indOrden', editable: true, width: 50, align: 'center', search: false},
                { name: 'codKeyConfig', index: 'codKeyConfig', width: 225, align: 'left', editable: false, search: true },
                { name: 'desValor', index: 'desValor', width: 300, align: 'left', editable: false, search: true },
                { name: 'numNivel', index: 'numNivel', width: 70, align: 'center', editable: false, search: false },
                { name: 'desNombre', index: 'desNombre', editable: true, width: 450, align: 'left', search: true },
                { name: 'desGrupo', index: 'desGrupo', editable: true, width: 90, align: 'left', search: true },
                { name: 'indActivo', index: 'indActivo', width: 90, align: 'center', editable: false, formatter: $.fnc_formatEstadoRegistroAcIn, sortable: false, search: false },
                { name: 'segFechaEdita', index: 'segFechaEdita', editable: true, width: 150, align: 'left', search: false},
                { name: 'segUsuarioEdita', index: 'segUsuarioEdita', editable: true, width: 160, align: 'left', search: false}
                ],
            pager: 'pagerConfig',
            pagerpos: "center",
            loadtext: 'Cargando datos...',
            recordtext: "{0} - {1} de {2}",
            emptyrecords: 'No se encontraron registros..',
            pgtext: 'Pág: {0} de {1}',
            rowNum: 10,
            rowList: [5,10, 20, 40, 80],
            sortname: 'indOrden',
            sortorder: "asc",
            viewrecords: true,
            caption: 'Resultados de la búsqueda',
            height: 'auto',
            rownumbers: true,
            altRows: true,
            gridComplete: function () {

                $.fnc_AplicarSeguridadControl($('#hddnomController').val(), $('#hddnomAction').val(), true);
            }
        }).jqGrid('filterToolbar', { stringResult: true, searchOnEnter: true });

    }
})(jQuery);

/***********************************************************************
Nombre: $.formatEditar 
Funcion: Formatea columna de eliminación de la grilla de DOCUMENTO
************************************************************************/
(function ($) {
    $.formatEditar = function (cellvalue, options, rowObject) {
        var srcImage = '../Content/Images/imgEditar.svg';
        var image;
        var strhidden = "hidden";
        image = "<a href='#' onclick=\"$.fnu_EditarRegistro('" + options.rowId + "');\"><img title='Editar Config' src='" + srcImage +
            "' border='0' id='imgEditarConfig' class='" + strhidden + "' style='height:22px;'   /></a>";
        return image;
    }
})(jQuery);

/**********************************************************************
  Nombre: $.getDataConfig
  Funcion: Se dispara para realizar una petición de la data actualizada 
           del jQGrid de Datos
 ***********************************************************************/
(function ($) {
    $.getDataConfig = function (postData) {
        'use strict';

        // Leer los datos para la petición

        var parametros = Object();
        parametros["jqPageSize"] = postData.rows;
        parametros["jqCurrentPage"] = postData.page;
        parametros["jqSortColumn"] = postData.sidx;
        parametros["jqSortOrder"] = postData.sord;

        parametros["codKeyConfig"] = $('#gs_codKeyConfig').val();
        parametros["desNombre"] = $('#gs_desNombre').val();
        parametros["desValor"] = $('#gs_desValor').val();
        parametros["codTabla"] = $('#gs_desGrupo').val();
        parametros["indActivo"] = document.getElementsByName("chkindActivo_prm")[0].checked;

        var paramAjax = Object();
        paramAjax["ajaxMessage"] = 'Listando valores de configuración...';
        paramAjax["url"] = '/Configuracion/ListarConfig';
        paramAjax["data"] = JSON.stringify(parametros);
        paramAjax["error"] = $.f_ajaxRequestFailed;
        paramAjax["success"] = function (response, status) {  /* Función callback */
            if (status == 'success') {
                var tipo = response.Type;
                var mensaje = response.Data;
                if (tipo == "E")
                    $.f_Mensaje(mensaje, false, true, 1);
                else if (tipo == "I")
                    $.f_Mensaje(mensaje, false, true, 1);
                else
                    $.getDataConfigSuccess(response, status);
            }
            else
                $.f_Mensaje(response.responseText, false, true, 1);
        }

        $.f_ajaxRespuesta(paramAjax);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.getDataConfigSuccess
 Funcion: Función callback luego de solicitar data para el jQGrid
 **********************************************************************/
(function ($) {
    $.getDataConfigSuccess = function (response, status) {
        'use strict';

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == 'E')
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == 'I')
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == 'C') {
                $("#gridConfig")[0].addJSONData(mensaje);
                $.fnc_AjustarJQGrid('gridConfig', 'divLista');
            }
        }
    }
})(jQuery);

/*******************************************************
Pantalla POPUP para editar registro de CONFIGURACION
********************************************************/
(function ($) {
    $.fnu_EditarRegistro = function (pID) {
        'use strict';

        $.f_redireccionarURL('/Configuracion/IndexReg' + '?pID=' + pID);
    };

})(jQuery);

