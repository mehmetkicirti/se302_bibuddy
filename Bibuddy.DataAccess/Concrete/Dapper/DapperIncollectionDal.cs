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
    public class DapperIncollectionDal : IIncollectionDal
    {
        public void Add(incollection entity)
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

        public incollection Get(Expression<Func<incollection, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<incollection> GetAll(Expression<Func<incollection, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<incollection> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<incollection> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public incollection GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(incollection entity)
        {
            throw new NotImplementedException();
        }
    }
}
