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
    public class DapperInbookDal : IInbookDal
    {
        public void Add(inbook entity)
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

        public inbook Get(Expression<Func<inbook, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<inbook> GetAll(Expression<Func<inbook, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<inbook> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<inbook> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public inbook GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(inbook entity)
        {
            throw new NotImplementedException();
        }
    }
}
