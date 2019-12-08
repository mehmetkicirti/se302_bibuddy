using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class ConferenceDal:BaseRepository<conference,SqliteContext>,IConferenceDal
    {
        public ConferenceDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}
