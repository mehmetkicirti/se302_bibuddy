using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class InCollectionDal:BaseRepository<incollection,SqliteContext>,IIncollectionDal
    {
        public InCollectionDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}