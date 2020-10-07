using RepartidorOnline.Application.DTO.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface ITiendaRepository
    {
        List<ObtenerTiendasResponseDto> ObtenerTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto);
    }
}
