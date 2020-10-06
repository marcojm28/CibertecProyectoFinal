var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Login = app.pagina.Login || (function () {

    var URL = { CreateUser: '/Seguridad/CreateUser' }

    function CrearUsuarioModal() {
        app.lib.common.ShowModal("Regístrate en ServEntrega", URL.CreateUser, RespuestaGuardar, "IdModalCreateUser");
    }

    function CrearUsuario() {

        var form = $('#frmCreateUser');

        $.post(URL.CreateUser, form.serialize())
            .done(function (response) {
            if (response) {
                app.lib.common.CloseModal(response, "IdModalCreateUser");
                alert("Los datos se grabaron correctamente");

            } else {
                alert("Error al guardar la información");
            }

        }).fail(function (xhr, status, error) {
                alert(xhr.responseText);
        });
    }

    function InitApp() {
        $('#IdCreateUserLink').on('click', CrearUsuarioModal);
    }

    function InitModalCreateUser() {
        $('#btnCreateUser').on('click', CrearUsuario);
    }


    function RespuestaGuardar() {

    }


    return {
        InitApp: InitApp,
        InitModalCreateUser: InitModalCreateUser
    }
})();