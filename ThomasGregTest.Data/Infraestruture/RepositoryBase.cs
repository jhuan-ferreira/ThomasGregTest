using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ThomasGregTest.Data.Infraestruture
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new ()
    {
        private readonly DbContext dbContext;
        
        protected virtual DbContext Context { get { return dbContext; } }

        public RepositoryBase(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            this.dbContext = dbContext;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return dbContext.Set<TEntity>();
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity Save(TEntity entity)
        {
            var firstColumn = entity.GetType().GetProperties().Select(x => x.Name).FirstOrDefault();
            var id = Convert.ToInt64(entity.GetType().GetProperty(firstColumn).GetValue(entity).ToString());

            if (id == 0)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }

            dbContext.SaveChanges();

            return entity;
        }
    }
}
