var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Tienda = app.pagina.Tienda || (function () {

    var URL = { buscarTiendas: '/Tienda/BuscarTiendas', ProductosPorTienda:'/Tienda/ProductosPorTienda'}


    function BuscarTiendas() {

        var nombreTienda = $('#idTxtBusqueda').val();

        $.post(URL.buscarTiendas, { NombreTienda: nombreTienda })
            .done(function response(response) {
                $('.content-main').html(response);
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });

    }

    function BuscarProductoPorTienda() {

        var idTienda = $(this).val();

        $.post(URL.ProductosPorTienda, { IdTienda: idTienda })
            .done(function response(response) {
                window.location.href = baseApplicationPath + 'Producto/Index?IdTienda=' + idTienda;
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });


    }

    function InitTienda() {
        $('#btnBuscarMain').on('click', BuscarTiendas);
        $('.item-tienda-boton').on('click', BuscarProductoPorTienda);
    }


    return {
        InitTienda: InitTienda
    }
})();