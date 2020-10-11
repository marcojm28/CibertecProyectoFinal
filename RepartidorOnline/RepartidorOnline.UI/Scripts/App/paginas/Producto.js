var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Producto = app.pagina.Producto || (function () {

    var URL = { ObtenerProductosLista: '/Producto/ObtenerProductosLista' }

    function buscarProducto() {
        var nombreProducto = $('#idTxtBusqueda').val();

        $.post(URL.ObtenerProductosLista, { NombreProducto: nombreProducto })
            .done(function response(response) {
                $('.tbody-producto').html(response);
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });

    }

    function InitProducto() {
        $('#btnBuscarMain').on('click', buscarProducto);
    }


    return {
        InitProducto: InitProducto
    }
})();