using System.Collections.Generic;
using System.Linq;
using Bibuddy.Business.Abstract;
using Bibuddy.Business.ValidationRules.FluentValidation;
using Bibuddy.Core.AOP.Validations.FluentValidation;
using Bibuddy.DataAccess.Abstract;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.Business.Concrete
{
    public class ArticleManager:BaseService<IArticleDal,article>,IArticleService
    { 
        public ArticleManager(IArticleDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }

        public List<article> GetList()
        {
            return _dal.GetAll();
        }

        public article GetById(int ID)
        {
            return _dal.GetByID(ID);
        }
        public void Add(article entity)
        {
            //export or import if there is,it will be coding into
             ToolValidator.FluentValidate(new ArticleValidate(),entity);
            _dal.Add(entity);
            _unitOfWork.CompleteTask();
        }

        public void Update(article entity)
        {
            ToolValidator.FluentValidate(new ArticleValidate(), entity);
            _dal.Update(entity);
            _unitOfWork.CompleteTask();
        }

        public void Delete(int ID)
        {
            //if import file deleted it will be coding into file 
            _dal.Delete(ID);
            _unitOfWork.CompleteTask();
        }

        public List<article> GetListByYear(int year)
        {
            return _dal.GetAll(a => a.year == year).ToList();
        }

        public List<article> GetListByMonth(int month)
        {
            return _dal.GetAll(a => a.month == month).ToList();
        }

        public List<article> GetListByAuthorName(string name)
        {
            return name.Length > 0
                ? _dal.GetAll(a => a.author.ToLower().Contains(name.ToLower())).ToList()
                : _dal.GetAll();
        }

        public void importBibTextFile(article entity)
        {
            
        }

		public int Count()
		{
			throw new System.NotImplementedException();
		}

		public List<article> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
		{
			throw new System.NotImplementedException();
		}

		public List<article> GetAllByYear(int? year)
		{
			throw new System.NotImplementedException();
		}
	}
}
