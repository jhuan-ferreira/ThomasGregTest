using System.Collections.Generic;

namespace ThomasGregTest.Data.Infraestruture
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        TEntity Save(TEntity entity);
        bool Delete(TEntity entity);
        void Dispose();

    }
}
