var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Producto = app.pagina.Producto || (function () {

    var URL = {
        ObtenerProductosLista: '/Producto/ObtenerProductosLista',
        NuevoProducto: '/Producto/NuevoProducto',
        EliminarProducto: '/Producto/EliminarProducto',
        EditarProducto: '/Producto/ActualizarProducto'
    }

    function buscarProducto() {
        var nombreProducto = $('#idTxtBusqueda').val();

        $.post(URL.ObtenerProductosLista, { NombreProducto: nombreProducto })
            .done(function response(response) {
                $('.tbody-producto').html(response);
            }).fail(function (xhr, status, error) {
                app.lib.common.ShowMessageError(xhr.responseText);
            });

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

    function EditarProducto() {
        event.preventDefault();

        var form = $('#frmUpdateProduct');

        if (form.valid()) {

            $.post(URL.EditarProducto, form.serialize())
                .done(function (response) {
                    if (response) {
                        app.lib.common.CloseModal(response, "IdModalEditarProducto");
                        app.lib.common.ShowMessageSuccess("Los datos se actualizaron correctamente");

                    } else {
                        app.lib.common.ShowMessageError("Error al editar producto");
                    }

                })
                .fail(function (xhr, status, error) {
                    app.lib.common.ShowMessageError(xhr.responseText);
                });
        }
    }

    function nuevoProductoModal() {
        app.lib.common.ShowModal("Nuevo Producto", URL.NuevoProducto, RespuestaCrearProducto, "IdModalProductoNuevo");
    }

    function EditarProductoModal()
    {
        var productoId = $(this).val();

        app.lib.common.ShowModal("Editar Producto", URL.EditarProducto + '?IdProducto=' + productoId, RespuestaEditarProducto, "IdModalEditarProducto");
    }

    function RespuestaCrearProducto() {
        buscarProducto();
    }

    function RespuestaEditarProducto() {
        buscarProducto();
    }

    function InitProductoPrincipal() {
        $('#btnBuscarMain').on('click', buscarProducto);
        $('#btnNuevoProducto').on('click', nuevoProductoModal);
        $('.btnEliminarProductoPrincipal').on('click', EliminarProducto);
        $('.btnEditarProductoPrincipal').on('click', EditarProductoModal);
        
    }

    function InitProductoCreateModal()
    {
        $.validator.unobtrusive.parse($("#frmCreateProduct"));
        $('#btnConfirmarCrearProducto').on('click', nuevoProducto);
    }

    function InitProductoUpdateModal() {
        $.validator.unobtrusive.parse($("#frmUpdateProduct"));
        $('#btnConfirmarEditarProducto').on('click', EditarProducto);
    }

    function InitProducto()
    {
        $('.btnEliminarProducto').on('click', EliminarProducto);
        $('.btnEditarProducto').on('click', EditarProductoModal);
    }


    return {
        InitProductoPrincipal: InitProductoPrincipal,
        InitProductoCreateModal: InitProductoCreateModal,
        InitProducto: InitProducto,
        InitProductoUpdateModal: InitProductoUpdateModal
    }
})();