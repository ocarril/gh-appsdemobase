/***********************************************************************
Modulo	   : Gestion Seguridad - Logueo de usuarios
Método     : Login.js
Propósito  : Manejo de la pagina para el logueo o acceso del usuario al sistema 
Se asume   : N/A
Efectos    : N/A
Notas      : N/A
Autor      : 
Fecha/Hora de Creación : 
Modificado : N/A
Fecha/Hora : N/A
***********************************************************************/

var rutaAPP = null;

$(document).ready(function () {

    $('#txtUsuario,#txtContrasenia').bind('keypress', function (event) {

        var key = event.charCode || event.keyCode || 0;
        if (key == 0 || key == 13) {
            $.ingresarAlSistema();
        };
    });

    $('#btnRegistrarUsuario').bind('click', function (event) {

        var url = 'UsuarioRegistro';
        window.location.href = url;
    });

    $('#btnCambiarClave').bind('click', function (event) {

        var url = window.sessionStorage.getItem('urlContraseniaCambiar');
        window.location.href = url;
    });

    $('#btnIngresar').bind('click', function (event) {

        $.ingresarAlSistema();
    });

    sessionStorage['rutaApiWebSeguridad'] = $('#hddRutaApiSeguridad').val();
    sessionStorage['rutaApiWebComercial'] = $('#hddRutaApiComercial').val();
    sessionStorage['rutaAppWebComercial'] = $('#hddRutaAppComercial').val();

    rutaAPP = sessionStorage.getItem('rutaAppWebComercial');
    $('#txtUsuario').focus();
    //location.href = rutaAPP;
});


/**********************************************************************
Nombre: $.ingresarAlSistema
Funcion: Permite el ingreso al sistema
**********************************************************************/
(function ($) {
    $.ingresarAlSistema = function () {
        'use strict'

        var indActivoCheck = false;
        var loginModel = {};
        loginModel["Usuario"] = $('#txtUsuario').val();
        loginModel["Contrasenia"] = $('#txtContrasenia').val();
        loginModel["OlvidoContrasenia"] = indActivoCheck;

        if (loginModel.Usuario == "" || loginModel.Contrasenia == "") {
            if (loginModel.Usuario == "" || loginModel.Contrasenia == "") {
                $.f_Mensaje('Ingresar login y contraseña de usuario', true, true, 2);
                $('#txtUsuario').focus();
                if (loginModel.Contrasenia == "")
                    $('#txtContrasenia').focus()
            }
            return;
        }
        else {
            var rutaActual = window.location.href;
            var rutaAgrega = '';
            var ultimoCaracter = String(rutaActual).substring(String(rutaActual).length - 1, String(rutaActual).length);
            if (ultimoCaracter == '/')
                rutaAgrega = 'AccesoCuenta' + ultimoCaracter;

            var parametro = {};
            parametro["url"] = 'AccesoCuenta/IniciarSesion';
            parametro["data"] = JSON.stringify(loginModel);
            parametro["success"] = $.ingresarAlSistemaSuccess;
            parametro["ajaxMessage"] = 'Ingresando al Sistema....';
            $.f_ajaxRespuesta(parametro);
        }
    }
})(jQuery);

/**********************************************************************
 Nombre: $.editItemVendedorMailSuccess
 Funcion: Función callback luego de solicitar un registro para edición
**********************************************************************/
(function ($) {
    $.ingresarAlSistemaSuccess = function (response, status) {

        
        if (status == 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;
            if (tipo == "E")
                $.f_Mensaje('[ERROR] - ' + mensaje, false, true, 1);

            else if (tipo == "I") {
                $.f_Mensaje(mensaje, false, true);
            }
            else if (tipo == "C") {

                //var rutaAPP = $('#hddRutaAppWeb').val();
                //sessionStorage['rutaAppWeb'] = rutaAPP;
                sessionStorage.setItem('tokenUser', response.TokenUser);
                
                $.f_Mensaje('Acceso correcto al sistema...', true, true, 3);

                var DATARequest = {
                    "desLogin": $('#txtUsuario').val()
                };

                var parametro = {};
                parametro["url"] = 'api/security/listuserobjectsgrants';
                parametro["type"] = 'POST';
                parametro["data"] = DATARequest;
                parametro["success"] = function (responseGrants, statusGrants) {
                    'use strict'

                    if (statusGrants === 'success') {

                        sessionStorage.setItem('grantsUsers', JSON.stringify(responseGrants));
                        
                        var url = '/Home/Index';
                        location.href = rutaAPP + url;
                    }
                    else
                        $.f_Mensaje(responseGrants.responseText, false, true);
                }
                parametro["ajaxMessage"] = 'Obteniendo permisos swl usuario...';
                $.f_ajaxRespuestaSeguridad(parametro);


               
            }
        }
        else
            $.f_Mensaje(response.responseText, false, true);
    }
})(jQuery);
