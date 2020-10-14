using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.UseCases
{
    public interface IProductoUseCase
    {
        List<Producto> ObtenerProductosPorTienda(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto);
    }
}
