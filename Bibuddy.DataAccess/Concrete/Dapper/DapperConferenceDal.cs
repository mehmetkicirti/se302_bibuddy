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
    public class DapperConferenceDal : IConferenceDal
    {
        public void Add(conference entity)
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

        public conference Get(Expression<Func<conference, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<conference> GetAll(Expression<Func<conference, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<conference> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<conference> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public conference GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(conference entity)
        {
            throw new NotImplementedException();
        }
    }
}
