/***********************************************************************
Modulo		: Gestion Comercial - Comercial
Método     : DocumentoEstado.js
Propósito  : Manejo de la pagina listado de Documento Estado
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

    $("#btnNuevo").click(function () {

        $.fnc_newEntidad();
    });

    $('#btnBuscar').bind('click', function (event) {
        $.f_reloadGrid('gridEstados');
    });

    $("#cboDocumentos").change(function () {

        $.f_reloadGrid('gridEstados');
    });

    $("#cboEstados").change(function () {

        $.f_reloadGrid('gridEstados');
    });

    $("#btnEliminar").click(function () {

        var chkSeleccionados = $(".check-box");
        var lstDocumentoEstado = [];
        var codigosSeleccionado = '';
        for (i = 0; i < chkSeleccionados.length; i++) {
            if (chkSeleccionados[i].checked == true) {
                var codDato = chkSeleccionados[i].value;
                lstDocumentoEstado.push({ codDocumentoEstado: codDato });
                codigosSeleccionado = codigosSeleccionado + ',' + codDato;
            }
        }
        if (lstDocumentoEstado.length == 0) {
            $.f_Mensaje('¡No ha seleccionado ningun registro a eliminar.!', false, true);
            return false;
        }
        var mensajeOK = new CROMMessageBox({
            contenido: "¿Confirma la eliminación de los registros seleccionados?",
            tipo: 4,
            botones: [
                    {
                        Etiqueta: "Aceptar",
                        Click: function () { fnc_EliminarDocumentoEstado(lstDocumentoEstado); }
                    },
                    {
                        Etiqueta: "Cancelar"
                    }]
        });
        mensajeOK.Mostrar();

    });

    $('#btnSalir').bind('click', function (event) {

        $.f_redireccionarURL('Home/Index/');
    });

    $.configuraGridEstados();

    $.fnc_AplicarSeguridadControl($('#hddnomController').val(), $('#hddnomAction').val(), true);
});

/**********************************************************************
Nombre: configuraGrilla
Funcion: Configuración de grilla
**********************************************************************/
(function ($) {
    $.configuraGridEstados = function () {
        'use strict';

        var gridWidth = window.screen.width * 0.9 - 55;
        $('[id*=gridEstados]').jqGrid({
            width: gridWidth,
            autowidth: true,
            shrinkToFit: false,
            datatype: $.getDataDocumentoEstado,
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
            colNames: ['EDITAR', 'ELIMINAR','ACTIVO', 'DOCUMENTO','COLOR', 'ESTADO','Nº ORDEN', 'FECHA EDICIÓN', 'USUARIO EDICIÓN', '','' ],
            colModel: [
                { name: 'Editar', index: 'Editar', width: 75, align: 'center', editable: false, formatter: $.fnc_formatEditarEstado, sortable: false, search: false},
                { name: 'Eliminar', index: 'Eliminar', width: 75, align: 'center', editable: false, formatter: $.fnc_formatEliminarEstado, sortable: false, search: false},
                { name: 'indActivo', index: 'indActivo', width: 90, align: 'center', editable: false, formatter: $.fnc_formatEstadoRegistroAcIn, sortable: false, search: false },
                { name: 'codRegDocumentoDesc', index: 'codRegDocumentoDesc', editable: true, width: 240, align: 'left', search: false},
                { name: 'codRegEstadoDesc', index: 'codRegEstadoDesc', editable: true, width: 180, align: 'left', search: false},
                { name: 'codRegEstadoColor', index: 'codRegEstadoColor', editable: true, width: 110, align: 'left', search: false },
                { name: 'codEstado', index: 'codEstado', editable: true, width: 75, align: 'center', search: false},
                { name: 'fechaEditas', index: 'fechaEditas', editable: true, width: 150, align: 'left', search: false},
                { name: 'usuarioEdita', index: 'usuarioEdita', editable: true, width: 135, align: 'left', search: false},
                { name: 'codRegDocumento', index: 'codRegDocumento', editable: true, width: 50, align: 'right', hidden: true, search: false },
                { name: 'codRegEstado', index: 'codRegEstado', editable: true, width: 50, align: 'right', hidden: true, search: false}

            ],
            pager: 'pagerEstados',
            pagerpos: "center",
            loadtext: 'Cargando datos...',
            recordtext: "{0} - {1} de {2}",
            emptyrecords: 'No hay registros',
            pgtext: 'Pág: {0} de {1}',
            rowNum: 10,
            rowList: [5, 10, 20, 40, 80, 100],
            sortname: 'auxcodRegDocumento',
            sortorder: "asc",
            viewrecords: true,
            caption: 'Resultados de la búsqueda',
            height: 'auto',
            rownumbers: true,
            altRows: true,
            multiselect: true,
            gridComplete: function (data) {
                var rows = $("#gridEstados").getDataIDs();
                var gridData = $('#gridEstados').jqGrid('getRowData');
                var countCols = jQuery('#gridEstados').jqGrid('getGridParam', 'colModel');
                for (var i = 0; i < rows.length; i++) {
                    var statusColor = $("#gridEstados").getCell(rows[i], "codRegEstadoColor");
                    $("#gridEstados").jqGrid('setCell', rows[i], "codRegEstadoColor", "", { background: statusColor });
                }
                $.fnc_AplicarSeguridadControl($('#hddnomController').val(), $('#hddnomAction').val(), true);
            }
        }).jqGrid('filterToolbar', { stringResult: true, searchOnEnter: true });
    }
})(jQuery);

