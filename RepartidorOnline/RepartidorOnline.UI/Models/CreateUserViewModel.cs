using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="Campo usuario es obligatiorio")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Campo contreseña es obligatiorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Campo nombres es obligatiorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo Apellidos es obligatiorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo correo es obligatiorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Campo teléfono es obligatiorio")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo dirección es obligatiorio")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        public string DireccionDomicilio { get; set; }

        [Required(ErrorMessage = "Campo ciudad es obligatiorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Campo Distrito es obligatiorio")]
        public string Distrito { get; set; }
    }
}