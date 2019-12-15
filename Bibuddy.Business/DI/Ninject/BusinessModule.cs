
using Bibuddy.Business.Abstract;
using Bibuddy.Business.Concrete;
using Bibuddy.Business.Concrete.Dapper;
using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Concrete;
using Bibuddy.DataAccess.Concrete.Dapper;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using Ninject.Modules;

namespace Bibuddy.Business.DI.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            #region DAL
            Bind<IArticleDal>().To<DapperArticleDal>().InSingletonScope();
            Bind<IBookDal>().To<DapperBookDal>().InSingletonScope();
            Bind<IBookletDal>().To<BookletDal>().InSingletonScope();
            Bind<IConferenceDal>().To<ConferenceDal>().InSingletonScope();
            Bind<IInbookDal>().To<InBookDal>().InSingletonScope();
            Bind<IManualDal>().To<ManualDal>().InSingletonScope();
            Bind<IIncollectionDal>().To<InCollectionDal>().InSingletonScope();
            #endregion

            #region Manager

            Bind<IUnitOfWork>().To<UnitOfWork<SqliteContext>>();
            Bind<IArticleService>().To<DapperArticleManager>();
            Bind<IBookService>().To<DapperBookManager>();

            #endregion
        }
    }
}
