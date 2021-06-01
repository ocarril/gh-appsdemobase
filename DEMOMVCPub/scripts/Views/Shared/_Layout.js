//**********************************************************************
// Nombre: ready
// Configuración css
//**********************************************************************
$(function () {
    // Ajustar el min-width de cabecera y cuerpo al 90% de la pantalla del usuario
    $('div#header').css('min-width', window.screen.availWidth * 0.9);
    $('div#content').css('min-width', window.screen.availWidth * 0.9);
    $('div#content').css('max-width', window.screen.availWidth * 0.9);
    
    // Limpiar almacenamiento local y de sessión
    //window.localStorage.clear();
});


//**********************************************************************
// Nombre: ready
// Funcion: Configuración de eventos
//**********************************************************************
$(function () {
    $(document).bind('contextmenu', function () {
        return false;
    });

    $('#btnVolverError').bind('click', function (event) {
        $('#dataError').removeClass('capaMostrar').addClass('capaOcultar');
        $('#dataForm').removeClass('capaOcultar').addClass('capaMostrar');
    });
});

