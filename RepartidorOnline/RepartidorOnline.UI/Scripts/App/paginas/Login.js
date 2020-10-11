var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Login = app.pagina.Login || (function () {

    var URL = { CreateUser: '/Seguridad/CreateUser' }

    function CrearUsuarioModal() {
        app.lib.common.ShowModal("Regístrate en ServEntrega", URL.CreateUser, RespuestaGuardar, "IdModalCreateUser");
    }

    function CrearUsuario() {

        event.preventDefault();

        var form = $('#frmCreateUser');

        if (form.valid()) {

            $.post(URL.CreateUser, form.serialize())
                .done(function (response) {
                    if (response.IndicadorRespuesta == 1) {
                        app.lib.common.CloseModal(response, "IdModalCreateUser");
                        app.lib.common.ShowMessageSuccess(response.MensajeValidacion);

                    } else {
                        app.lib.common.ShowMessageError(response.MensajeValidacion);
                    }

                }).fail(function (xhr, status, error) {
                    app.lib.common.ShowMessageError(xhr.responseText);
                });
        }
    }

    function InitApp() {
        $('#IdCreateUserLink').on('click', CrearUsuarioModal);
    }

    function InitModalCreateUser() {
        $.validator.unobtrusive.parse($("#frmCreateUser"));
        $('#btnCreateUser').on('click', CrearUsuario);
    }


    function RespuestaGuardar() {

    }


    return {
        InitApp: InitApp,
        InitModalCreateUser: InitModalCreateUser
    }
})();