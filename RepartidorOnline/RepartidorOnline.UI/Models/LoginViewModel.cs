using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepartidorOnline.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="El campo usuario es obligatorio")]
        public string Login { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string Password { get; set; }
        public string MensajeValidacion { get; set; }
        public string ReturnUrl { get; set; }
    }
}