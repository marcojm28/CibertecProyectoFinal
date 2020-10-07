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
                if (string.IsNullOrWhiteSpace(obtenerTiendasRequestDto.NombreTienda))
                {
                    tiendas = db.GetList<TiendaEntity>(new { EstadoRegistro = 1 }).ToList();
                }
                else {
                    var paramNombre = string.IsNullOrWhiteSpace(obtenerTiendasRequestDto.NombreTienda) ? null : $"%{obtenerTiendasRequestDto.NombreTienda.Trim()}%";
                    tiendas = db.GetList<TiendaEntity>("where EstadoRegistro = 1 and NombreTienda like @NombreTienda", new { NombreTienda = paramNombre }).ToList();

                }
                
            }

            ListaTiendas.AddRange(MapingTiendasEntity(tiendas));

            return ListaTiendas;
        }

        #region Métodos internos

        private List<ObtenerTiendasResponseDto> MapingTiendasEntity(List<TiendaEntity> tiendas) 
        {
            var ListaTiendas = new List<ObtenerTiendasResponseDto>();

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

        #endregion
    }
}
