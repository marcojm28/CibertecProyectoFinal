using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.Domain.Products;
using RepartidorOnline.UI.Models;
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
        private readonly ITiendaUseCase _tiendaUseCase;

        public ProductoController(IProductoRepository productoRepository, IProductoUseCase productoUseCase, ITiendaUseCase tiendaUseCase) 
        {
            this._productoRepository = productoRepository;
            this._productoUseCase = productoUseCase;
            this._tiendaUseCase = tiendaUseCase;
        }

        [Authorize]
        public ActionResult Index(int IdTienda)
        {
            ViewBag.IdTienda = IdTienda;

            var lista = new List<Producto>();

            lista = _productoUseCase.ObtenerProductosPorTienda(new ObtenerProductosPorTiendaRequestDto { IdTienda = IdTienda });

            return View(lista);
        }

        public ActionResult ObtenerProductosLista(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto)
        {
            var Tiendas = _tiendaUseCase.GetList();

            var lista = new List<Producto>();

            lista = _productoUseCase.ObtenerProductosPorTienda(new ObtenerProductosPorTiendaRequestDto { 
                NombreProducto = obtenerProductosPorTiendaRequestDto.NombreProducto
            });

            return PartialView(lista);
        }

        [HttpGet]
        public ActionResult NuevoProducto() 
        {
            var model = new CreateProductoViewModel();
            model.tiendas = _tiendaUseCase.GetList();

            return PartialView(model);
        }

    }
}