/***********************************************************************
Modulo	   : Gestion Comercial - Comercial
Método     : TipoCambioReg.js
Propósito  : Manejo de la pagina registro de TipoCambio
Se asume   : N/A
Efectos    : N/A
Notas      : N/A
Autor      : 
Fecha/Hora de Creación : 
Modificado : N/A
Fecha/Hora : N/A
***********************************************************************/
$(document).ready(function () {

    $('#btnGuardar').bind('click', function (event) {

        $.fnc_guardarEntidad();
    });

    $('#btnRegresar').bind('click', function (event) {

        $.f_redireccionarURL('/Comercial/TipoCambio');
    });

    $('#btnObtenerUltimo').bind('click', function (event) {

        $.fnu_MostrarUltimoRegistroTipoCambio();
    });
    
    $('#txtmonVentaGOB,#txtmonCompraGOB').bind('blur', function (event) {


        var monVentaGOB = $('#txtmonVentaGOB').val() == '' ? '0.00' : $('#txtmonVentaGOB').val();
        var monVentaPRL = $('#txtmonVentaPRL').val() == '' ? '0.00' : $('#txtmonVentaPRL').val();
        var monCompraGOB = $('#txtmonCompraGOB').val() == '' ? '0.00' : $('#txtmonCompraGOB').val();
        var monCompraPRL = $('#txtmonCompraPRL').val() == '' ? '0.00' : $('#txtmonCompraPRL').val();

        if (parseFloat(monVentaPRL) <= 0)
            $('#txtmonVentaPRL').val(monVentaGOB);
        if (parseFloat(monCompraPRL) <= 0)
            $('#txtmonCompraPRL').val(monCompraGOB);

        console.log('txtmonCompraPRL: ', monCompraGOB);

    });
    var vcodTipoCambio = $('#hddcodTipoCambio').val();
    console.log('vcodTipoCambio: ', vcodTipoCambio);

    $.fnu_MostrarRegistro(vcodTipoCambio);
    $.f_formatoFechas("txtfecProceso");

    $('#txtfecProceso').val(moment($('#txtfecProceso').val(), "DD-MM-YYYY").format("DD-MM-YYYY"));
});

