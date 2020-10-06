using Dapper;
using RepartidorOnline.Application.DTO.Users;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Domain.Users;
using RepartidorOnline.Infraestructure.Database;
using RepartidorOnline.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Get(string login)
        {
            Usuario usuario = new Usuario();

            using (var db = DatabaseUtil.CreateDBConnection())
            {
                usuario = db.QuerySingleOrDefault<Usuario>("dbo.usp_ObtenerUsuario",
                    new { Usuario = login },
                    commandType: CommandType.StoredProcedure);
            }

            return usuario;

        }

        public Usuario Add(CrearUsuarioRequestDTO crearUsuarioRequestDTO)
        {
            Usuario usuario = new Usuario();

            using (var db = DatabaseUtil.CreateDBConnection()) 
            {
                var newId = db.Insert(new UsuarioEntity
                {
                    NombreUsuario = crearUsuarioRequestDTO.NombreUsuario,
                    Apellidos = crearUsuarioRequestDTO.Apellidos,
                    Ciudad = crearUsuarioRequestDTO.Ciudad,
                    Contrasena = crearUsuarioRequestDTO.Contrasena,
                    Correo = crearUsuarioRequestDTO.Correo,
                    DireccionDomicilio = crearUsuarioRequestDTO.DireccionDomicilio,
                    Distrito = crearUsuarioRequestDTO.Distrito,
                    Nombres = crearUsuarioRequestDTO.Nombres,
                    Telefono = crearUsuarioRequestDTO.Telefono,
                    IdRol = 2
                });

                if (newId.Value > 0)
                    usuario.IdUsuario = newId.Value;
            }

            return usuario;

        }
    }
}
