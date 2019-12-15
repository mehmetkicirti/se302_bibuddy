using Bibuddy.Business.Abstract;
using Bibuddy.DataAccess.Abstract;
using BiBuddy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.Business.Concrete.Dapper
{
    public class DapperBookManager : IBookService
    {
        private readonly IBookDal _iBookDal;
        public DapperBookManager(IBookDal bookDal)
        {
            _iBookDal = bookDal;
        }
        public void Add(book entity)
        {
            _iBookDal.Add(entity);
        }

        public int Count()
        {
            return _iBookDal.Count();
        }

        public void Delete(int ID)
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

        public book GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public List<book> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(book entity)
        {
            throw new NotImplementedException();
        }
    }
}
