//**********************************************************************
// Nombre: $.f_ajaxRespuestas
// Funcion: Realiza una petición ajax al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRespuestas = function (url, data, success, messaje, type) {

        var prmAjax = {};
        prmAjax['url'] = url;
        prmAjax["data"] = undefined ? '' : JSON.stringify(data);
        prmAjax['success'] = success;
        prmAjax['ajaxMessage'] = messaje == undefined ? "Esperar un momento...." : messaje;
        $.f_ajaxRespuesta(prmAjax);
    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_ajaxRespuesta
// Funcion: Realiza una petición ajax al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRespuesta = function (paramAjax) {

        var vrutaApiWeb = sessionStorage.getItem('rutaAppWebComercial');

        var pathURL = vrutaApiWeb == undefined ? '' : vrutaApiWeb;

        window.ajaxMessage = paramAjax['ajaxMessage'];
        jQuery.ajax({
            type: paramAjax["type"] == undefined ? "POST" : paramAjax["type"],            // GET, POST, PUT O DELETE (verbo HTTP), si se omite, por defecto es GET
            async: paramAjax["async"] == undefined ? true : paramAjax["async"],           // true o false, llamada sícrona o asíncrona, por defecto la llamada es asíncrona
            timeout: paramAjax["timeout"] == undefined ? 600000 : paramAjax["timeout"],   // Tiempo máximo de espera para la petición (en milisegundos)
            url: pathURL + paramAjax["url"],                                              // ubicación del servicio
            data: paramAjax["data"] == undefined ? '' : paramAjax["data"],                // data enviada al servidor
            dataType: paramAjax["dataType"] == undefined ? 'JSON' : paramAjax["dataType"],// Tipo de dato que se espera que se devuelva en la respuesta
            contentType: paramAjax["contentType"] == undefined ? 'application/json; charset=UTF-8' : paramAjax["contentType"],   // Tipo de contenido que se especifica en la petición. Si se omite, la opción por defecto es application/x-www-form-urlencoded
            success: paramAjax["success"],                                                // función si la llamada al server fue exitosa
            error: paramAjax["error"] == undefined ? $.f_ajaxRequestFailed : paramAjax["error"], // función si la llamada al server falló
            cache: false,
            headers: {
                "Authorization": sessionStorage.getItem('tokenUser')
            }
        });
    }
})(jQuery);


//**********************************************************************
// Nombre: $.f_ajaxRespuestaApi
// Funcion: Realiza una petición ajax al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRespuestasApi = function (url, data, success, messaje, type, error) {

        var prmAjax = {};
        prmAjax['url'] = url;
        prmAjax["data"] = data;
        prmAjax['success'] = success;
        prmAjax["type"] = type;
        prmAjax['ajaxMessage'] = messaje;
        prmAjax['error'] = error;
        $.f_ajaxRespuestaApi(prmAjax);
    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_ajaxRespuestaApi
// Funcion: Realiza una petición ajax al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRespuestaApi = function (paramAjax) {

        //var vkeyAPI = sessionStorage.getItem('keyAPI');
        //var pathURL = sessionStorage.getItem('rutaApiWebAlertas');
        //console.log(antiForgeryToken);
        //console.log(vkeyAPI);
        //console.log(rutaApiWebAlertas + '--' + paramAjax["url"]);
        //var pathURL = rutaApiWebAlertas == undefined ? '' : rutaApiWebAlertas;
        //  http://localhost:7318/api/security/system/list

        var tokenUser = sessionStorage.getItem('tokenUser');
        var pathURL = sessionStorage.getItem('rutaApiWebComercial');
        pathURL = pathURL + "api/"+ paramAjax["url"];

        window.ajaxMessage = paramAjax['ajaxMessage'] == undefined ? "Esperar un momento...." : paramAjax['ajaxMessage'];
        jQuery.ajax({
            type: paramAjax["type"] == undefined ? "POST" : paramAjax["type"],            // GET, POST, PUT O DELETE (verbo HTTP), si se omite, por defecto es GET
            async: paramAjax["async"] == undefined ? true : paramAjax["async"],           // true o false, llamada sícrona o asíncrona, por defecto la llamada es asíncrona
            timeout: paramAjax["timeout"] == undefined ? 600000 : paramAjax["timeout"],   // Tiempo máximo de espera para la petición (en milisegundos)
            url: pathURL,                                                                 // ubicación del servicio
            data: (paramAjax["data"] == undefined || paramAjax["data"] == null)? '' : JSON.stringify(paramAjax["data"]),                // JSON.parse()data enviada al servidor
            dataType: paramAjax["dataType"] == undefined ? 'JSON' : paramAjax["dataType"],// Tipo de dato que se espera que se devuelva en la respuesta
            //contentType: paramAjax["contentType"] == undefined ? 'application/json; charset=UTF-8' : paramAjax["contentType"],   // Tipo de contenido que se especifica en la petición. Si se omite, la opción por defecto es application/x-www-form-urlencoded
            success: paramAjax["success"],                                          // función si la llamada al server fue exitosa
            error: paramAjax["error"] == undefined ? $.f_ajaxRequestFailed : paramAjax["error"],
            // función si la llamada al server falló
            cache: false,
            headers: {
                "Access-Control-Allow-Origin": '*',
                "Access-Control-Allow-Methods": 'POST, GET, OPTIONS, PUT',
                "content-type": 'application/json',
                "Authorization": tokenUser
            }
        });
    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_ajaxRequestFailed
