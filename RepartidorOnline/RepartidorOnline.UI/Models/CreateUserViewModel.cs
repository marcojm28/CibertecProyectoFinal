using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string DireccionDomicilio { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Distrito { get; set; }
    }
}