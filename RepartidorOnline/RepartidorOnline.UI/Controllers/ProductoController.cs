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

        [HttpPost]
        public ActionResult NuevoProducto(CreateProductoViewModel createProductoViewModel)
        {
            var response = _productoUseCase.Add(new Producto() {
                Descripcion = createProductoViewModel.Descripcion,
                IdProducto = createProductoViewModel.IdProducto,
                IdTienda = createProductoViewModel.IdTienda,
                NombreProducto = createProductoViewModel.NombreProducto,
                Precio = createProductoViewModel.Precio,
                Stock = createProductoViewModel.Stock,
                EstadoRegistro = 1
            });

            return Json(response);
        }

        [HttpPost]
        public ActionResult EliminarProducto(int IdProducto)
        {
            _productoUseCase.Remove(new Producto() { 
                IdProducto = IdProducto
            });

            return Json(true);
        }

        [HttpGet]
        public ActionResult ActualizarProducto(int IdProducto)
        {
            var response = _productoUseCase.Get(IdProducto);
            var model = new UpdateProductoViewModel() { 
                Descripcion = response.Descripcion,
                IdProducto = response.IdProducto,
                IdTienda = response.IdTienda,
                NombreProducto = response.NombreProducto,
                Precio = response.Precio,
                Stock = response.Stock,
                tiendas = _tiendaUseCase.GetList()
            };
            

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(UpdateProductoViewModel updateProductoViewModel)
        {
            _productoUseCase.Update(new Producto() {
                 Descripcion = updateProductoViewModel.Descripcion,
                 Stock = updateProductoViewModel.Stock,
                 EstadoRegistro = 1,
                 IdProducto = updateProductoViewModel.IdProducto,
                 IdTienda = updateProductoViewModel.IdTienda,
                 NombreProducto = updateProductoViewModel.NombreProducto,
                 Precio = updateProductoViewModel.Precio
            });

            return Json(true);
        }

    }
}