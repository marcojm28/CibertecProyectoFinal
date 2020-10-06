using RepartidorOnline.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.UseCases
{
    public interface IUsuarioUseCase
    {
        LoginResponseDto ValidarUsuario(LoginRequestDto loginRequestDto);

        CrearUsuarioResponseDTO CrearUsuario(CrearUsuarioRequestDTO crearUsuarioRequestDTO);
    }
}
