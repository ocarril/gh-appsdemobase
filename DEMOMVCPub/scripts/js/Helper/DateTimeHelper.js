(function ($) {
    $.f_getChangedTimeFormat = function (timePickerID) {
        var timeValue = $('#' + timePickerID).val();
        if (timeValue == '') return null;

        var contieneAM = timeValue.toLocaleLowerCase().indexOf('am');
        var contienePM = timeValue.toLocaleLowerCase().indexOf('pm');
        var json = null;

        if (contieneAM != -1 || contienePM != -1) {
            var sTime = timeValue.split(' ')[0];
            var sAMPM = timeValue.split(' ')[1];
            var tokens = sTime.split(':');

            switch (tokens.length) {
                case 2: // Hora y minuto
                    var hora12 = parseInt(tokens[0], 10);
                    var minuto = parseInt(tokens[1], 10);
                    var hora24;

                    if (sAMPM.toLocaleLowerCase() == 'pm' && hora12 < 12)
                        hora24 = hora12 + 12;
                    else if (sAMPM.toLocaleLowerCase() == 'am' && hora12 == 12)
                        hora24 = 0;
                    else
                        hora24 = hora12;

                    json = {
                        Formato12: {
                            hora: hora12,
                            minuto: minuto,
                            am_pm: sAMPM
                        },
                        Formato24: {
                            hora: hora24,
                            minuto: minuto,
                            Display: (hora24 < 10 ? '0' + hora24 : hora24) + ':' + (minuto < 10 ? '0' + minuto : minuto)
                        }
                    };
                    break;
                case 3: // Hora, minuto y segundo
                    var hora12 = parseInt(tokens[0], 10);
                    var minuto = parseInt(tokens[1], 10);
                    var segundo = parseInt(tokens[2], 10);
                    var hora24;

                    if (sAMPM.toLocaleLowerCase() == 'pm' && hora12 < 12)
                        hora24 = hora12 + 12;
                    else if (sAMPM.toLocaleLowerCase() == 'am' && hora12 == 12)
                        hora24 = 0;
                    else
                        hora24 = hora12;

                    json = {
                        Formato12: {
                            hora: hora12,
                            minuto: minuto,
                            segundo: segundo,
                            am_pm: sAMPM
                        },
                        Formato24: {
                            hora: hora24,
                            minuto: minuto,
                            segundo: segundo,
                            Display: (hora24 < 10 ? '0' + hora24 : hora24) + ':' + (minuto < 10 ? '0' + minuto : minuto) + ':' + (segundo < 10 ? '0' + segundo : segundo)
                        }
                    };
                    break;
            }
        }
        else {
            var tokens = timeValue.split(':');

            switch (tokens.length) {
                case 2: // Hora y minuto
                    var hora24 = parseInt(tokens[0], 10);
                    var minuto = parseInt(tokens[1], 10);
                    var hora12 = hora24 == 0 ? 12 : hora24 > 12 ? hora24 % 12 : hora24;

                    if (hora12 == 0) hora12 = 12;

                    json = {
                        Formato24: {
                            hora: hora24,
                            minuto: minuto
                        },
                        Formato12: {
                            hora: hora12,
                            minuto: minuto,
                            Display: (hora12 < 10 ? '0' + hora12 : hora12) + ':' + (minuto < 10 ? '0' + minuto : minuto) + ' ' + (hora24 < 12 ? 'am' : 'pm')
                        }
                    };
                    break;
                case 3: // Hora, minuto y segundo
                    var hora24 = parseInt(tokens[0], 10);
                    var minuto = parseInt(tokens[1], 10);
                    var hora12 = hora24 == 0 ? 12 : hora24 > 12 ? hora24 % 12 : hora24;
                    var segundo = parseInt(tokens[2], 10);

                    json = {
                        Formato24: {
                            hora: hora24,
                            minuto: minuto,
                            segundo: segundo
                        },
                        Formato12: {
                            hora: hora12,
                            minuto: minuto,
                            segundo: segundo,
                            Display: (hora12 < 10 ? '0' + hora12 : hora12) + ':' + (minuto < 10 ? '0' + minuto : minuto) + ':' + (segundo < 10 ? '0' + segundo : segundo) + ' ' + (hora24 < 12 ? 'am' : 'pm')
                        }
                    };
                    break;
            }
        }

        return json;
    }
})(jQuery);


(function ($) { 
    $.f_getDateFormatedString = function(sDate, formatoFechaOrigen, formatoFechaDestino) {
        var tokens = sDate.split('/');
        var dia, mes, anio;
        var result;

        if (formatoFechaOrigen == $('#hdFormatoFechaDefault').val()) {
            dia = tokens[0];
            mes = tokens[1];
            anio = tokens[2];
        }
        else if (formatoFechaOrigen == $('#hdFormatoFecha2').val()) {
            mes = tokens[0];
            dia = tokens[1];
            anio = tokens[2];
        }
        else {
            anio = tokens[0];
            mes = tokens[1];
            dia = tokens[2];
        }

        if (formatoFechaDestino == $('#hdFormatoFechaDefault').val())
            result = dia + '/' + mes + '/' + anio;
        else if (formatoFechaDestino == $('#hdFormatoFecha2').val())
            result = mes + '/' + dia + '/' + anio;
        else if (formatoFechaDestino == $('#hdFormatoFecha3').val())
            result = anio + '/' + mes + '/' + dia;
        else
            throw Error('Formato de fecha incorrecto.');

        return result;
    }
})(jQuery);


