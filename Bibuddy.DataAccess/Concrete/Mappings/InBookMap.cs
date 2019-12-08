
using System.Data.Entity.ModelConfiguration;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
    public class InBookMap:EntityTypeConfiguration<inbook>
    {
        public InBookMap()
        {
            ToTable("inbook", "dbo").HasKey(i => i.ID);
            Property(i => i.year).HasColumnName("year");
            Property(i => i.address).HasColumnName("address");
            Property(i => i.author).HasColumnName("author");
            Property(i => i.chapter).HasColumnName("chapter");
            Property(i => i.edition).HasColumnName("edition");
            Property(i => i.month).HasColumnName("month");
            Property(i => i.pages).HasColumnName("pages");
            Property(i => i.publisher).HasColumnName("publisher");
            Property(i => i.series).HasColumnName("series");
            Property(i => i.title).HasColumnName("title");
            Property(i => i.volume).HasColumnName("volume");
            Property(i => i.note).HasColumnName("note");
            Property(i => i.ID).HasColumnName("ID");

        }
    }
}
