/*APLICACION DESARROLLO*/
var rutaAppWeb = "";
var separadorfecha = "-";


//**********************************************************************
// Nombre: $.f_showError
// Funcion: Despliega el error provocado en el servidor
//**********************************************************************
(function($) {
    $.f_showError = function (data) {
        $.f_closeAllOpenDialog();

        $('#dataForm').addClass('capaOcultar');
        $('#dataError div:first-child').html('').html($.f_getHtmlException(data.Descripcion, data.Fuente, data.StackTrace));
        $('#dataError').removeClass('capaOcultar').addClass('capaMostrar');
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_redirectSessionOut
// Funcion: Redirecciona a una url enviada desde el server cuando las sesiones han expirado
//**********************************************************************
(function ($) {
    $.f_redirectSessionOut = function (page) {
        alert('La operación no puede realizarse. Su sesión ha expirado.');
        window.location.href = page;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_loadCombo
// Funcion: Carga un combo a partir de un array json obtenido via petición ajax
//**********************************************************************
(function ($) { 
    $.f_loadCombo = function(idCombo, conSeleccione, selectedValue, url, data, disabled, async, timeout, pSuccess, ajaxMessage) {
        $("#" + idCombo).html('');

        var prmAjax = {};
        prmAjax["async"] = async;
        prmAjax["url"] = url;
        prmAjax["data"] = JSON.stringify(data);
        prmAjax["success"] = function (response, status) {  // Función callback
            if (status === 'success') {
                var tipo = response.Type;
                var mensaje = response.Data;
               
                if (tipo === "E")
                    $.f_showError(mensaje);
                else if (tipo === "I") {
                    $.f_bloquearCombo(idCombo, true);
                    alert(mensaje);
                }
                else if (tipo === "C") {
                    var arrayJson = mensaje;
                    $.f_loadComboFromArray(arrayJson, idCombo, conSeleccione, selectedValue, disabled);

                    if (pSuccess != null)
                        pSuccess(response, status);
                }
            }
            else
                alert(response.responseText);
        };

        prmAjax["ajaxMessage"] = ajaxMessage ? ajaxMessage : window.ajaxMessage;
        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_loadComboFromArray
// Funcion: Carga un combo a partir de un array json
//**********************************************************************
(function ($) { 
    $.f_loadComboFromArray = function(arrayJson, idCombo, conSeleccione, selectedValue, disabled) {
        $("#" + idCombo).html('');

        if (arrayJson == null) {
            $.f_bloquearCombo(idCombo, true);
            return;
        }

        if (conSeleccione)
            $("#" + idCombo).append('<option value="">' + '--Seleccione--' + '</option>');

        for (var i = 0; i < arrayJson.length; ++i) {
            var value = arrayJson[i].value == undefined ? arrayJson[i].Valor : arrayJson[i].value;
            var text = arrayJson[i].text == undefined ? arrayJson[i].Text : arrayJson[i].text;

            var selected = value == selectedValue && value != 0 ? 'selected = selected' : '';

            $("#" + idCombo).append('<option value="' + value + '"  ' + selected + ' >' + text + '</option>');
        }

        if (disabled)
            $('#' + idCombo).attr('disabled', true);
        else if (i > 0)
            $('#' + idCombo).attr('disabled', false);

        return $('#' + idCombo);
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_loadChosenFromArray
// Funcion: Carga un chosen a partir de un array json
//**********************************************************************
(function ($) {
    $.f_loadChosenFromArray = function (arrayJson, idCombo, arraySelecteds, disabled) {
        $("#" + idCombo).html('');

        for (var i = 0; i < arrayJson.length; ++i) {
            var value = arrayJson[i].value;
            var text = arrayJson[i].text;

            var selected = '';
            if (arraySelecteds != null)
            {
                // Verificar si el value se encuentra en arraySelecteds
                var encontrado = false;
                for (var j = 0; j < arraySelecteds.length && !encontrado; ++j)
                    if (value == arraySelecteds[j].value) encontrado = true;

                selected = encontrado ? 'selected = selected' : '';
            }

            $("#" + idCombo).append('<option value="' + value + '"  ' + selected + ' >' + text + '</option>');
        }

        if (disabled)
            $('#' + idCombo).attr('disabled', true);
        else if (i > 0)
            $('#' + idCombo).attr('disabled', false);

        return $('#' + idCombo).trigger("liszt:updated");
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_bloquearCombo
// Funcion: Bloquea un combo
//**********************************************************************
(function ($) {
    $.f_bloquearCombo = function (idCombo, conSeleccione) {
        $("#" + idCombo).html('');
        if (conSeleccione)
            $("#" + idCombo).append('<option value="">' + '--Seleccione--' + '</option>');
        $("#" + idCombo).attr('disabled', 'disabled');
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_openWin
// Funcion: Abre una ventana con parametros de configuración
//**********************************************************************
(function($) {
    $.f_openWin = function(url, name, width, height, resizable, status, html) {
        var leftPosition, topPosition;

        width = width != null ? width : window.screen.width;
        height = height != null ? height : window.screen.height;

        leftPosition = (window.screen.width / 2) - (width / 2);
        topPosition = (window.screen.height / 2) - (height / 2);

        var specs = "status=" + (status ? "yes" : "no");
        specs += ",height=" + (height != null ? height : window.screen.height);
        specs += ",width=" + (width != null? width : window.screen.width);
        specs += ",resizable=" + (resizable ? 'yes' : 'no');
        specs += ",left=" + leftPosition;
        specs += ",screenY=" + topPosition;
        specs += ",toolbar=no,menubar=no,scrollbars=yes,location=no,directories=no";

        var ventana = window.open(url, '', specs);
        ventana.resizeTo(width != null ? width : screen.width, height ? height : screen.height);
        ventana.top.window.moveTo(0, 0);
        
        if (html != null) ventana.document.write(html);

        return ventana;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_openWinExport
// Funcion: Abre una pequeña ventana para tareas de exportación
//**********************************************************************
(function ($) {
    $.f_openWinExport = function (url, name, width, height, resizable, html) {
        var leftPosition, topPosition;

        width = width != null ? width : window.screen.width;
        height = height != null ? height : window.screen.height;

        leftPosition = 0;
        topPosition = 0;

        var specs = "status=no,height=" + (height != null ? height : window.screen.height);
        specs += ",width=" + (width != null ? width : window.screen.width);
        specs += ",resizable=" + (resizable ? 'yes' : 'no');
        specs += ",left=" + leftPosition;
        specs += ",screenY=" + topPosition;
        specs += ",toolbar=no,menubar=no,scrollbars=no,location=no,directories=no";

        var myWindow = window.open(url, '', specs);

        if (html != null) myWindow.document.write(html);

        return myWindow;
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_cerrarVentanaPadre
// Funcion: Cierra la ventana padre
//**********************************************************************
(function ($) {
    $.f_cerrarVentanaPadre = function () {
        var ventana = window.open('', '_parent', '');
        ventana.close();
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_setWindowDimension
// Posiciona un objeto en el centro de la pantalla
//**********************************************************************
(function($) {
    $.f_setWindowDimension = function(id, dlgWidth) {
        if (dlgWidth != null)
            $("#" + id).css("width", dlgWidth);

        var w = $("#" + id).css("width");
        var h = $("#" + id).css("height");

        var screenWidth = screen.width;
        var screenHeight = screen.height;

        var dlgLeft = Math.round((screenWidth - parseInt(w, 10)) / 2);
        var dlgTop = Math.round((screenHeight - parseInt(h, 10)) / 2);

        $("#" + id).css("left", dlgLeft);
        $("#" + id).css("top", dlgTop * 0.5);
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_validateAccessControls
// Funcion: Visualiza los controles que se envían en el array y oculta el resto
//**********************************************************************
(function ($) {
    $.f_validateAccessControls = function (arrayControls) {
        var allControls = $('#dataForm').find(':button, input, select, textarea, img');

        for (var i = 0; i < allControls.length; ++i)
        {
            var idControl = allControls[i].id;

            var encontrado = false;
            for (var j = 0; j < arrayControls.length && !encontrado; ++j)
                if (idControl != null && idControl != '' && idControl == arrayControls[j])
                    encontrado = true;

            if (idControl != null && idControl != '' && !encontrado)
                $('#' + idControl).css('display', 'none');    
        }
    }
})(jQuery);





/**********************************************************************
Nombre: $.fnc_AplicarSeguridadSucces
Funcion: Función callback luego de solicitar la eliminación de un registro de la Entidad
**********************************************************************/
(function ($) {
    $.fnc_AplicarSeguridadControlRegSucces = function (response, status) {
        'use strict'

        if (status === 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo === "E")
                $.f_Mensaje(mensaje, false, true, 1);
            else if (tipo === "I")
                $.f_Mensaje(mensaje, false, true);
            else if (tipo === "C") {
                $.f_validarAccesoControles(mensaje);

                if ($('#hddindModo').val() == 0) {
                    $('#btnGuardar').addClass('hidden');
                }
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_bloquearCombo
// Funcion: Bloquea un combo
//**********************************************************************
(function ($) {
    $.f_getUrlParameter = function (parameterName) {
        var params = window.location.href.split('?');
        var sURLVariables = params.split('&');
        
        for (var i = 0; i < sURLVariables.length; ++i) {
            var sParameter = sURLVariables[i].split('=');
            if (sParameter == parameterName) 
                return sParameter[1];
        }

        return null;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_clearGrid
// Funcion: Limpia un jqGrid con id=gridID
//**********************************************************************
(function ($) { 
    $.f_clearGrid = function(gridID) {
        $('#' + gridID).jqGrid('clearGridData');
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_reloadGrid
// Funcion: Limpia un jqGrid con id=gridID
//**********************************************************************

(function ($) {
    $.f_reloadGrid = function (gridID) {
        //$('#' + gridID).jqGrid('clearGridData');
        $('#' + gridID).trigger("reloadGrid", [{ page: 1 }]);
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_clearChosen
// Funcion: Limpia un chose con id=chosenID
//**********************************************************************
(function ($) {
    $.f_clearChosen = function (chosenID) {
        $('#' + chosenID + '_chzn').find("li.search-choice").remove();
        $('#' + chosenID).val('').trigger('liszt:updated');
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_closeAllOpenDialog
// Funcion: Cierra todos los diálogo abiertos en el documento
//**********************************************************************
(function ($) { 
    $.f_closeAllOpenDialog = function() {
        $('.ui-dialog').filter(function() {
            return $(this).css('display') == 'block'
        }).find('.ui-dialog-content').each(function(index, obj) {
            $(obj).dialog('close');
        });
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_configuraCalendario
// Funcion: Configuración control calendario
//**********************************************************************
(function ($) {
    $.f_configuraCalendario = function (datePickerID, dateFormat, minDate, maxDate) {
        //$('#' + datePickerID).datepicker('destroy');
        var datePicker = $('#' + datePickerID);

        datePicker.datepicker({
            showButtonPanel: false,
            showAnim: 'slide',
            changeMonth: true,
            changeYear: true
            //dateFormat: 'dd/mm/yy'    // default
            //showWeek: true
            //minDate: new Date()
        });

        if (dateFormat != null)
            datePicker.datetimepicker('option', 'dateFormat', dateFormat);
        else
            datePicker.datetimepicker('option', 'dateFormat', 'dd/mm/yy');

        if (minDate != null)
            datePicker.datetimepicker('option', 'minDate', minDate);

        if (maxDate != null)
            datePicker.datetimepicker('option', 'maxDate', maxDate);

        return datePicker;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_getMinDate
// Funcion: Devuelve la fecha actual restádole la cantidad de años del parámetro
//**********************************************************************
(function($) {
    $.f_getMinDate = function(anios) {
        var fechaHoy = new Date();
        var dia = fechaHoy.getDate();
        var mes = fechaHoy.getMonth();
        var anio = fechaHoy.getFullYear();

        return new Date(anio - anios, mes, dia);
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_cssGridApply
// Funcion: Aplica estilo personalizado al grid
//**********************************************************************
(function ($) {
    $.f_cssGridApply = function (showTitleBar, styleCase) {
        if (!showTitleBar) $(".ui-jqgrid-titlebar").hide();

        switch (styleCase)
        {
            case 1:
                $('.ui-state-default,.ui-widget-content .ui-state-default,.ui-widget-header .ui-state-default').css('background-color', '#e9f2fe');
                $('.ui-state-default,.ui-widget-content .ui-state-default,.ui-widget-header .ui-state-default').css('font-weight', 'bold');
                break;
            default:
                $('.ui-state-default,.ui-widget-content .ui-state-default,.ui-widget-header .ui-state-default').css('background', '#e6e6e6 url(images/ui-bg_glass_75_e6e6e6_1x400.png) 50% 50% repeat-x');
                $('.ui-state-default,.ui-widget-content .ui-state-default,.ui-widget-header .ui-state-default').css('font-weight', 'bold');
                break;
        }
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_getBrowseHeight
// Funcion: Obtiene el alto del navegador
//**********************************************************************
(function($) {
    $.f_getBrowseHeight = function() {
        return window.layers ? window.innerHeight : document.body.clientHeight;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_getBrowseWidth
// Funcion: Obtiene el ancho del navegador
//**********************************************************************
(function($) {
    $.f_getBrowseWidth = function() {
        return window.layers ? window.innerWidth : document.body.clientWidth;
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_getBrowseWidth
// Funcion: Obtiene el ancho del navegador
//**********************************************************************
(function ($) { 
    $.f_blink = function(selector, interval) {
        var visible = true;

        setInterval(function() {
            visible = !visible;
            $(selector).css('display', visible ? 'none' : 'block');
        }, interval);
    }
})(jQuery);


(function ($) {
    $.f_validaInput = function (filterType, evt, allowDecimal, allowCustom) {

        var keyCode, Char, inputField, filter = '';
        var alpha = 'abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ';
        var num = '0123456789';
        if (window.event) {
            keyCode = window.event.keyCode;
            evt = window.event;
        } else if (evt) keyCode = evt.which;
        else return true;
        if (filterType == 0) filter = alpha;
        else if (filterType == 1) filter = num;
        else if (filterType == 2) filter = alpha + num;
        if (allowCustom) filter += allowCustom;
        if (filter == '') return true;
        inputField = evt.srcElement ? evt.srcElement : evt.target || evt.currentTarget;
        if ((keyCode == null) || (keyCode == 0) || (keyCode == 8) || (keyCode == 9) || (keyCode == 13) || (keyCode == 27)) return true;
        Char = String.fromCharCode(keyCode);
        if ((filter.indexOf(Char) > -1)) return true;
        else if (filterType == 1 && allowDecimal && (Char == '.') && inputField.value.indexOf('.') == -1) return true;
        else return false;
    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_NombreArchivo
// Funcion: Obtiene el nombre del un archivo con la fecha actual de la maquina cliente
//**********************************************************************
(function ($) {
    $.f_NombreArchivo = function (desNombre) {
        var nombreArchivo = "";

        nombreArchivo = desNombre + "_" + $.f_formatoFechaYYYYMMDDHHMMSS();
        return nombreArchivo;
    }
})(jQuery);



(function ($) {
    $.f_Delay = function (miliseconds) {

        var init = new Date().getTime();
        var current = init;
        while (current - init < miliseconds) {
            current = new Date().getTime();
        }
    }
})(jQuery);



//**********************************************************************
// Nombre: $.f_esValidoCorreoElectronico
// Funcion: Devuelve true si el dato de correo electronico es correcto
//**********************************************************************
(function ($) {
    $.f_esValidoCorreoElectronico = function (entry) {
        var resultado = false;

        if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(entry)) {
            resultado = true;
        }

        return resultado;
    }
})(jQuery);



var Class = function (methods) {
    var klass = function () {
        this.initialize.apply(this, arguments);
    };

    for (var property in methods) {
        klass.prototype[property] = methods[property];
    }

    if (!klass.prototype.initialize) klass.prototype.initialize = function () { };

    return klass;
};

var MapManager = Class({
    mapManage: null,
    divMap: null,
    drawingManager: null,
    initialize: function (divMap, load) {
        this.divMap = divMap;
        this.mapManage = null;
        this.options = {
            zoom: 12,
            center: new google.maps.LatLng(-12.046374, -77.0427934),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControl: false
        };
        if (load) {
            this.mapManage = new google.maps.Map(document.getElementById(divMap), this.options);
        }
    },
    /*load: function () {
			if (this.mapManage == null) {
					var Options = this.options;
					this.mapManage = new google.maps.Map(document.getElementById(this.divMap), Options);

					if (this.drawingManager != null) {
							this.drawingManager.setMap(this.mapManage);
					}
			}
	},*/
    createDrawing: function (drawingModes) {
        if (this.drawingManager == null) {
            this.drawingManager = new google.maps.drawing.DrawingManager({
                //drawingMode: google.maps.drawing.OverlayType.MARKER,
                drawingControl: false,
                drawingControlOptions: {
                    position: google.maps.ControlPosition.TOP_CENTER,
                    drawingModes: drawingModes
                }
            });
        }
        if (this.mapManage != null) {
            this.drawingManager.setMap(this.mapManage);
        }
    },
    setDrawing: function (draw) {
        this.drawingManager.setOptions({
            drawingControl: draw
        });
        if (draw) {
            this.drawingManager.setMap(this.mapManage);
        } else {
            this.drawingManager.setMap(null);
        }
    },
    addEventDrawing: function (event, funcion) {
        google.maps.event.addListener(this.drawingManager, event, funcion);
    },
    addEvent: function (event, funcion) {
        google.maps.event.addListener(this.mapManage, event, funcion);
    },
    addMarkerSimple: function (lat, lng, center) {
        var latLng = new google.maps.LatLng(lat, lng);
        var marker = this.addMarker(latLng, "", false);
        marker.setMap(this.mapManage);
        if (center) {
            this.mapManage.setCenter(latLng);
        }
        return marker;
    },
    addMarker: function (latLng, title, drag) {
        var marker = new google.maps.Marker({
            position: latLng,
            map: this.mapManage,
            title: title,
            draggable: drag
        });
        return marker;
    },
    addMarkerDrag: function (latLng, title, funcionDrag, funcionDragend) {
        var marker = this.addMarker(latlng, title, true);

        google.maps.event.addListener(marker, 'drag', funcionDrag);
        google.maps.event.addListener(marker, 'dragend', funcionDragend);
        return marker;
    },
    addListMarkers: function (arrayElements, style) {
        var FeatureCollection = {
            type: "FeatureCollection"
        };

        var Features = [];

        $.each(arrayElements, function (index, element) {
            var Feature = {
                type: "Feature",
                geometry: {
                    type: "Point",
                    coordinates: [element["lng"], element["lat"]]
                },
                properties: element["properties"]
            };
            Features.push(Feature);
        });

        FeatureCollection.features = Features;

        this.addGeoJson(FeatureCollection, style);

    },
    addGeoJson: function (geojson, style) {
        var mapManageLocal = this.mapManage;
        mapManageLocal.data.forEach(function (feature) {
            mapManageLocal.data.remove(feature);
        });

        mapManageLocal.data.addGeoJson(geojson, {
            idPropertyName: "idFeature"
        });
        mapManageLocal.data.setStyle(style);
    },
    setPropertyFeatureById: function (idFeature, property, value) {
        this.mapManage.data.getFeatureById(idFeature).setProperty(property, value);
    },
    refresh: function () {
        $("#" + this.divMap).show();
        var center = this.mapManage.getCenter();
        google.maps.event.trigger(this.mapManage, "resize");
        this.mapManage.setCenter(center);
    }
});

