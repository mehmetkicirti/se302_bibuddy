using BiBuddy.Core.DataAccess;
using Bibuddy.Business.Abstract;
using BiBuddy.Entities.Abstract;

namespace Bibuddy.Business.Concrete
{
    // burada gelicek herhangi bir dal bize hem bagımlılıgını azaltıcak hemde verdigimiz soyut nesnenin somutunu vermiş olucak
    // Solid principle ' nin D harfi olan dependency inversion icin gerekli
    public class BaseService<TDal,TEntity>
        where TDal:IRepository<TEntity>
        where TEntity:class,IEntity,new()
    {
        protected readonly TDal _dal;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(TDal dal, IUnitOfWork unitOfWork)
        {
            _dal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}
