(function ($) {
    $.f_formatoFechas = function (txtfecha, minFecha) {
        'use strict';

        $("#" + txtfecha).datepicker({
            //showOn: 'button',
            //buttonImage: '../Content/Images/icoCalendar.gif',
            buttonImageOnly: true,
            changeYear: true,
            changeMonth: true,
            dateFormat: separadorfecha == "/" ? 'dd/mm/yy' : 'dd-mm-yy',
            timeFormat: 'hh:mm:ss',
            //appendText: true,
            numberOfMonths: 1,
            minDate: (minFecha == true ? 0 : undefined),
            onSelect: function (txtfecha, objDatepicker) {
                $('#' + txtfecha).focus();
                $("#mensaje").html("<p>Has seleccionado: " + txtfecha + "</p>");
            }
        });
    }
})(jQuery);

(function ($) {
    $.f_formatoHoras = function (txtHora) {
        'use strict';

        $("#" + txtHora).datepicker({
            //showOn: 'button',
            //buttonImage: '../Content/Images/icoCalendar.gif',
            buttonImageOnly: true,
            changeYear: false,
            changeMonth: false,
            dateFormat: 'HH:mm',
            timeFormat: 'hh:mm',
            //appendText: true,
            //numberOfMonths: 1,
            onSelect: function (txtHora, objDatepicker) {
                $("#mensaje").html("<p>Has seleccionado: " + txtHora + "</p>");
            }
        });
    }
})(jQuery);


(function ($) {
    $.f_MensajeNew = function (responseBrokenRulesCollection) {
        'use strict';
        //Error = 0,        =1->ERROR                   =ROJO
        //Warning = 1,      =2->ALERTA                  =NARANJA
        //Information = 2,  =4->CONFIRMACION            =AZUL
        //Success = 3       =3->OK-SATISFACTORIO        =VERDE

        var mensaje = responseBrokenRulesCollection[0].description;
        var autoHide = false;
        var tipo;
        var modal;
        var ntipo;
        if (responseBrokenRulesCollection[0].severity == 0) {
            tipo = "E";
            ntipo = 1;
        }
        else if (responseBrokenRulesCollection[0].severity == 1) {
            tipo = "I"
            ntipo = 2;
        }
        else if (responseBrokenRulesCollection[0].severity == 3) {
            tipo = "C";
            ntipo = 3;
            autoHide = true;
        }
        //= tipo === "E" ? 1 : (tipo === "C" ? null : (tipo === undefined ? 2 : 3));
        $.f_Mensaje(mensaje, autoHide, modal, ntipo);
    }
})(jQuery);

(function ($) {
    $.f_Mensajes = function (mensaje, autoHide, modal, tipo) {
        'use strict';

        var ntipo = tipo === "E" ? 1 : (tipo === "C" ? null : (tipo === undefined ? 2 : 3));
        $.f_Mensaje(mensaje, autoHide, modal, ntipo);

    }
})(jQuery);

(function ($) {
    $.f_Mensaje = function (mensaje, autoHide, modal, ntipo) {
        'use strict';

        //Error = 0,        =1->ERROR                   =ROJO
        //Warning = 1,      =2->ALERTA                  =NARANJA
        //Information = 2,  =4->CONFIRMACION            =AZUL
        //Success = 3       =3->OK-SATISFACTORIO        =VERDE
        var argumentos = ['', ''];
        if (autoHide == undefined || autoHide == null)
            autoHide = true;

        if (modal == undefined || modal == null)
            modal = true;
        if (ntipo === undefined || ntipo === null)
            ntipo = 2;
        var controlMensaje = new CROMMessageBox({
            contenido: mensaje,
            modal: modal,
            argumentos: argumentos,
            autoCerrado: (ntipo == 4 || ntipo == 2) ? false : autoHide,
            tipo: ntipo
        });
        controlMensaje.Mostrar();
    }
})(jQuery);

