using BiBuddy.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BiBuddy.Core.DataAccess
{
    //add limitation =>
    //Here class restriction used to reach from only reference type
    //new() => abstract and interface are a reference type ,so we are seperated from that.
    //IEntity => each classes can be able to have some specific for standard. 
    public interface IRepository<TEntity>
        where TEntity : class,IEntity,new()
    {
        void Add(TEntity entity);
        void Delete(int ID);
        void Update(TEntity entity);
        TEntity GetByID(int ID);
        TEntity Get(Expression<Func<TEntity,bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null);
        List<TEntity> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null);
        List<TEntity> GetAllByYear(int? year);
        int Count();
    }
}
