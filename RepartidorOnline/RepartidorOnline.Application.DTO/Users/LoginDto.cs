using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.DTO.Users
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "El campo usuario es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        public string Contrasena { get; set; }
    }
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string DireccionDomicilio { get; set; }
        public string Ciudad { get; set; }
        public string Distrito { get; set; }
    }
}
