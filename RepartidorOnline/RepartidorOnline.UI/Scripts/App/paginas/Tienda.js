var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Tienda = app.pagina.Tienda || (function () {

    var URL = { buscarTiendas: '/Tienda/BuscarTiendas'}


    function BuscarTiendas() {

        var nombreTienda = $('#idTxtBusqueda').val();

        $.post(URL.buscarTiendas, { NombreTienda: nombreTienda })
            .done(function response(response) {
                $('.content-main').html(response);
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });

    }

    function InitTienda() {
        $('#btnBuscarMain').on('click', BuscarTiendas);
    }


    return {
        InitTienda: InitTienda
    }
})();