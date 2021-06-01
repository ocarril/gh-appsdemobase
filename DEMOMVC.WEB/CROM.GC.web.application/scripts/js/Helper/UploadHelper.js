//**********************************************************************
// Nombre: $.f_extensionIsValid
// Función: Determina si extensión se encuentra dentro del array validExtensions
//**********************************************************************

(function ($) {
    $.f_extensionIsValid = function (extension, validExtensions) {

        var existePunto = extension.indexOf('.');

        var extensionSinPunto = extension.substring(existePunto + 1, extension.length - (existePunto));

        console.log('extension: ', extension);
        console.log('extensionSinPunto: ', extensionSinPunto);

        for (var t in validExtensions) {

           /*alert('validExtensions[t] == extension' + validExtensions[t].toLowerCase() + '--' + extension.toLowerCase());*/

            console.log('tvalidExtensions t: ', t);

            console.log('tvalidExtensions t: ', validExtensions[t].toLowerCase(), ' - ', extension.toLowerCase());

            if ('.'+validExtensions[t].toLowerCase() == extension.toLowerCase())
                return true;
        }
        return false;
    }
})(jQuery);


(function($) {
    $.f_deleteFileServerSuccess = function(response, status) {
        if (status === 'success') {
            var tipo = response.Type;
            var mensaje = response.Data;

            if (tipo === "E")
                $.f_showError(mensaje);
            else if (tipo === "I") {
                alert(mensaje);
            }
            else if (tipo === "C") {
                // Nothing
            }
        }
    }
})(jQuery);