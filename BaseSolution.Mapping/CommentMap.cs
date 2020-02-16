using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Message).HasMaxLength(300).IsRequired(true);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
        }
    }
}
