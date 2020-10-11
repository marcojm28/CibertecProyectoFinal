using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI.Models
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public int IdTienda { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public string ImagenSrc { get; set; }
    }
}