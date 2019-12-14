using System.Collections.Generic;
using BiBuddy.Entities.Abstract;

namespace Bibuddy.Business.Abstract
{
    public interface IService<TEntity>
        where  TEntity : class,IEntity,new()
    {
        List<TEntity> GetList();
        TEntity GetById(int ID);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int ID);

        void importBibTextFile(TEntity entity);
    }
}