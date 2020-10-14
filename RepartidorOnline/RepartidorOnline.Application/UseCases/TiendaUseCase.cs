using RepartidorOnline.Application.DTO.Stores;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.UseCases
{
    public class TiendaUseCase : ITiendaUseCase
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaUseCase(ITiendaRepository tiendaRepository) 
        {
            this._tiendaRepository = tiendaRepository;
        }

        public List<Tienda> GetList() 
        {
           return _tiendaRepository.GetList();
        }

        public List<Tienda> ObtenerTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto)
        {
            var response = new List<Tienda>();
            var responseRepository = new List<ObtenerTiendasResponseDto>();

            responseRepository = _tiendaRepository.ObtenerTiendas(obtenerTiendasRequestDto);

            return response;
        }
    }
}
