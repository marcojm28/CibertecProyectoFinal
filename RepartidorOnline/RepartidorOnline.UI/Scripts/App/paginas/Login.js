var app = app || {}; app.pagina = app.pagina || {};

app.pagina.Login = app.pagina.Login|| (function () {

    var URL = { Logout: '/Seguridad/Logout' }

    function CerrarSesion() {

        $.post(URL.Logout).done(function (response) {
            if (response) {
                window.location.href = "";
            }

        });

        
        
    }

    function InitApp() {
        //$('#btnLogoutMain').on('click', CerrarSesion);
        //$('.txt-busqueda-productos').on('keyup', BuscarProducto);
    }


    return {
        //IniciarSesion: IniciarSesion,
        InitApp: InitApp

    }
})();