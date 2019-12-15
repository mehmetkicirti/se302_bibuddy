using System.Collections.Generic;
using BiBuddy.Entities.Abstract;

namespace Bibuddy.Business.Abstract
{
	public interface IService<TEntity>
		where TEntity : class, IEntity, new()
	{
		List<TEntity> GetList();
		TEntity GetById(int ID);
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(int ID);

		int Count();
		List<TEntity> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null);
		List<TEntity> GetAllByYear(int? year);
		//void importBibTextFile(TEntity entity);
	}
}