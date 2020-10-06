using RepartidorOnline.Application.DTO.Users;
using RepartidorOnline.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Get(string login);

        Usuario Add(CrearUsuarioRequestDTO crearUsuarioRequestDTO);
    }
}
