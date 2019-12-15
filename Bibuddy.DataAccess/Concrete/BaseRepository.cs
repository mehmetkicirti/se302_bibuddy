using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BiBuddy.Core.DataAccess;
using BiBuddy.Entities.Abstract;

namespace Bibuddy.DataAccess.Concrete
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity :class,IEntity,new()
        where TContext: DbContext,new()
    {
        private TContext _dbContext;
        public BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public int Count()
        {
            using (_dbContext = new TContext())
            {
                return _dbContext.Set<TEntity>().ToList().Count;
            }
        }

        public void Delete(int ID)
        {
            var entity = _dbContext.Set<TEntity>().Find(ID);
            if (entity == null)
                throw new Exception("Does not found any data");
            else
                _dbContext.Entry(entity).State=EntityState.Deleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbContext.Set<TEntity>().ToList() : _dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public List<TEntity> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(int ID)
        {
            return _dbContext.Set<TEntity>().Find(ID);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}