// Funcion: Visualiza alerta de error en la llamada al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRequestFailed = function (request, status, error) {

        var message = 'Ha fallado la petición al servidor [Estado respuesta = ' + request.status + '] ' + request.statusText;
        if (status === 'error' && error === '') {

            $.f_Mensaje(error == '' ? status : error,  false, true, 1);
            return;
        }
        
        if (request.status == 200) {

            console.log('ERROR: 200');
            $.f_redireccionarURL(sessionStorage.getItem('rutaAppWebComercial'));
        }
        else if (request.status == 401) {

            console.log('ERROR: 401');
            $.f_redireccionarURL(sessionStorage.getItem('rutaAppWebComercial'));
        }
        else if (request.status == 400) {

            console.log('ERROR: 400');
            console.log(request);
            var errorRpta = JSON.parse(request.responseText);
            $.f_Mensaje(errorRpta.Message, false, true);
        }
        else {

            console.log('ERROR: ' + request.status);
            console.log(request);
            if (request.statusText === "timeout") {

                $.f_Mensaje("No existe conexión con el servicio. TimeOut", false, true, 1);
                $.f_redireccionarURL(sessionStorage.getItem('rutaAppWebComercial'));

            }
            else {
                console.log(request.responseText);
                if (request.responseText.substr(0,6) != '<!DOCTY') {
                    var errorRpta = JSON.parse(request.responseText);
                    $.f_Mensaje(errorRpta.Message, false, true, 1);
                }
            }
        }

    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_ajaxRequestFailed
// Funcion: Seguimiento de peticiones ajax
//**********************************************************************
(function ($) {
    var xhrRequests = [];

    // Cada vez que se hace una petición la agregamos al array
    $(document).ajaxSend(function (e, jqXHR, options) {

    });

    // Al completarse la petición la elminamos del array
    $(document).ajaxComplete(function (e, jqXHR, options) {

    });

    // Cada vez que se hace una petición la agregamos al array
    $(document).ajaxStart(function (e, jqXHR, options) {
        var ajaxMessage = window.ajaxMessage;

        //console.log('rutaAppWeb: ' + rutaAppWeb + '- window.location.href: ' + window.location.href + ' - window.location:' + window.location + ' - 126:');
        var pathURL = rutaAppWeb.length == 0 ? sessionStorage.getItem('rutaAppWebComercial') : rutaAppWeb;
        var htmlLoading = '<div style="background-color:blue;"><table border="0" cellpadding="5" cellspacing="0" align="center" width="150px"><colgroup><col width="20%" /><col width="80%" /></colgroup><tr><td><img alt="loading" src="' + pathURL + 'content/images/img_ajax.gif" /></td><td style="font-size: 11px; width: 80px; height: 30px; forecolor: green">' + ajaxMessage + '...' + '</td></tr></table></div>';
        //console.log(htmlLoading);
        if (ajaxMessage != '')
            $.blockUI({ message: htmlLoading });

    });

    // Cada vez que se hace una petición la agregamos al array
    $(document).ajaxStop(function (e, jqXHR, options) {
        if (window.ajaxMessage != '')
            $.unblockUI();
    });

    $(document).ajaxComplete(function (e, jqXHR, options) {
        // Verificar si ocurrió timeout
        if (jqXHR.statusText == 'timeout')
            alert('La petición ha tardado demasiado para el timeout configurado.');
        else if (options.dataType == 'json' || options.dataType == 'iframe json') {
            var urlCurrent = window.location.href;
            var json = jqXHR.responseJSON;

        }
    });

})(jQuery);

/// <summary>
/// Funcion que exporta un fichero mediante una petición Ajax.
/// </summary>
/// <remarks>
/// Creacion: LOG(TLV) 20120627 <br />
/// Modificacion: 
/// </remarks>
(function ($) {
    $.f_ajaxExportarFichero = function (generarFichero, descargarFichero, datos, nombreReporte) {
        window.ajaxMessage = 'Generando el reporte de excel de ' + nombreReporte;
        jQuery.ajax({
            type: 'POST',
            url: generarFichero,
            data: datos,
            onSuccess: function (response) {
                var hidNombreReporte = "<input type='hidden' id='nombreReporteExcel' name='nombreReporteExcel' value='" + nombreReporte + "'/>"
                jQuery('<form action="' + descargarFichero + '" method="post">' + hidNombreReporte + '</form>')
                    .appendTo('body').submit().remove();
            }
        });
    }

})(jQuery);

