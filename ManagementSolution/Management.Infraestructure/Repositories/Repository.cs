using Management.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Management.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual List<TEntity> List()
        {
            return this._dbContext.Set<TEntity>().ToList();
        }

        public virtual void Save(TEntity Entity)
        {
            this._dbContext.Set<TEntity>().Add(Entity);
        }

        public virtual void Delete(TEntity Entity)
        {
            this._dbContext.Set<TEntity>().Remove(Entity);
        }

        public virtual TEntity FindById(int Id)
        {
            return this._dbContext.Set<TEntity>().Find(Id);
        }

        public virtual void Update(TEntity Entity)
        {
            this._dbContext.Set<TEntity>().Update(Entity);
        }
    }
}