/**********************************************************************
 Nombre: $.fnu_MostrarRegistro
 Funcion: Se dispara cuando se hace click sobre el ícono editar de la grilla 
**********************************************************************/
(function ($) {
    $.fnu_MostrarRegistro = function (pID) {
    'use strict'
            
            var prmAjax = {};
            prmAjax["url"] = '/Comercial/TipoCambioBuscar?pID=' + pID;
            prmAjax["ajaxMessage"] = 'Obteniendo datos del registro...';
            prmAjax["success"] = $.fnu_MostrarRegistroSuccess;
            $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnu_MostrarRegistroSuccess
 Funcion: Función callback luego de solicitar un registro para edición
**********************************************************************/
(function ($) {
    $.fnu_MostrarRegistroSuccess = function (response, status) {
        'use strict'

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == "C") {
                $.fnc_mostrarDatos(response);
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnu_MostrarUltimoRegistroTipoCambio
 Funcion: Se dispara cuando se hace click sobre el ícono editar de la grilla 
**********************************************************************/
(function ($) {
    $.fnu_MostrarUltimoRegistroTipoCambio = function () {
        'use strict'


        var uriURL = '?pTipoMND=GTMND002';
        $.f_ajaxRespuestasApi('commercial/exchangerate/findlastdate' + uriURL, null,
            function (response, status) {
                'use strict'

                if (status == 'success') {

                    console.log('response: ', response);

                    $('#txtmonCompraGOB').val(response.monCompraGOB.toFixed(3));
                    $('#txtmonVentaGOB').val(response.monVentasGOB.toFixed(3));
                    $('#txtmonCompraPRL').val(response.monCompraPRL.toFixed(3));
                    $('#txtmonVentaPRL').val(response.monVentasPRL.toFixed(3));

                    $('#txtfecProcesoUltimo').val(moment(response.fecProceso, "DD-MM-YYYY").format("DD-MM-YYYY"));
                }
            }, 'Obteniendo los valores del último tipo de cambio registrado...', 'GET',

        );

    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_mostrarDatos
Funcion: Muestra los datos en los controles de un registro de la entidad
**********************************************************************/
(function ($) {
    $.fnc_mostrarDatos = function (response) {
    'use strict'

        var jsonData = response.Data;
        var registroID = jsonData.codTipoCambio;
        var monedas = response.Monedas;
        $('#hddcodTipoCambio').val(registroID);
        $('#txtfecProceso').val(moment(jsonData.fecProceso, "DD-MM-YYYY").format("DD-MM-YYYY"));
        $('#txtmonCompraGOB').val(jsonData.monCompraGOB);
        $('#txtmonVentaGOB').val(jsonData.monVentaGOB);
        $('#txtmonCompraPRL').val(jsonData.monCompraPRL);
        $('#txtmonVentaPRL').val(jsonData.monVentaPRL);
        $('#chkEstado').attr('checked', jsonData.Estado=='1'? true:false);
        $('#txtUsumodi').val(jsonData.UsuModi);
        $('#txtFemodi').val(jsonData.FeModi);
        $.f_loadComboFromArray(monedas, 'cbocodRegMoneda', true,
            jsonData.codRegMoneda == undefined ? response.codRegMonedaExt : jsonData.codRegMoneda, false);
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_guardarEntidad
Funcion: Invocada por el controlador de evento click del botón Guardar
**********************************************************************/
(function ($) {
    $.fnc_guardarEntidad = function () {
        'use strict'

        var entidad = $.fnc_validarEntidad();
        if (entidad.msjValidacion != '' && entidad.msjControl != '') {
            $.f_Mensaje(entidad.msjValidacion, false, true);
            $('#' + entidad.msjControl).focus();
            return;
        }
        else {
            var parametro = {};
            parametro['url'] = '/Comercial/TipoCambioGuardar';
            parametro['data'] = JSON.stringify(entidad);
            parametro['ajaxMessage'] = 'Guardando datos de la entidad...';
            parametro['success'] = $.fnc_guardarEntidadSuccess; /*Función callback*/
            $.f_ajaxRespuesta(parametro);
        }
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_validarEntidad
Funcion: Invocada por el metodo guardar para validar los datos
**********************************************************************/
(function ($) {
    $.fnc_validarEntidad = function () {
        'use strict'

        var codTipoCambio = $('#hddcodTipoCambio').val();
        var fecProceso = $('#txtfecProceso').val();
        var codRegMoneda = $('#cbocodRegMoneda').val() == null ? '' : $('#cbocodRegMoneda').val();
        var monVentaGOB = $('#txtmonVentaGOB').val() == '' ? '0.00' : $('#txtmonVentaGOB').val();
        var monCompraGOB = $('#txtmonCompraGOB').val() == '' ? '0.00' : $('#txtmonCompraGOB').val();
        var monVentaPRL = $('#txtmonVentaPRL').val() == '' ? '0.00' : $('#txtmonVentaPRL').val();
        var monCompraPRL = $('#txtmonCompraPRL').val() == '' ? '0.00' : $('#txtmonCompraPRL').val();
        var Estado = document.getElementsByName("chkEstado")[0].checked;

        var idFocusControl = '';
        var msg = '';
        if (fecProceso == '') {
            msg += '- Seleccionar fecha de proceso. <br>';
            if (idFocusControl == '') idFocusControl = 'txtfecProceso';
        }
        if (codRegMoneda == '') {
            msg += '- Seleccionar tipo de moneda. <br>';
            if (idFocusControl == '') idFocusControl = 'cbocodRegMoneda';
        }
        if (parseFloat(monVentaGOB) <= 0) {
            msg += '- Ingresar tipo de venta mayor que cero. <br>';
            if (idFocusControl == '') idFocusControl = 'txtmonVentaGOB';
        }
        if (parseFloat(monCompraGOB) <= 0) {
            msg += '- Ingresar tipo de compra mayor que cero. <br>';
            if (idFocusControl == '') idFocusControl = 'txtmonCompraGOB';
        }
        var pEntidad = {};
        pEntidad['codTipoCambio'] = codTipoCambio;
        pEntidad['FechaProceso'] = fecProceso;
        pEntidad['CodigoArguMoneda'] = codRegMoneda;
        pEntidad['CambioVentasGOB'] = monVentaGOB;
        pEntidad['CambioCompraGOB'] = monCompraGOB;
        pEntidad['CambioVentasPRL'] = monVentaPRL;
        pEntidad['CambioCompraPRL'] = monCompraPRL;
        pEntidad['Estado'] = Estado;

        pEntidad['msjValidacion'] = msg;
        pEntidad['msjControl'] = idFocusControl;
        return pEntidad;
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_guardarEntidadSuccess
Funcion: Invocada por el controlador de evento click del botón Guardar
**********************************************************************/
(function ($) {
    $.fnc_guardarEntidadSuccess = function (response, status) {
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
                $.f_redireccionarURL('/Comercial/TipoCambio');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);
