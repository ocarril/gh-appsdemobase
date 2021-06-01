/***********************************************************************
Modulo	   : Gestion comercial INDEX
Método     : index.js
Propósito  : Manejo de la pagina principal del sistema
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

    var vrutaApiWeb = sessionStorage.getItem('rutaAppWebComercial');
    var nomImageLogo = vrutaApiWeb + '/content/logos/' + $('#txtNumRUCEmpresa').val() + '.PNG';
    document.getElementById('imgLogoImagenEmpresa').src = nomImageLogo;


    //var vFechaEmision = moment($('#hddfecEmision').val(), "DD-MM-YYYY").format("DD-MM-YYYY");
    //var fechaSelec = moment(vFechaEmision, "DD-MM-YYYY").format("YYYY-MM-DD");
    //$.fnc_getTipoDeCambioFecha(fechaSelec, 'TipoCambioVTA', 'TipoCambioCMP', false, true);

});

