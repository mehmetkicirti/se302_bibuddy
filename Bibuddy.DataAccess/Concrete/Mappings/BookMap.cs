using System.Data.Entity.ModelConfiguration;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
    public class BookMap:EntityTypeConfiguration<book>
    {
        public BookMap()
        {
            ToTable(@"book", "dbo").HasKey(b=>b.ID);

            Property(b => b.ID).HasColumnName("ID");
            Property(b => b.year).HasColumnName("year");
            Property(b => b.address).HasColumnName("address");
            Property(b => b.author).HasColumnName("author");
            Property(b => b.edition).HasColumnName("edition");
            Property(b => b.entrytype).HasColumnName("entrytype");
            Property(b => b.url).HasColumnName("url");
            Property(b => b.month).HasColumnName("month");
            Property(b => b.series).HasColumnName("series");
            Property(b => b.title).HasColumnName("title");
            Property(b => b.volume).HasColumnName("volume");
            Property(b => b.note).HasColumnName("note");
        }
    }
}
