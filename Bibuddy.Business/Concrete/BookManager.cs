using Bibuddy.Business.Abstract;
using Bibuddy.DataAccess.Abstract;
using BiBuddy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.Business.Concrete
{
    public class BookManager : BaseService<IBookDal, book>, IBookService
    {
        public BookManager(IBookDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }

        public void Add(book entity)
        {
            _dal.Add(entity);

            _unitOfWork.CompleteTask();

        }

		public int Count()
		{
			throw new NotImplementedException();
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

        public void importBibTextFile(book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(book entity)
        {
            throw new NotImplementedException();
        }
    }
}
