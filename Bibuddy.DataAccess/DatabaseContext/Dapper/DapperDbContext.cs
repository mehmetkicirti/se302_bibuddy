using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.DatabaseContext.Dapper
{
    public class DapperDbContext
    {
        private static IDbConnection _dbConnection;
        private static string con = Path.GetFullPath("se302_bibuddy");

        private static string[] path = con.Split(new string[] { "bin" }, StringSplitOptions.None);
        //private static string dbName = @"BiBuddyDB.db";
        private static string fullPath = String.Format(@"Data Source={0}BiBuddyDB.db", path[0]);
        public DapperDbContext()
        {
            _dbConnection = new SQLiteConnection(fullPath);
        }
        public static IDbConnection GetDbConnection()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteConnection(fullPath);
                return _dbConnection;
            }
            return _dbConnection;
        }
    }
}
