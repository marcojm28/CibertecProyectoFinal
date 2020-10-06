using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.DTO.Users
{
    public class CrearUsuarioRequestDTO
    {
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

    public class CrearUsuarioResponseDTO
    {
        public int IdUsuarioNuevo { get; set; }

        public int IndicadorRespuesta{ get; set; }

        public string MensajeValidacion { get; set; }
    }
}
