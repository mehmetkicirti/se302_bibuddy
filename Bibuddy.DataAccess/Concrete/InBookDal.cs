using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class InBookDal:BaseRepository<inbook,SqliteContext>,IInbookDal
    {
        public InBookDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}
