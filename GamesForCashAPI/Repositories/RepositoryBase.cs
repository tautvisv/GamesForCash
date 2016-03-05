using System;
using System.Collections.Generic;
using Models;

namespace Repositories
{
    public class RepositoryBase<TEntity>:IBaseRepository<TEntity> where TEntity: BaseEntity, new()
    {
        public TEntity Get(int id)
        {
            return  new TEntity();
        }

        public int Update(TEntity entity)
        {
            return -1;
        }

        public int Insert(TEntity entity)
        {
            return -1;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public ICollection<TEntity> List()
        {
            var list = new List<TEntity>();
            list.Add(new TEntity());
            list.Add(new TEntity());
            list.Add(new TEntity());
            return list;
        }
    }
}