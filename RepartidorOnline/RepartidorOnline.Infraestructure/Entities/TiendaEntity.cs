using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Entities
{
    [Table("Tienda")]
    public class TiendaEntity
    {
        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public string ImagenSrc { get; set; }
        public string Descripcion { get; set; }
        public int EstadoRegistro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ClaseColor { get; set; }

    }
}
