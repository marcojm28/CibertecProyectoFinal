using RepartidorOnline.Application.DTO.Users;
using RepartidorOnline.Application.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var usuario = _usuarioUseCase.ValidarUsuario(new LoginRequestDto() {NombreUsuario = "marcojm28",Contrasena = "73127743" });

            return View();
        }
    }
}