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
            Bind<IBookletDal>().To<DapperBookletDal>().InSingletonScope();
            Bind<IConferenceDal>().To<DapperConferenceDal>().InSingletonScope();
            Bind<IInbookDal>().To<DapperInbookDal>().InSingletonScope();
            Bind<IIncollectionDal>().To<DapperIncollectionDal>().InSingletonScope();
            Bind<IManualDal>().To<DapperManualDal>().InSingletonScope();

            #endregion
        }
    }
}
