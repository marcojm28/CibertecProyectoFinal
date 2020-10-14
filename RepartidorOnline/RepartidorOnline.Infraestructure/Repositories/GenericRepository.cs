using Dapper;
using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Domain.Users;
using RepartidorOnline.Infraestructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Infraestructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
            where TEntity : class
    {
        public TKey Add<TKey>(TEntity entity)
        {
            TKey retorno;
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                retorno = db.Insert<TKey, TEntity>(entity);
            }

            return retorno;
        }

        public TEntity Get(object id)
        {
            TEntity retorno = null;
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                retorno = db.Get<TEntity>(id);
            }

            return retorno;

        }

        public List<TEntity> GetList()
        {
            List<TEntity> retorno = new List<TEntity>();
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                retorno = db.GetList<TEntity>().ToList();
            }

            return retorno;
        }

        public void Remove(TEntity entity)
        {
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                db.Delete<TEntity>(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = DatabaseUtil.CreateDBConnection())
            {
                db.Update<TEntity>(entity);
            }
        }
    }
}
