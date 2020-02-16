using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RoleName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);
        }
    }
}
