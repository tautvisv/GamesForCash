using System.Collections.Generic;
using Models;

namespace Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        TEntity Get(int id);
        int Update(TEntity entity);
        int Insert(TEntity entity);
        bool Delete(int id);
        ICollection<TEntity> List();
    }
}