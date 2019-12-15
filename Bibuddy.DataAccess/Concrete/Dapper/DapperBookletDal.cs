using Bibuddy.DataAccess.Abstract;
using BiBuddy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Concrete.Dapper
{
    public class DapperBookletDal : IBookletDal
    {
        public void Add(booklet entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public booklet Get(Expression<Func<booklet, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<booklet> GetAll(Expression<Func<booklet, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<booklet> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<booklet> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public booklet GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(booklet entity)
        {
            throw new NotImplementedException();
        }
    }
}
