using RepartidorOnline.Application.DTO.Stores;
using RepartidorOnline.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Controllers
{
    public class TiendaController : Controller
    {
        private readonly ITiendaRepository _tiendaRepository;
        public TiendaController(ITiendaRepository tiendaRepository) 
        {
            this._tiendaRepository = tiendaRepository;
        }

        public ActionResult Index()
        {
            var listaTiendas = _tiendaRepository.ObtenerTiendas(new ObtenerTiendasRequestDto { });

            return View(listaTiendas);
        }

        [HttpPost]
        public ActionResult BuscarTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto)
        {
            var listaTiendas = _tiendaRepository.ObtenerTiendas(new ObtenerTiendasRequestDto {
                NombreTienda = obtenerTiendasRequestDto .NombreTienda
            });

            return PartialView("_BuscarTiendas", listaTiendas);
        }
    }
}