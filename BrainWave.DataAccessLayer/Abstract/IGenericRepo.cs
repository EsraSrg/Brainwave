using System.Collections.Generic;

namespace BrainWave.DataAccessLayer.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        List<TEntity> GetList();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
