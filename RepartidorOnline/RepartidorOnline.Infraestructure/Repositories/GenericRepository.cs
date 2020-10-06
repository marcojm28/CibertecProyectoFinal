using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Domain.Users;
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
        public TEntity Add(TEntity entity)
        {
            return null;
        }

        public TEntity Get(int id)
        {
            return null;
        }

        public void Remove(TEntity entity)
        {

        }

        public void Update(TEntity entity)
        {

        }
    }
}
