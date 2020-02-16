using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Content).HasColumnType("text").IsRequired(true);
            builder.Property(x => x.Slug).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.ViewCount).IsRequired(false).HasDefaultValue(false);
            builder.Property(x => x.Author).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.IsSlide).IsRequired(false).HasDefaultValue(false);
            builder.Property(x => x.IsPublish).IsRequired(false).HasDefaultValue(false);
            builder.Property(x => x.IsDeleted).IsRequired(false).HasDefaultValue(false);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.RowVersion).IsRowVersion();


            builder.HasOne(x => x.Category).WithMany(c => c.Articles).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
