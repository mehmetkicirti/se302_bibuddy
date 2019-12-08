using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    //To Solid Principlies being D => Dependency Inversion principle
    // So NHibernate,Dapper,EF orm can be able to use and also belonging to interface this classes to reduce loyalty.
    public class ArticleDal:BaseRepository<article,SqliteContext>,IArticleDal
    {
        public ArticleDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}
