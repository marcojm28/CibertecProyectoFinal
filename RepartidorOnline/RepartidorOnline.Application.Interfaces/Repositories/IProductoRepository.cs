using RepartidorOnline.Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        List<ObtenerProductosPorTiendaResponseDto> ObtenerProductosPorTienda(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto);
    }
}
