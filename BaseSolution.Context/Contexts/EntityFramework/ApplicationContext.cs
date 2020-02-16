using BaseSolution.Entity;
using BaseSolution.Entity.Base;
using BaseSolution.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BaseSolution.Context.Contexts.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        /*
         !!!Create DbSet<Entity> 
             */
        #region DbSet properties

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connection = @"Data Source=DESKTOP-UHPJU3L;Initial Catalog=TestDB;Integrated Security=True;Pooling=False";
        //    optionsBuilder.UseSqlServer(connection);
        //    //base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArticleComment>().HasKey(pk => new { pk.ArticleId, pk.CommentId, pk.UserId });
            //modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserId, pk.RoleId });

            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ArticleImagesMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new ArticleCommentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());


            //foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(t => t.ClrType.GetProperties().Any(x => x.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute)))))
            //{
            //    foreach (var property in entity.ClrType.GetProperties()
            //.Where(p => p.PropertyType == typeof(Guid) && p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))))
            //    {
            //        modelBuilder
            //            .Entity(entity.ClrType)
            //            .Property(property.Name)
            //            .HasDefaultValueSql("newsequentialid()");
            //    }
            //}
        }
        public override int SaveChanges()
        {

            var bases = ChangeTracker.Entries();


            if(bases.Where(x=>x.Entity is BaseEntity).Any())
            {
                var entries = ChangeTracker
               .Entries()
               .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                        ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;
                    if (entityEntry.State == EntityState.Added)
                        ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }

            if(bases.Where(x=>x.Entity is BaseDateEntity).Any())
            {
                var entries1 = ChangeTracker
              .Entries()
              .Where(x => x.Entity is BaseDateEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entityEntry in entries1)
                {
                    if (entityEntry.State == EntityState.Modified)
                        ((BaseDateEntity)entityEntry.Entity).UpdateDate = DateTime.Now;
                    if (entityEntry.State == EntityState.Added)
                        ((BaseDateEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }
           

          

            return base.SaveChanges();
        }
    }
}
