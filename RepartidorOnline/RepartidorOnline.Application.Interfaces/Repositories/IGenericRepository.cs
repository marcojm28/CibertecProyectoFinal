﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartidorOnline.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity>
            where TEntity : class
    {
        TKey Add<TKey>(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(object id);
        List<TEntity> GetList();
    }
}
