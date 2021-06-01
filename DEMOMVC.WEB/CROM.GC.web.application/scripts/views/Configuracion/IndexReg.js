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

    //$(":button,:submit").each(function () {
    //    $(this).toggleClass("botonEnabled");
    //});

    //$('#btnGuardar,#btnRegresar').button({

    //    disabled: false,
    //    primary: "ui-icon-save",
    //    secondary: "ui-icon-triangle-1-s"
    //});

    $('#btnGuardar').bind('click', function (event) {

        $.fnc_guardarRegistro();
    });

    $('#btnRegresar').bind('click', function (event) {

        $.f_redireccionarURL('/Configuracion/Index');
    });

    var vcodConfiguracion = $('#hddcodConfiguracion').val();
    $.fnu_MostrarRegistro(vcodConfiguracion);

    $('#txtsegUsuarioEdita').attr('Disabled', true);
    $('#txtsegFechaEdita').attr('Disabled', true);
    $('#txtcodKeyConfig').attr('Disabled', true);
});

(function ($) {
    $.fnu_MostrarRegistro = function (codConfiguracion) {
        'use strict';

        $('#hddcodConfiguracion').val(codConfiguracion);
        var prmAjax = {};
        prmAjax["url"] = '/Configuracion/ObtenerConfiguracion' + '?pId=' + codConfiguracion;
        prmAjax["success"] = $.fnu_MostrarRegistroSuccess;
        prmAjax["ajaxMessage"] = 'Obteniendo Datos del registro..';
        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

//**********************************************************************
// Nombre: $.fnu_MostrarRegistroSuccess
// Funcion: Función callback luego de solicitar un registro para edición
//**********************************************************************
(function ($) {
    $.fnu_MostrarRegistroSuccess = function (response, status) {
        'use strict';

        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo == "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo == "C") {
                $.mostrarDatos(response);
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true, 1);
    }
})(jQuery);

/**********************************************************************
Nombre: $.mostrarDatos
Funcion: Muestra los datos en los controles de un registro de PROYECTO
**********************************************************************/
(function ($) {
    $.mostrarDatos = function (response) {
        'use strict';

        var configuracion = response.Data.Data;
        var tablaReg = response.Data.Tabla;
        var indTipoValor = configuracion.indTipoValor;
        if (tablaReg == null)
            tablaReg = {};
        $('#hddindTipoValor').val(configuracion.indTipoValor);
        $('#txtindOrden').val(configuracion.indOrden);
        $('#txtcodKeyConfig').val(configuracion.codKeyConfig);
        $('#txtdesNombre').val(configuracion.desNombre);
        $('#txtgloDescripcion').val(configuracion.gloDescripcion);
        $('#txtindTipoValor').val(configuracion.indTipoValor);
        $('#txtcodTabla').val(configuracion.codTabla);
        $('#txtnumNivel').val(configuracion.numNivel);
        $('#txtdesGrupo').val(configuracion.desGrupo);
        $('#chkindActivo').attr('checked', configuracion.indActivo);
        $('#txtsegUsuarioEdita').val(configuracion.usuarioEdita);
        $('#txtsegFechaEdita').val(configuracion.fechaEdita);
        if (configuracion.codTabla != null) {
            $('#txtdesValor').addClass('capaOcultar');
            $('#cbodesValor').attr('hidden', false);
            $.f_loadComboFromArray(tablaReg, 'cbodesValor', true, configuracion.desValor, false);
        }
        else {
            $('#cbodesValor').addClass('capaOcultar');
            $('#txtdesValor').attr('hidden', false);
            $('#txtdesValor').val(configuracion.desValor);
            if (indTipoValor == 'D')
                $('#txtdesValor').on("onkeypress", "$.f_validaInput(1, event, true ,' ')");
            else if (indTipoValor == 'N')
                $('#txtdesValor').onkeypress = "return $.f_validaInput(1, event, true ,' ')";
        }
    }
})(jQuery);


/**********************************************************************
Nombre: $.fnc_guardarRegistro
Funcion: Invocada por el controlador de evento click del botón Guardar
**********************************************************************/
(function ($) {
    $.fnc_guardarRegistro = function () {
        'use strict'

        var registro = $.fnc_validarRegistro();
        if (registro.msjValidacion != '' && registro.msjControl != '') {
            $.f_Mensaje(registro.msjValidacion, false, true);
            $('#' + registro.msjControl).focus();
            return;
        }
        else {
            var parametro = {};
            parametro['url'] = '/Configuracion/GuardarConfiguracion';
            parametro['data'] = JSON.stringify(registro);
            parametro['ajaxMessage'] = 'Guardando datos del registro';
            parametro['success'] = $.fnc_guardarRegistroSuccess; /*Función callback*/
            $.f_ajaxRespuesta(parametro);
        }
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_guardarRegistroSuccess
Funcion: Invocada por el controlador de evento click del botón Guardar
**********************************************************************/
(function ($) {
    $.fnc_guardarRegistroSuccess = function (response, status) {
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
                $.f_redireccionarURL('/Configuracion/Index');
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_validarRegistro
Funcion: Invocada por el metodo guardar para validar los datos de la entidad
**********************************************************************/
(function ($) {
    $.fnc_validarRegistro = function () {
        'use strict'

        var vcodKeyConfig = $('#txtcodKeyConfig').val();
        var valtxtdesValor = null;
        if( $('#cbodesValor').is(":visible") )
            valtxtdesValor = $('#cbodesValor').val();
        else
            valtxtdesValor = $('#txtdesValor').val();
        var indCheckedOK = $('#chkindActivo').val() == 'on' ? true : false;

        var vcodConfiguracion= $('#hddcodConfiguracion').val();
        var vindOrden = $('#txtindOrden').val();
        var vdesValor =  valtxtdesValor;
        var vdesNombre = $('#txtdesNombre').val();
        var vgloDescripcion = $('#txtgloDescripcion').val();
        var vindTipoValor = $('#txtindTipoValor').val();
        var vcodTabla = $('#txtcodTabla').val();
        var vnumNivel = $('#txtnumNivel').val();
        var vdesGrupo = $('#txtdesGrupo').val();
        var vindActivo = document.getElementsByName("chkindActivo")[0].checked;;

        var idFocusControl = '';
        var msg = '';
        if (vcodKeyConfig == '') {
            msg += '- Ingresar clave de la configuración.. <br>';
            if (idFocusControl == '') idFocusControl = 'txtcodKeyConfig';
        }
        if (valtxtdesValor == '') {
            msg += '- Ingresar valor para el parametro. <br>';
            if (idFocusControl == '') idFocusControl = 'cbodesValor';
        }
        if (vdesNombre == '') {
            msg += '- Ingresar nombre que identifique al parámetro. <br>';
            if (idFocusControl == '') idFocusControl = 'txtdesNombre';
        }
        if (vdesNombre == '') {
            msg += '- Ingresar nombre que identifique al parámetro. <br>';
            if (idFocusControl == '') idFocusControl = 'txtdesNombre';
        }
        var pEntidad = {};
        pEntidad['codConfiguracion'] = vcodConfiguracion;
        pEntidad['indOrden'] = vindOrden;
        pEntidad['desValor'] = vdesValor;
        pEntidad['desNombre'] = vdesNombre;
        pEntidad['gloDescripcion'] = vgloDescripcion;
        pEntidad['indTipoValor'] = vindTipoValor
        pEntidad['codTabla'] = vcodTabla
        pEntidad['numNivel'] = vnumNivel
        pEntidad['desGrupo'] = vdesGrupo
        pEntidad['indActivo'] = vindActivo

        pEntidad['msjValidacion'] = msg;
        pEntidad['msjControl'] = idFocusControl;
        return pEntidad;
    }
})(jQuery);

