using RepartidorOnline.Application.DTO.Stores;
using RepartidorOnline.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.UseCases
{
    public interface ITiendaUseCase
    {
        List<Tienda> ObtenerTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto);
        List<Tienda> GetList();
    }
}
