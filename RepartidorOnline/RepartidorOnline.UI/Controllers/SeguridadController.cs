using RepartidorOnline.Application.DTO.Users;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.UI.Helpers;
using RepartidorOnline.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Controllers
{
    public class SeguridadController : Controller
    {
        private readonly IUsuarioUseCase _usuarioUseCase;

        public SeguridadController(IUsuarioUseCase usuarioUseCase) 
        {
            this._usuarioUseCase = usuarioUseCase;
        }

        // GET: Seguridad
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var loginResponse = _usuarioUseCase.ValidarUsuario(new LoginRequestDto() { NombreUsuario = loginViewModel.Login, Contrasena = loginViewModel.Password });

            if (loginResponse != null)
            {
                var claims = SecurityHelpers.CreateUserClaims(
                    $"{loginResponse.Nombres} {loginResponse.Apellidos}",
                    $"{loginResponse.NombreUsuario}",
                    $"{loginResponse.Correo}",
                    $"{loginResponse.IdUsuario}"
                    );

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                //obtiene configuración de startup
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                //Se realiza el login
                authManager.SignIn(identity);

                return Redirect(loginViewModel.ReturnUrl ?? "~/");
            }
            else
            {
                return View(loginViewModel);
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignOut();

            return Redirect("~/");
        }


        }
}