/***********************************************************************
Nombre: $.fnc_AjustarJQGrid
Funcion: Formatea columna de edición de la grilla entidad
************************************************************************/
(function ($) {
    $.fnc_AjustarJQGrid = function (nombreGrid, nombreMarco) {
        'use strict'

        $(window).bind('resize', function () {
            $("#" + nombreGrid).jqGrid('setGridWidth', ($("#" + nombreMarco).width()));
        }).trigger('resize');
    }
})(jQuery);

/**********************************************************************
 Nombre: $.fnc_traerFilasSeleccionadas
 Funcion: Función que devuelve las filas seleccionadas de la grilla 
**********************************************************************/
(function ($) {
    $.fnc_traerFilasSeleccionadas = function (nombreGrid, nombreCampoID) {
        'use strict'

        var saveSelectedRows = $("#" + nombreGrid).getGridParam('selarrrow');
        var objEntidad = {};
        var arr_CodigosIDs = [];
        if (saveSelectedRows.toString().length > 0) {
            var codigoIDs = saveSelectedRows.toString().split(',');
            for (var i = 0; i < codigoIDs.length; ++i) {
                var codID = codigoIDs[i]; //parseInt();

                objEntidad[nombreCampoID] = codID;
                arr_CodigosIDs.push(objEntidad);
                objEntidad = {};
            };
        }
        return arr_CodigosIDs;
    }
})(jQuery);


/**********************************************************************
Nombre: $.fnc_formatEstadoRegistroAcIn
Funcion: Se dispara para mostrar estado en forma de botones
**********************************************************************/
(function ($) {
    $.fnc_formatEstadoRegistroAcIn = function (cellvalue, options, rowObject) {
        'use strict'
        var html = "";

        if (cellvalue.toLowerCase() === "true") {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_1 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '" value=\"' + options.rowId + '\">ACTIVADO</button></div>';
        } else {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_4 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '" value=\"' + options.rowId + '\">DESACTIVADO</button></div>';
        }

        return html
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_formatEstadoRegistroSiNo
Funcion: Se dispara para mostrar estado en forma de botones
**********************************************************************/
(function ($) {
    $.fnc_formatEstadoRegistroSiNo = function (cellvalue, options, rowObject) {
        'use strict'
        var html = "";
        var btnId = 'btnButtonSiNo_' + options.rowId;

        if (cellvalue.toLowerCase() === "true") {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_1 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '"  id=' + btnId + '" value=\"' + options.rowId + '\">SI</button></div>';
        } else {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_4 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '"  id=' + btnId + '" value=\"' + options.rowId + '\">NO</button></div>';
        }

        return html
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_formatEstadoRegistroStatus
Funcion: Se dispara para mostrar estado en forma de botones
**********************************************************************/
(function ($) {
    $.fnc_formatEstadoRegistroStatus = function (cellvalue, options, rowObject) {
        'use strict'
        var html = "";

        if (cellvalue.toLowerCase() === "true") {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_1 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '" value=\"' + options.rowId + '\">VALIDADO</button></div>';
        } else {
            html = '<div style="width:100%;padding:4px 0px;"><button class="f_g_b_sinefecto f_g_b_estado_5 btnCambiarEstado" type="button" data-state="' + rowObject[10] + '" value=\"' + options.rowId + '\">PENDIENTE</button></div>';
        }

        return html
    }
})(jQuery);


/**********************************************************************
Nombre: $.fnc_wordCount
Funcion: Cuenta la cantidad de carácteres en un cuadro de texto INPUT/TEXTAREA
**********************************************************************/
(function ($) {
    $.fnc_wordCount = function (valorMaximo, valorTexto, controlViewValor) {
        'use strict'

        var numeroCaracteres = valorMaximo - valorTexto.length;
        $('#' + controlViewValor).html(' : Faltan [ ' + numeroCaracteres + ' ]');

    }
})(jQuery);