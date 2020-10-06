using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Common
{
    public class Enumerados
    {
        public struct RespuestaCrearUsuario 
        {
            public const int IndicadorUsuarioCreado = 1;

            public const string MensajeUsuarioCreado = "Usuario creado correctamente";

            public const string MensajeUsuarioExistente = "El nombre de usuario ya existe";
        }
    }
}
