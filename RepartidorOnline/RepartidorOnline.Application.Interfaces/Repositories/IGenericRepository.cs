using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity>
            where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
    }
}
