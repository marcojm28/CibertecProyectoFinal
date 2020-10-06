using RepartidorOnline.Application.Common;
using RepartidorOnline.Application.DTO.Users;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.UseCases
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioUseCase(IUsuarioRepository usuarioRepository) 
        {
            this._usuarioRepository = usuarioRepository;
        }

        public LoginResponseDto ValidarUsuario(LoginRequestDto loginRequestDto)
        {
            LoginResponseDto response = null;

            var usuario = _usuarioRepository.Get(loginRequestDto.NombreUsuario);

            if (usuario != null) 
            {
                //string password = string.Empty;
                //password = ConvertPasswordToSha512(usuario.Contrasena);

                if (usuario.Contrasena == loginRequestDto.Contrasena) 
                {
                    response = LoginMapping(usuario);

                    return response;
                }
            }

            return response;
        }


        public CrearUsuarioResponseDTO CrearUsuario(CrearUsuarioRequestDTO crearUsuarioRequestDTO)
        {
            CrearUsuarioResponseDTO response = new CrearUsuarioResponseDTO();

            var usuarioValidacion = _usuarioRepository.Get(crearUsuarioRequestDTO.NombreUsuario);

            if (usuarioValidacion == null)
            {
                var usuario = _usuarioRepository.Add(crearUsuarioRequestDTO);

                response.IdUsuarioNuevo = usuario.IdUsuario;

                if (response.IdUsuarioNuevo > 0)
                {
                    response.IndicadorRespuesta = Enumerados.RespuestaCrearUsuario.IndicadorUsuarioCreado;
                    response.MensajeValidacion = Enumerados.RespuestaCrearUsuario.MensajeUsuarioCreado;
                }
            }
            else 
            {
                response.MensajeValidacion = Enumerados.RespuestaCrearUsuario.MensajeUsuarioExistente;
            }

            return response;
        }

        #region Métodos internos
        private LoginResponseDto LoginMapping(Usuario usuario)
        {
            return new LoginResponseDto()
            {
                IdUsuario = usuario.IdUsuario,
                IdRol = usuario.IdRol,
                NombreUsuario = usuario.NombreUsuario,
                Contrasena = usuario.Contrasena,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                DireccionDomicilio = usuario.DireccionDomicilio,
                Ciudad = usuario.Ciudad,
                Distrito = usuario.Distrito
            };
        }


        private static string ConvertPasswordToSha512(string password)
        {
            string result = string.Empty;
            if (!String.IsNullOrEmpty(password))
            {
                try
                {
                    var data = Encoding.UTF8.GetBytes(password);
                    using (SHA512 shaM = new SHA512Managed())
                    {
                        result = ByteArrayToString(shaM.ComputeHash(data));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return result;
        }

        private static string ByteArrayToString(byte[] passwordByte)
        {
            string hex = BitConverter.ToString(passwordByte);
            return hex.Replace("-", "");
        }
        #endregion
    }
}
