using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class BookletDal:BaseRepository<booklet,SqliteContext>,IBookletDal
    {
        public BookletDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}
