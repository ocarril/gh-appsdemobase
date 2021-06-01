/*
	Autor : 
	fecha : 
*/
(function ($) {
    $.jgrid.extend({
        exportarExcelCliente: function (o) {
            var archivoExporta, hojaExcel;
            archivoExporta = {
                worksheets: [
                    []
                ],
                creator: o.nomUsuario,
                created: new Date(),
                lastModifiedBy: o.nomUsuario,
                modified: new Date(),
                activeWorksheet: 0,
                name: o.nombre 
            };
            hojaExcel = archivoExporta.worksheets[0];
            hojaExcel.name = o.nombre;

            var arrayCabeceras = new Array();
            arrayCabeceras = $(this).getDataIDs();
            var dataFilaGrid = $(this).getRowData(arrayCabeceras[0]);
            var nombreColumnas = new Array();
            var ii = 0;
            var contador = 0;
            for (var i in dataFilaGrid) {
                if (contador >= parseInt(o.numColumna))
                    nombreColumnas[ii++] = i;
                contador++;
            }

            hojaExcel.push(nombreColumnas);
            var dataFilaArchivo;
            for (i = 0 ; i < arrayCabeceras.length; i++) {
                dataFilaGrid = $(this).getRowData(arrayCabeceras[i]);
                dataFilaArchivo = new Array();
                for (j = 0 ; j < nombreColumnas.length; j++) {
                    dataFilaArchivo.push(dataFilaGrid[nombreColumnas[j]]);
                }
                hojaExcel.push(dataFilaArchivo);
            }
            return xlsx(archivoExporta, o.nombre).href();
        },
        exportarTextoCliente: function (o) {
            var arrayCabeceras = new Array();
            arrayCabeceras = $(this).getDataIDs();
            var dataFilaGrid = $(this).getRowData(arrayCabeceras[0]);
            var nombreColumnas = new Array();
            var ii = 0;
            var textoRpta = "";
            var contador = 0;
            for (var i in dataFilaGrid) {
                if (contador >= parseInt(o.numColumna)) {
                    nombreColumnas[ii++] = i;
                    textoRpta = textoRpta + i + "|";
                }
                contador++;
            }
            textoRpta = textoRpta + "\n";
            for (i = 0; i < arrayCabeceras.length; i++) {
                dataFilaGrid = $(this).getRowData(arrayCabeceras[i]);
                for (j = 0; j < nombreColumnas.length; j++) {
                    textoRpta = textoRpta + dataFilaGrid[nombreColumnas[j]] + "|";
                }
                textoRpta = textoRpta + "\n";
            }
            textoRpta = textoRpta + "\n";
            return textoRpta;
        }
    });
})(jQuery);


(function ($) {
    $.fnc_descargarArchivo = function (contenidoEnBlob, nombreArchivo) {

        var element = document.createElement('a');
        element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(contenidoEnBlob));
        element.setAttribute('download', nombreArchivo + '.txt');
        element.style.display = 'none';
        document.body.appendChild(element);
        element.click();
        document.body.removeChild(element);

    }
})(jQuery);

(function ($) {
    $.fnc_descargarArchivoExcel = function (contenidoEnBlob, nombreArchivo) {

        nombreArchivo = nombreArchivo || 'archivo-.xlsx';
        var save = document.createElement('a');
        save.href = contenidoEnBlob;
        save.target = '_blank';
        save.download = nombreArchivo + '.xlsx';
        var clicEvent = new MouseEvent('click', { 'view': window, 'bubbles': true, 'cancelable': true });
        save.dispatchEvent(clicEvent);
        (window.URL || window.webkitURL).revokeObjectURL(save.href);
    }
})(jQuery);