/***********************************************************************
Nombre: $.fnc_formatEditarEstado 
Funcion: Formatea columna de edición de la grilla de ESTADOS de documentos
************************************************************************/
(function ($) {
    $.fnc_formatEditarEstado = function (cellvalue, options, rowObject) {
        'use strict';

        var srcImage = '../Content/Images/imgEditar.svg';
        var image;
        var strhidden = "hidden";
        image = "<a href='#' onclick=\"$.fnc_EditEstado('" + options.rowId + "');\"><img title='Editar estado' src='" + srcImage + "' border='0' style='height:22px;'   id='imgEditarDocumentoEstado'  class='" + strhidden +"' /></a>";
        return image;
    }
})(jQuery);

/***********************************************************************
Nombre: $.fnc_formatEliminarEstado 
Funcion: Formatea columna de eliminación de la grilla de ESTADOS de documentos
************************************************************************/
(function ($) {
    $.fnc_formatEliminarEstado = function (cellvalue, options, rowObject) {
        'use strict';

        var srcImage = '../Content/Images/icoEliminar.png';
        var image;
        var strhidden = "hidden";
        image = "<a href='#' onclick=\"$.fnc_EliminarEstadoSel('" + options.rowId + "');\"><img title='Eliminar estado de documento' src='" + srcImage + "' border='0' id='imgEliminarEstadoDocumento' class='" + strhidden +"'  /></a>";
        return image;
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_EliminarEstadoSel
Funcion: Se dispara cuando se hace click sobre el ícono eliminar de la grilla
**********************************************************************/
(function ($) {
    $.fnc_EliminarEstadoSel = function (correlativoID) {
        'use strict'

        var lstDocumentoEstado = [];
        var codigosSeleccionado = '';
        lstDocumentoEstado.push({ codDocumentoEstado: correlativoID });
        codigosSeleccionado = codigosSeleccionado + ',' + String(correlativoID);
        var mensajeOK = new CROMMessageBox({
            contenido: '¿Está seguro de eliminar registro de estado de documento?',
            tipo: 4,
            botones: [
                    {
                        Etiqueta: "Aceptar",
                        Click: function () {
                            var paramAjax = {};
                            paramAjax['url'] = '/Comercial/DocumentoEstadoEliminar';
                            paramAjax["data"] = JSON.stringify(lstDocumentoEstado),
                            paramAjax['ajaxMessage'] = 'Eliminando registro de la entidad';
                            paramAjax['success'] = $.fnc_EliminarEstadoSuccess; /*Función callback*/
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
Nombre: $.fnc_EliminarEstadoSuccess
Funcion: Función callback luego de solicitar la eliminación de un registro 
**********************************************************************/
(function ($) {
    $.fnc_EliminarEstadoSuccess = function (response, status) {
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
                $.f_reloadGrid('gridEstados');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_newEntidad
 Funcion: Se dispara cuando se hace click sobre el ícono editar de la grilla 
**********************************************************************/
(function ($) {
    $.fnc_newEntidad = function () {
        'use strict'

        var prmAjax = {};
        prmAjax["url"] = '/Comercial/DocumentoEstadoBuscar?pID=0';
        prmAjax["ajaxMessage"] = 'Nuevo registro...';
        prmAjax["success"] = $.fnc_newEntidadSuccess;
        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_newEntidadSuccess
 Funcion: Función callback luego de solicitar un registro para nuevo
**********************************************************************/
(function ($) {
    $.fnc_newEntidadSuccess = function (response, status) {
        'use strict'

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == "C") {
                $.fnc_mostrarDatosEntidad(response);
                $.fnc_showDialogEstado();
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_EditEstado
 Funcion: Se dispara cuando se hace click sobre el ícono editar de la grilla 
**********************************************************************/
(function ($) {
    $.fnc_EditEstado = function (correlativoID) {
        'use strict'

        var prmAjax = {};
        prmAjax["url"] = '/Comercial/DocumentoEstadoBuscar?pID=' + correlativoID;
        prmAjax["ajaxMessage"] = 'Obteniendo datos del registro...';
        prmAjax["success"] = $.fnc_EditEstadoSuccess;
        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

//**********************************************************************
// Nombre: $.fnc_EditEstadoSuccess
// Funcion: Función callback luego de solicitar un registro para edición
//**********************************************************************
(function ($) {
    $.fnc_EditEstadoSuccess = function (response, status) {
        'use strict';

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;

            if (tipo == "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == "C") {
                $.fnc_mostrarDatosEntidad(response);
                $.fnc_showDialogEstado();
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true, 1);
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_mostarDatosEntidad
Funcion: Muestra los datos en los controles de un registro de ESTADO
**********************************************************************/
(function ($) {
    $.fnc_mostrarDatosEntidad = function (response) {
        'use strict';

        var jsonData = response.Data;
        var documentos = response.Documentos;
        var estados = response.Estados;
        var registroID = jsonData.codDocumentoEstado;

        $('#hddcodDocumentoEstado').val(registroID);
        $('#chkindActivo').attr('checked', jsonData.indActivo );

        $('#txtsegUsuarioEdita').val(jsonData.usuarioEdita);
        $('#txtsegFechaEdita').val(jsonData.fechaEditas);
        $('#txtcodEstado').val(jsonData.codEstado);

        $.f_loadComboFromArray(documentos, 'cboDocumentoReg', true, jsonData.codRegDocumento, false);
        $.f_loadComboFromArray(estados, 'cboEstadoReg', true, jsonData.codRegEstado, false);

        $('#txtsegUsuarioEdita').attr('disabled', true);
        $('#txtsegFechaEdita').attr('disabled', true);

    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_showDialogEstado
 Funcion: Visualiza diálogo para registro o edición de un ESTADO
**********************************************************************/
(function ($) {
    $.fnc_showDialogEstado = function () {
        'use strict';

        var divID = 'popupVentana';
        var modal = true;
        var title = 'Estado de documento';
        var width = 'auto';
        var height = null;
        var draggable = true;
        var resizable = false;
        var buttons = {
            "Grabar": function () {
                $.fnc_grabarEstado(this);
            },
            "Cancelar": function () {
                $(this).dialog('close');
            }
        };

        $.f_dialog_open_noButtons(divID, modal, title, width, height, draggable, resizable).dialog({ buttons: buttons })
        .dialog({
            beforeClose: function (event, ui) {
                $('#popupVentana').find(':text, select').val('');  // Limpiar campos del popup
            }
        });
        $.f_dialogCssApply(divID);

    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_grabarEstado
 Funcion: Invocada por el controlador de evento click del botón aplicar del popup carga de ESTADOS
**********************************************************************/
(function ($) {
    $.fnc_grabarEstado = function (context) {
        'use strict';

        var entidad = $.fnc_validarEntidad(context);
        if (entidad.msjValidacion != '' && entidad.msjControl != '') {
            $.f_Mensaje(entidad.msjValidacion, false, true);
            $('#' + entidad.msjControl).focus();
            return;
        }
        else {
            var parametro = {};
            parametro['url'] = '/Comercial/DocumentoEstadoGuardar';
            parametro['data'] = JSON.stringify(entidad);
            parametro['ajaxMessage'] = 'Guardando documento estado...';
            parametro['success'] = $.fnc_grabarEstadoSuccess; /*Función callback*/
            $.f_ajaxRespuesta(parametro);

        }
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_grabarEstadoSuccess
Funcion: Invocada por el controlador de evento click del botón Guardar
**********************************************************************/
(function ($) {
    $.fnc_grabarEstadoSuccess = function (response, status) {
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
                $.f_reloadGrid('gridEstados');
                $('#popupVentana').dialog('close');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_validarEntidad
Funcion: Invocada por el metodo guardar para validar los datos
**********************************************************************/
(function ($) {
    $.fnc_validarEntidad = function (context) {
        'use strict'

        var vcodDocumentoEstado = $('#hddcodDocumentoEstado').val();
        var vcboDocumentoReg = $('#cboDocumentoReg').val();
        var vcboEstadoReg = $('#cboEstadoReg').val();
        var vindActivo = document.getElementsByName("chkindActivo")[0].checked;
        var vcodEstado = $('#txtcodEstado').val();
        var idFocusControl = '';
        var msg = '';

        if (vcboDocumentoReg == '') {
            msg += '- Debe seleccionar tipo de documento <BR>';
            if (idFocusControl == '') idFocusControl = 'cboDocumentoReg';
        }
        if (vcboEstadoReg == '') {
            msg += '- Debe seleccionar el estado <BR>';
            if (idFocusControl == '') idFocusControl = 'cboEstadoReg';
        }

        if (msg != '' && idFocusControl != '') {
            $.f_Mensaje(msg, false, true);
            $('#' + idFocusControl).focus();
            return;
        }

        var pEntidad = {};
        pEntidad['codDocumentoEstado'] = vcodDocumentoEstado;
        pEntidad['codRegDocumento'] = vcboDocumentoReg;
        pEntidad['codRegEstado'] = vcboEstadoReg;
        pEntidad['codEstado'] = vcodEstado;
        pEntidad['indActivo'] = vindActivo;
        
        pEntidad['msjValidacion'] = msg;
        pEntidad['msjControl'] = idFocusControl;

        return pEntidad;
    }
})(jQuery);


(function ($) {
    $.fnu_MostrarValor = function (newValor) {
        'use strict';

        var codTabla = $('#txtcodEstado').val();
        document.getElementById("valLongitud").innerHTML = newValor;

    }
})(jQuery);


/**********************************************************************
  Nombre: $.getDataDocumentoEstado
  Funcion: Se dispara para realizar una petición de la data actualizada 
           del jQGrid de Datos
 ***********************************************************************/
(function ($) {
    $.getDataDocumentoEstado = function (postData) {
        'use strict';

        // Leer los datos para la petición
        var codDocumento = $('#cboDocumentos').val();
        var codEstado = $('#cboEstados').val();
        
        var parametros = Object();
        parametros['jqPageSize'] = postData.rows;
        parametros['jqCurrentPage'] = postData.page;
        parametros['jqSortColumn'] = postData.sidx;
        parametros['jqSortOrder'] = postData.sord;
        parametros['codRegDocumento'] = codDocumento;
        parametros['codRegEstado'] = codEstado;
        
        var paramAjax = {};
        paramAjax["ajaxMessage"] = 'Listando estados de los documentos...';
        paramAjax["url"] = '/Comercial/DocumentoEstadoListar';
        paramAjax["data"] = JSON.stringify(parametros);
        paramAjax["error"] = $.f_ajaxRequestFailed;
        paramAjax["success"] = function (response, status) {  /* Función callback */
            if (status == 'success') {
                var tipo = response.Type;
                var mensaje = response.Data;
                if (tipo == "E")
                    $.$.f_Mensaje(mensaje, false, true, 1);
                else if (tipo == "I")
                    $.f_Mensaje(mensaje, false, true, 1);
                else
                    $.getDataDocumentoEstadoSuccess(response, status);
            }
            else
                $.f_Mensaje(response.responseText, false, true, 1);
        }

        $.f_ajaxRespuesta(paramAjax);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.getDataDocumentoEstadoSuccess
 Funcion: Función callback luego de solicitar data para el jQGrid de DocumentoEstado
 **********************************************************************/
(function ($) {
    $.getDataDocumentoEstadoSuccess = function (response, status) {
        'use strict';

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == 'E')
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == 'I')
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == 'C') {
                $("#gridEstados")[0].addJSONData(mensaje);
                $.fnc_AjustarJQGrid('gridEstados', 'divLista');
            }
        }
    }
})(jQuery);

/**********************************************************************
Nombre: fnc_EliminarDocumentoEstado
Funcion: Funcion para eliminar registros de docuemnto estado
**********************************************************************/
(function ($) {
    $.fnc_EliminarDocumentoEstado = function (lstDocumentoEstado) {
        'use strict';

        var paramAjax = {};
        paramAjax["ajaxMessage"] = 'Eliminando registro de la tabla documento estado...';
        paramAjax["url"] = '/Comercial/DocumentoEstadoEliminar',
        paramAjax["data"] = JSON.stringify(lstDocumentoEstado),
        paramAjax["success"] = function (response, status) {
            if (status == 'success') {
                var tipo = response.Type;
                var mensaje = response.Data;
                if (tipo == "E")
                    $.f_Mensaje(mensaje, false, true, 1);
                else if (tipo == "I")
                    $.f_Mensaje(mensaje, false, true);
                else if (tipo == "C") {
                    $.f_Mensaje(mensaje, true, true, 3);
                    $.f_reloadGrid('gridEstados');
                }
            }
            else
                $.f_Mensaje(response.responseText, false, true);
        }
        $.f_ajaxRespuesta(paramAjax);

    }
})(jQuery);
