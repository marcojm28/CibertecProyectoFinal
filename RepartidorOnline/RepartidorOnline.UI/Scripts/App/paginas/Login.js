var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Login = app.pagina.Login|| (function () {

    var URL = { LoginController: '/Seguridad/Login' }

    function IniciarSesion() {

        //$.get(URL.LoginController)
        //    .done(function response(response) {
        //        $('.main-content').html(response);
        //    });

        $.get(URL.LoginController, function (response) {
            $('.content-main').html(response);
        });

        //$.get(URL.LoginController);
    }

    function InitApp() {
        $('#btnLoginMain').on('click', IniciarSesion);
        //$('.txt-busqueda-productos').on('keyup', BuscarProducto);
    }


    return {
        //IniciarSesion: IniciarSesion,
        InitApp: InitApp

    }
})();