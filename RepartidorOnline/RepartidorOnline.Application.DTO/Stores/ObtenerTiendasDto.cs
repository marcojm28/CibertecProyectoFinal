using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.DTO.Stores
{
    public class ObtenerTiendasResponseDto
    {
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public string ImagenSrc { get; set; }
        public string Descripcion { get; set; }
        public string ClaseColor { get; set; }
    }

    public class ObtenerTiendasRequestDto
    {
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
    }
}
