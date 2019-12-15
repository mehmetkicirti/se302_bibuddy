using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibuddy.Business.Abstract;
using Bibuddy.DataAccess.Abstract;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.Business.Concrete.Dapper
{
	public class DapperArticleManager : IArticleService
	{
		private readonly IArticleDal _iArticleDal;

		public DapperArticleManager(IArticleDal articleDal)
		{
			_iArticleDal = articleDal;
		}

		public void Add(article entity)
		{
			_iArticleDal.Add(entity);
		}

		public int Count()
		{
			return _iArticleDal.Count();
			
		}

		public void Delete(int ID)
		{
			_iArticleDal.Delete(ID);
		}

		public List<article> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
		{
			return _iArticleDal.GetAllByAuthorOrTitleIfNotExist(author, title);
		}

		public List<article> GetAllByYear(int? year)
		{
			return _iArticleDal.GetAllByYear(year);
		}

		public article GetById(int ID)
		{
			return _iArticleDal.GetByID(ID);
		}

		public List<article> GetList()
		{
			throw new NotImplementedException();
		}

		public List<article> GetListByAuthorName(string name)
		{
			throw new NotImplementedException();
		}

		public List<article> GetListByMonth(int month)
		{
			throw new NotImplementedException();
		}

		public List<article> GetListByYear(int year)
		{
			throw new NotImplementedException();
		}

		public void Update(article entity)
		{
			_iArticleDal.Update(entity);
		}
	}
}