(function($) {
    $.f_compararFechas = function(fecha1, fecha2) {
        if (fecha1.getYear() != fecha2.getYear())
            return fecha1.getYear() - fecha2.getYear();

        else if (fecha1.getMonth() != fecha2.getMonth())
            return fecha1.getMonth() - fecha2.getMonth();

        else return fecha1.getDate() - fecha2.getDate();
    }
})(jQuery);

// Función que suma o resta días a la fecha indicada

(function($) {
    $.f_sumaFecha = function (d, fecha) {
    var Fecha = new Date();
    var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
    var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
    var aFecha = sFecha.split(sep);
    var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
    fecha = new Date(fecha);
    fecha.setDate(fecha.getDate() + parseInt(d));
    var anno = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();
    mes = (mes < 10) ? ("0" + mes) : mes;
    dia = (dia < 10) ? ("0" + dia) : dia;
    var fechaFinal = dia + sep + mes + sep + anno;
    return (fechaFinal);
    }
})(jQuery);

(function ($) {
    $.f_formatoFechaYYYYMMDD = function (vfecha) {
        'use strict'

        if (vfecha == null || vfecha == undefined)
            return;

        var fechaFormato = String(vfecha.substring(6, 10)) +
                            String(vfecha.substring(3, 5)) +
                            String(vfecha.substring(0, 2));

        return fechaFormato;
    }
})(jQuery);

(function ($) {
    $.f_formatoFechaDDMMYYYY = function (vfecha, vLong) {
        'use strict'

        var fechaFormato = "";
        if (vfecha == null)
            return fechaFormato;
        if (vLong == undefined)
            vLong = false;
        var fecha = new Date(parseInt(vfecha.slice(6, -2)));
        var vDia = fecha.getDate() < 10 ? '0' + fecha.getDate().toString() : fecha.getDate().toString();
        var vMes = (1 + fecha.getMonth()) < 10 ? '0' + (1 + fecha.getMonth()).toString() : (1 + fecha.getMonth()).toString();
        var vAnio = fecha.getFullYear().toString();
        var vHora = fecha.getHours() < 10 ? '0' + fecha.getHours().toString() : fecha.getHours().toString();
        var vMinu = fecha.getMinutes() < 10 ? '0' + fecha.getMinutes().toString() : fecha.getMinutes().toString();
        var vSegu = fecha.getSeconds() < 10 ? '0' + fecha.getSeconds().toString() : fecha.getSeconds().toString();
        //fechaFormato = vLong ? vDia + '/' + vMes + '/' + vAnio + ' ' + vHora + ':' + vMinu + ':' + vSegu : vDia + '/' + vMes + '/' + vAnio;
        fechaFormato = vLong ? vDia + separadorfecha + vMes + separadorfecha + vAnio + ' ' + vHora + ':' + vMinu + ':' + vSegu :
                               vDia + separadorfecha + vMes + separadorfecha + vAnio;
        return fechaFormato;
    }
})(jQuery);

(function ($) {
    $.f_formatoFechaYYYYMMDDHHMMSS = function () {
        'use strict'

        var Digital = new Date();

        var hours = Digital.getHours()
        var minutes = Digital.getMinutes()
        var seconds = Digital.getSeconds()
        var days = Digital.getDate()
        var months = Digital.getUTCMonth() + 1
        var years = Digital.getFullYear()
        if (hours <= 9) hours = "0" + hours.toString();
        if (minutes <= 9) minutes = "0" + minutes.toString();
        if (seconds <= 9) seconds = "0" + seconds.toString();
        if (days < 10) days = "0" + days.toString();
        if (months < 10) months = "0" + months.toString();
        var myclock = years.toString() + months.toString() + days.toString();
        myclock = myclock + hours.toString() + minutes.toString() + seconds.toString()

        return myclock
    }
})(jQuery);

function JSONDateWithTime(dateStr) {

    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    var m, day;
    m = d.getMonth() + 1;
    if (m < 10)
        m = '0' + m
    if (d.getDate() < 10)
        day = '0' + d.getDate()
    else
        day = d.getDate();
    var formattedDate = day + "/" + m + "/" + d.getFullYear();
    var hours = (d.getHours() < 10) ? "0" + d.getHours() : d.getHours();
    var minutes = (d.getMinutes() < 10) ? "0" + d.getMinutes() : d.getMinutes();
    var formattedTime = hours + ":" + minutes + ":" + d.getSeconds();
    formattedDate = formattedDate + " " + formattedTime;
    return formattedDate;
}