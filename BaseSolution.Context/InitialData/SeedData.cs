using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Core.Security;
using BaseSolution.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseSolution.Context.InitialData
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder builder)
        {
            var context = builder.ApplicationServices.GetRequiredService<ApplicationContext>();

            context.Database.Migrate();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var _pass = "123456789";
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(_pass, out passwordHash, out passwordSalt);
                var user1 = new User
                {
                    Email = "testAdmin@test.com",
                    Name = "Test",
                    Lastname = "Admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };


                var _pass2 = "987654321";
                byte[] _passwordHash, _passwordSalt;
                HashingHelper.CreatePasswordHash(_pass2, out _passwordHash, out _passwordSalt);
                var user2 = new User
                {
                    Email = "testUser@test.com",
                    Name = "Test1",
                    Lastname = "User",
                    PasswordHash = _passwordHash,
                    PasswordSalt = _passwordSalt
                };

                context.Set<User>().Add(user1);
                context.Set<User>().Add(user2);

                if (!context.Roles.Any())
                {
                    var roles = new[]
                    {
                        new Role(){RoleName="Admin"},
                        new Role(){RoleName="User"},
                        new Role(){RoleName="Super Admin"},
                    };
                    context.Roles.AddRange(roles);
                }
                context.SaveChanges();

                var addeduser1 = context.Users.ToList();
                var role1 = context.Roles.Where(x => x.RoleName == "Admin").FirstOrDefault();
                var role2 = context.Roles.Where(x => x.RoleName == "User").FirstOrDefault();

                var userroles = new[]
                {
                    new UserRole(){UserId=addeduser1[0].Id,RoleId=role1.Id},
                    new UserRole(){UserId=addeduser1[1].Id,RoleId=role2.Id},
                };
                context.AddRange(userroles);

                context.SaveChanges();
            }
        }
    }
}
