using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.DTO.Products
{
    public class ObtenerProductosPorTiendaResponseDto
    {
        public int IdProducto { get; set; }
        public int IdTienda { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string ImagenSrc { get; set; }

    }
    public class ObtenerProductosPorTiendaRequestDto
    {
        public int IdProducto { get; set; }
        public int IdTienda { get; set; }
        public string NombreProducto { get; set; }
    }

}
