using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class ArticleCommentMap : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.ToTable("CommentsOfArticles");
            builder.HasKey(x => new { x.ArticleId, x.CommentId, x.UserId });

            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

            builder.HasOne(x => x.Article).WithMany(y => y.ArticleComments).HasForeignKey(x => x.ArticleId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Comment).WithMany(y => y.ArticleComments).HasForeignKey(x => x.CommentId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithMany(y => y.ArticleComments).HasForeignKey(x => x.UserId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
