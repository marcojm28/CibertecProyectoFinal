using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
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
        private readonly IProductoUseCase _productoUseCase;

        public ProductoController(IProductoRepository productoRepository, IProductoUseCase productoUseCase) 
        {
            this._productoRepository = productoRepository;
            this._productoUseCase = productoUseCase;
        }

        [Authorize]
        public ActionResult Index(int IdTienda)
        {
            ViewBag.IdTienda = IdTienda;

            var lista = new List<ObtenerProductosPorTiendaResponseDto>();

            lista = _productoUseCase.ObtenerProductosPorTiendaResponse(new ObtenerProductosPorTiendaRequestDto { IdTienda = IdTienda });

            return View(lista);
        }

        public ActionResult ObtenerProductosLista(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto)
        {

            var lista = new List<ObtenerProductosPorTiendaResponseDto>();

            lista = _productoUseCase.ObtenerProductosPorTiendaResponse(new ObtenerProductosPorTiendaRequestDto { 
                NombreProducto = obtenerProductosPorTiendaRequestDto.NombreProducto
            });

            return PartialView(lista);
        }

    }
}