using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.UseCases
{
    public class ProductoUseCase : IProductoUseCase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoUseCase(IProductoRepository productoRepository) 
        {
            this._productoRepository = productoRepository;
        }

        public List<Producto> ObtenerProductosPorTienda(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto)
        {
            var response = new List<Producto>();
            var responseRepository = new List<ObtenerProductosPorTiendaResponseDto>();

            responseRepository = _productoRepository.ObtenerProductosPorTienda(obtenerProductosPorTiendaRequestDto);

            foreach (var item in responseRepository) 
            {
                response.Add(new Producto() {
                    Descripcion= item.Descripcion,
                    IdProducto = item.IdProducto,
                    IdTienda = item.IdTienda,
                    ImagenSrc = item.ImagenSrc,
                    NombreProducto = item.NombreProducto,
                    Precio = item.Precio,
                    Stock = item.Stock
                });
            }

            return response;
        }
    }
}
