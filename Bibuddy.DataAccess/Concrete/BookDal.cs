using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.Concrete
{
    public class BookDal:BaseRepository<book,SqliteContext>,IBookDal
    {
        public BookDal(SqliteContext dbContext) : base(dbContext)
        {
        }
    }
}
