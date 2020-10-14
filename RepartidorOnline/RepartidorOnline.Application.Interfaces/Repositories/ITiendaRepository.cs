using RepartidorOnline.Application.DTO.Stores;
using RepartidorOnline.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface ITiendaRepository : IGenericRepository<Tienda>
    {
        List<ObtenerTiendasResponseDto> ObtenerTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto);
    }
}
