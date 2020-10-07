using Dapper;
using RepartidorOnline.Application.DTO.Stores;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Infraestructure.Database;
using RepartidorOnline.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Repositories
{
    public class TiendaRepository : ITiendaRepository
    {
        public List<ObtenerTiendasResponseDto> ObtenerTiendas(ObtenerTiendasRequestDto obtenerTiendasRequestDto)
        {
            var ListaTiendas = new List<ObtenerTiendasResponseDto>();
            var tiendas = new List<TiendaEntity>();
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                tiendas = db.GetList<TiendaEntity>(new { EstadoRegistro = 1 }).ToList();
            }

            foreach (var item in tiendas) 
            {
                ObtenerTiendasResponseDto obj = new ObtenerTiendasResponseDto()
                {
                    ClaseColor = item.ClaseColor,
                    Descripcion = item.Descripcion,
                    IdTienda = item.IdTienda,
                    ImagenSrc = item.ImagenSrc,
                    NombreTienda = item.NombreTienda
                };

                ListaTiendas.Add(obj);
            }

            return ListaTiendas;
        }
    }
}
