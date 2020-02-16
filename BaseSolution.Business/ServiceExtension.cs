using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business.Abstract;
using BaseSolution.Business.Concrete;
using BaseSolution.Business.UOW;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Utilities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSolution.Business
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(DbContext), typeof(ApplicationContext));
            ////services.AddScoped(typeof(DbContext), typeof(ApplicationContext));
            services.AddDbContext<ApplicationContext>(options =>
           { options.UseSqlServer(ApplicationSettings.MssqlConnectionString); options.EnableSensitiveDataLogging(true); });

            services.AddScoped(typeof(IUnitofWork<>), typeof(UnitofWork<>));

            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
        }
    }
}
