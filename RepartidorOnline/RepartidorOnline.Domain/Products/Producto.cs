using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Domain.Products
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public int IdTienda { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string ImagenSrc { get; set; }
        public int EstadoRegistro { get; set; }

    }
}
