using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BiBuddy.DataAccess.Concrete.Mapping;
using BiBuddy.Entities.Concrete;

namespace Bibuddy.DataAccess.DatabaseContext.Sqlite
{
    public class SqliteContext:DbContext
    {
        //private static string conString = Path.GetFullPath("se302_bibuddy");
        //String.Format(@"Data Source={0}\DB\BiBuddyDB.db;Version=3 providerName='System.Data.SQLite'",conString)
        public SqliteContext() : base("BiBuddyContext")
        {
            // İn here we did not have any migration so it can provide that it produced to block from coding. 
            Database.SetInitializer<SqliteContext>(null);
        }

        public DbSet<booklet> booklet { get; set; }
        public DbSet<article> article{ get; set; }
        public DbSet<book> book{ get; set; }
        public DbSet<conference> conference{ get; set; }
        public DbSet<inbook> inbook{ get; set; }
        public DbSet<incollection> incollection{ get; set; }
        public DbSet<manual> manual{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mapping tables injected
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new BookletMap());
            modelBuilder.Configurations.Add(new ConferenceMap());
            modelBuilder.Configurations.Add(new InBookMap());
            modelBuilder.Configurations.Add(new IncollectionMap());
            modelBuilder.Configurations.Add(new ManualMap());
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
