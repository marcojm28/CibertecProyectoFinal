using RepartidorOnline.Domain.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI.Models
{
    public class CreateProductoViewModel
    {
        [Key]
        public int IdProducto { get; set; }

        [Display(Name = "Tienda")]
        public int IdTienda { get; set; }

        [Required(ErrorMessage = "Campo nombre es requerido")]
        [Display(Name = "Nombre")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Campo descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo stock es requerido")]
        [Range(1, 5000, ErrorMessage = "Valor fuera del rango")]
        public int Stock { get; set; }

        [Required(ErrorMessage ="Campo precio es requerido")]
        [Range(1, 50000, ErrorMessage = "Valor fuera del rango")]
        public decimal Precio { get; set; }

        public List<Tienda> tiendas { get; set; }
    }
}