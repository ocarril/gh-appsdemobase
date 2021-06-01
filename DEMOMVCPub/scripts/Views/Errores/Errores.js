/***********************************************************************
Método     : Errores.js
Propósito  : Manejo de la pagina de error
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
   
    $('#btnSalir').bind('click', function (event) {

        $.f_redireccionarURL('Home/Index/');
    });

});
