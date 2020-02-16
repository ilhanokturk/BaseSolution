using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Lastname).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.PasswordHash).HasColumnType("varbinary(MAX)").IsRequired(true);
            builder.Property(x => x.PasswordSalt).HasColumnType("varbinary(MAX)").IsRequired(true);
            builder.Property(x => x.LockoutEnabled).IsRequired(true).HasDefaultValue(true);
            builder.Property(x => x.LockoutEnd).HasColumnType("datetimeoffset(7)").IsRequired(false);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
        }
    }
}
