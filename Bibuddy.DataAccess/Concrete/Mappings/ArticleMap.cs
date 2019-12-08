using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.DataAccess.Concrete.Mapping
{
    public class ArticleMap:EntityTypeConfiguration<article>
    {
        public ArticleMap()
        {
            ToTable(@"article", @"dbo")
                .HasKey(x => x.ID);
            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.year).HasColumnName("year");
            Property(x => x.author).HasColumnName("author");
            Property(x => x.journal).HasColumnName("journal");
            Property(x => x.month).HasColumnName("month");
            Property(x => x.number).HasColumnName("number");
            Property(x => x.pages).HasColumnName("pages");
            Property(x => x.title).HasColumnName("title");
            Property(x => x.volume).HasColumnName("volume");
            Property(x => x.note).HasColumnName("note");
        }
    }
}
