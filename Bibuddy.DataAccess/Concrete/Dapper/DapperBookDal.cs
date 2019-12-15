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
    public class DapperBookDal : IBookDal
    {
        public void Add(book entity)
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

        public book Get(Expression<Func<book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAll(Expression<Func<book, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public book GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(book entity)
        {
            throw new NotImplementedException();
        }
    }
}
