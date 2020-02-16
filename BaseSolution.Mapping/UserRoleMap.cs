using BaseSolution.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("RolesofUsers");
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.Property(x => x.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(x => x.UpdateDate).HasColumnType("datetime").IsRequired(false);

            builder.HasOne(x => x.User).WithMany(y => y.UserRoles).HasForeignKey(x => x.UserId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Role).WithMany(y => y.UserRoles).HasForeignKey(x => x.RoleId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
