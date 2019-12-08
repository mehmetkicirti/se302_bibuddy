
using System.Data.Entity.ModelConfiguration;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
   public class BookletMap:EntityTypeConfiguration<booklet>
    {
        public BookletMap()
        {
            ToTable("booklet", "dbo").HasKey(b => b.ID);

            Property(b => b.ID).HasColumnName("ID");
            Property(b => b.year).HasColumnName("year");
            Property(b => b.address).HasColumnName("address");
            Property(b => b.author).HasColumnName("author");
            Property(b => b.howpublished).HasColumnName("howpublished");
            Property(b => b.month).HasColumnName("month");
            Property(b => b.title).HasColumnName("title");
            Property(b => b.note).HasColumnName("note");
        }
    }
}
