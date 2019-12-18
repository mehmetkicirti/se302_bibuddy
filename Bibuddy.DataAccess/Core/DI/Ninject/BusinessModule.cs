using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Concrete.Dapper;
using Ninject.Modules;

namespace Bibuddy.DataAccess.Core.DI.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            #region DAL
            Bind<IArticleDal>().To<DapperArticleDal>().InSingletonScope();
            Bind<IBookDal>().To<DapperBookDal>().InSingletonScope();
            #endregion
        }
    }
}
