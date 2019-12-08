using System.Data.Entity.ModelConfiguration;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
    public class ManualMap:EntityTypeConfiguration<manual>
    {
        public ManualMap()
        {
            ToTable("manual", "dbo").HasKey(m => m.ID);

            Property(m => m.year).HasColumnName("year");
            Property(m => m.ID).HasColumnName("ID");
            Property(m => m.address).HasColumnName("address");
            Property(m => m.author).HasColumnName("author");
            Property(m => m.edition).HasColumnName("edition");
            Property(m => m.month).HasColumnName("month");
            Property(m => m.organization).HasColumnName("organization");
            Property(m => m.note).HasColumnName("note");
            Property(m => m.title).HasColumnName("title");
        }
    }
}