using Dapper;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Domain.Users;
using RepartidorOnline.Infraestructure.Database;
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
    }
}
