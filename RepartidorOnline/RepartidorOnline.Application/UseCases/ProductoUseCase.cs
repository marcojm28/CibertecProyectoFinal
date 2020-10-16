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

        public int Add(Producto entity) 
        {
            return _productoRepository.Add<int>(entity);
        }

        public void Remove(Producto entity) 
        {
            _productoRepository.Remove(entity);
        }

        public Producto Get(int IdProducto) 
        {
            return _productoRepository.Get(IdProducto);
        }

        public void Update(Producto producto) 
        {
            _productoRepository.Update(producto);
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
