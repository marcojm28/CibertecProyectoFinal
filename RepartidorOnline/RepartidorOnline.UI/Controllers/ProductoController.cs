using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository) 
        {
            this._productoRepository = productoRepository;
        }

        [Authorize]
        public ActionResult Index(int IdTienda)
        {
            ViewBag.IdTienda = IdTienda;

            var lista = new List<ObtenerProductosPorTiendaResponseDto>();

            lista = _productoRepository.ObtenerProductosPorTiendaResponse(new ObtenerProductosPorTiendaRequestDto { IdTienda = IdTienda });

            return View(lista);
        }
    }
}