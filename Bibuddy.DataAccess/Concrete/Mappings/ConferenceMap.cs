using System.Data.Entity.ModelConfiguration;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
    public class ConferenceMap:EntityTypeConfiguration<conference>
    {
        public ConferenceMap()
        {
            ToTable("conference", "dbo").HasKey(c => c.ID);

            Property(c => c.ID).HasColumnName("ID");
            Property(c => c.year).HasColumnName("year");
            Property(c => c.address).HasColumnName("address");
            Property(c => c.author).HasColumnName("author");
            Property(c => c.booktitle).HasColumnName("booktitle");
            Property(c => c.editor).HasColumnName("editor");
            Property(c => c.month).HasColumnName("month");
            Property(c => c.organization).HasColumnName("organization");
            Property(c => c.pages).HasColumnName("pages");
            Property(c => c.publisher).HasColumnName("publisher");
            Property(c => c.series).HasColumnName("series");
            Property(c => c.title).HasColumnName("title");
            Property(c => c.note).HasColumnName("note");
            Property(c => c.volume).HasColumnName("volume");
        }
    }
}