/// <summary>
/// Funcion que permite redireccionar pagina web dentro de la aplicacion web
/// </summary>
/// <remarks>
/// Creacion: LOG(TLV) 20120627 <br />
/// Modificacion: 
/// </remarks>
(function ($) {
    $.f_redireccionarURL = function (paginaWeb, indEncuesta) {

        var pathURL = sessionStorage.getItem('rutaAppWebComercial');
        var pathURLEncuesta = sessionStorage.getItem('rutaAppWebEncuesta');
        //console.log(pathURL + paginaWeb);
        if (indEncuesta)
            window.location.href = pathURLEncuesta + paginaWeb;
        else
            window.location.href = pathURL + paginaWeb;
    }

})(jQuery);

/**********************************************************************
Nombre: $.fnc_AplicarSeguridadControl
Funcion: Se dispara cuando se hace click sobre el ícono eliminar de la grilla 
**********************************************************************/
(function ($) {
    $.fnc_AplicarSeguridadControl = function (vController, vAction, vPrincipal) {
        'use strict'

        var permisosRolUser = JSON.parse(sessionStorage.getItem('grantsUsers'));
        //console.log(vController, vAction);
        //console.log(permisosRolUser);

        $.f_validarAccesoControles(permisosRolUser, vController, vAction);

    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_ajaxRespuestaSeguridad
// Funcion: Realiza una petición ajax al servidor
//**********************************************************************
(function ($) {
    $.f_ajaxRespuestaSeguridad = function (paramAjax) {

        var vkeyAPI = sessionStorage.getItem('keyAPI');
        var vrutaApiWeb = sessionStorage.getItem('rutaApiWebSeguridad');

        var pathURL = vrutaApiWeb == undefined ? '' : vrutaApiWeb;

        window.ajaxMessage = paramAjax['ajaxMessage'];
        jQuery.ajax({
            type: paramAjax["type"] == undefined ? "POST" : paramAjax["type"],            // GET, POST, PUT O DELETE (verbo HTTP), si se omite, por defecto es GET
            async: paramAjax["async"] == undefined ? true : paramAjax["async"],           // true o false, llamada sícrona o asíncrona, por defecto la llamada es asíncrona
            timeout: paramAjax["timeout"] == undefined ? 600000 : paramAjax["timeout"],   // Tiempo máximo de espera para la petición (en milisegundos)
            url: pathURL + paramAjax["url"],                                              // ubicación del servicio
            //data: paramAjax["data"] == undefined ? '' : paramAjax["data"],                // data enviada al servidor
            data: (paramAjax["data"] == undefined || paramAjax["data"] == null) ? '' : JSON.stringify(paramAjax["data"]),                // JSON.parse()data enviada al servidor
            dataType: paramAjax["dataType"] == undefined ? 'JSON' : paramAjax["dataType"],// Tipo de dato que se espera que se devuelva en la respuesta
            contentType: paramAjax["contentType"] == undefined ? 'application/json; charset=UTF-8' : paramAjax["contentType"],   // Tipo de contenido que se especifica en la petición. Si se omite, la opción por defecto es application/x-www-form-urlencoded
            success: paramAjax["success"],                                          // función si la llamada al server fue exitosa
            error: paramAjax["error"] == undefined ? $.f_ajaxRequestFailed : paramAjax["error"],                                              // función si la llamada al server falló
            cache: false,
            headers: {
                "keyTOKEN": vkeyAPI,
                "Authorization": sessionStorage.getItem('tokenUser')
            }
        });
    }
})(jQuery);

/**********************************************************************
Nombre: $.fnc_AplicarSeguridadControlSucces
Funcion: Función callback luego de solicitar la eliminación de un registro de la Entidad
**********************************************************************/
(function ($) {
    $.fnc_AplicarSeguridadControlSucces = function (response, status) {
        'use strict'

        if (status === 'success') {

            $.f_validarAccesoControles(response);

        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);

//**********************************************************************
// Nombre: $.f_validarAccesoControles
// Funcion: Visualiza los controles que se envían en el array y oculta el resto
//**********************************************************************
(function ($) {
    $.f_validarAccesoControles = function (arrayControls, vController, vAction) {

        var allControls = $('#dataForm').find(':button, input, select, textarea, img');
        for (var i = 0; i < allControls.length; ++i) {
            var idControl = allControls[i].id;

            for (var j = 0; j < arrayControls.length; ++j) {

                //console.log('idControl - ', arrayControls[j]);

                if (idControl.length > 0 &&
                    idControl == arrayControls[j].codElementoID &&
                    arrayControls[j].indTipoObjeto == 'CONTROL' &&
                    arrayControls[j].desEnlacePadre == vAction + "*" + vController) {

                   
                    if (arrayControls[j].indVer == true) {

                        //console.log('arrayControls[j].codElementoID: ' + arrayControls[j].codElementoID +
                        //    ' => indEditar: ' + arrayControls[j].indVer +
                        //    ' - indEditar: ' + arrayControls[j].indEditar);

                        $('#' + arrayControls[j].codElementoID + '*').removeClass('hidden');

                    }
                }
            }
        }
        setTimeout('$.f_Delay()', 5000);
    }
})(jQuery);

