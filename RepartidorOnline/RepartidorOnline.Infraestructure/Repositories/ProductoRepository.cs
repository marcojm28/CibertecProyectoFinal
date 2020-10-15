using Dapper;
using RepartidorOnline.Application.DTO.Products;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Domain.Products;
using RepartidorOnline.Infraestructure.Database;
using RepartidorOnline.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>,IProductoRepository
    {
        public List<ObtenerProductosPorTiendaResponseDto> ObtenerProductosPorTienda(ObtenerProductosPorTiendaRequestDto obtenerProductosPorTiendaRequestDto)
        {
            var listaProductos = new List<ObtenerProductosPorTiendaResponseDto>();
            var listaEntity = new List<ProductoEntity>();
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                if (string.IsNullOrWhiteSpace(obtenerProductosPorTiendaRequestDto.NombreProducto))
                {
                    if (obtenerProductosPorTiendaRequestDto.IdTienda == 0)
                    {
                        listaEntity = db.GetList<ProductoEntity>("where EstadoRegistro = 1").ToList();
                    }
                    else {
                        listaEntity = db.GetList<ProductoEntity>("where EstadoRegistro = 1 and IdTienda = @IdTienda", new { IdTienda = obtenerProductosPorTiendaRequestDto.IdTienda }).ToList();
                    }
                    
                }
                else 
                {
                    var paramNombre = string.IsNullOrWhiteSpace(obtenerProductosPorTiendaRequestDto.NombreProducto) ? null : $"%{obtenerProductosPorTiendaRequestDto.NombreProducto.Trim()}%";
                    listaEntity = db.GetList<ProductoEntity>("where EstadoRegistro = 1 and NombreProducto like @NombreProducto", new 
                    { 
                        NombreProducto = paramNombre 
                    }).ToList();
                }



            }

            listaProductos.AddRange(MapingProductoEntity(listaEntity));

            return listaProductos;
        }


        #region Métodos internos

        private List<ObtenerProductosPorTiendaResponseDto> MapingProductoEntity(List<ProductoEntity> productos)
        {
            var ListaProductos = new List<ObtenerProductosPorTiendaResponseDto>();

            foreach (var item in productos)
            {
                ObtenerProductosPorTiendaResponseDto obj = new ObtenerProductosPorTiendaResponseDto()
                {
                    IdTienda = item.IdTienda,
                    IdProducto = item.IdProducto,
                    Descripcion = item.Descripcion,
                    ImagenSrc = item.ImagenSrc,
                    NombreProducto = item.NombreProducto,
                    Stock = item.Stock,
                    Precio = item.Precio
                };

                ListaProductos.Add(obj);
            }

            return ListaProductos;
        }

        #endregion
    }
}
