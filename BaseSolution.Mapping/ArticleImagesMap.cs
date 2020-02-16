using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class ArticleImagesMap : IEntityTypeConfiguration<ArticleImage>
    {
        public void Configure(EntityTypeBuilder<ArticleImage> builder)
        {
            builder.ToTable("ImagesofArticles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Url).HasMaxLength(100).IsRequired(true);
            builder.Property(x=>x.Slug).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

            builder.HasOne(x => x.Article).WithMany(c => c.ArticleImages).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
