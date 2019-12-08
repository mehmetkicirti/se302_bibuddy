using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class ManualDal:BaseRepository<manual,SqliteContext>,IManualDal
    {
        public ManualDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}