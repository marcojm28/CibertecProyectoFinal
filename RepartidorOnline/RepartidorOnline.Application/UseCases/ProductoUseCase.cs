using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
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

        public List<ObtenerProductosPorTiendaResponseDto> ObtenerProductosPorTiendaResponse(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto)
        {
            var response = new List<ObtenerProductosPorTiendaResponseDto>();

            response = _productoRepository.ObtenerProductosPorTiendaResponse(obtenerProductosPorTiendaRequestDto);

            return response;
        }
    }
}
