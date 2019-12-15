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
    public class DapperManualDal : IManualDal
    {
        public void Add(manual entity)
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

        public manual Get(Expression<Func<manual, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<manual> GetAll(Expression<Func<manual, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<manual> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<manual> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public manual GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(manual entity)
        {
            throw new NotImplementedException();
        }
    }
}
