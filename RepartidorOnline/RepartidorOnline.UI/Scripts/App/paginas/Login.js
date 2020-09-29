var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Login = app.pagina.Login|| (function () {

    var URL = { busquedaProductos: '/Producto/BuscarProductos' }

    //function BuscarProducto() {
    //    var nombre = $('.txt-busqueda-productos').val();

    //    $.post(URL.busquedaProductos, { Nombre: nombre })
    //        .done(function response(response) {
    //            $('.main-content').html(response);
    //        });
    //}

    //function InitApp() {
    //    //$('.btn-buscar').on('click', BuscarProducto);
    //    $('.txt-busqueda-productos').on('keyup', BuscarProducto);
    //}


    return {
        //BuscarProducto: BuscarProducto,
        //InitApp: InitApp

    }
})();