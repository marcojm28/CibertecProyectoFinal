var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Producto = app.pagina.Producto || (function () {

    var URL = { ObtenerProductosLista: '/Producto/ObtenerProductosLista', NuevoProducto: '/Producto/NuevoProducto', EliminarProducto:'/Producto/EliminarProducto' }

    function buscarProducto() {
        var nombreProducto = $('#idTxtBusqueda').val();

        $.post(URL.ObtenerProductosLista, { NombreProducto: nombreProducto })
            .done(function response(response) {
                $('.tbody-producto').html(response);
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });

    }

    function nuevoProductoModal()
    {
        app.lib.common.ShowModal("Nuevo Producto", URL.NuevoProducto, RespuestaCrearProducto, "IdModalProductoNuevo");
    }

    function nuevoProducto()
    {
        event.preventDefault();

        var form = $('#frmCreateProduct');

        if (form.valid()) {

            $.post(URL.NuevoProducto, form.serialize())
                .done(function (response) {
                    if (response > 0) {
                        app.lib.common.CloseModal(response, "IdModalProductoNuevo");
                        app.lib.common.ShowMessageSuccess("Se añadió el producto correctamente");

                    } else {
                        app.lib.common.ShowMessageError("Hubo un error al crear el producto");
                    }

                }).fail(function (xhr, status, error) {
                    app.lib.common.ShowMessageError(xhr.responseText);
                });
        }
    }

    function EliminarProducto()
    {
        var idProducto = $(this).val();

        $.post(URL.EliminarProducto, { IdProducto: idProducto })
            .done(function response(response) {
                if (response) {
                    app.lib.common.ShowMessageSuccess("Se eliminó el producto correctamente");
                    buscarProducto();
                } else {
                    app.lib.common.ShowMessageError("Hubo un error al eliminar el producto");
                }

            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });
    }

    function RespuestaCrearProducto() {
        buscarProducto();
    }

    function InitProductoPrincipal() {
        $('#btnBuscarMain').on('click', buscarProducto);
        $('#btnNuevoProducto').on('click', nuevoProductoModal);
        $('.btnEliminarProductoPrincipal').on('click', EliminarProducto);
        
    }

    function InitProductoModal()
    {
        $.validator.unobtrusive.parse($("#frmCreateProduct"));
        $('#btnConfirmarCrearProducto').on('click', nuevoProducto);
    }

    function InitProducto()
    {
        $('.btnEliminarProducto').on('click', EliminarProducto);
    }


    return {
        InitProductoPrincipal: InitProductoPrincipal,
        InitProductoModal: InitProductoModal,
        InitProducto: InitProducto
    }
})();