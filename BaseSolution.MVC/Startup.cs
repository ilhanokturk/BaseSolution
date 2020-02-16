using BaseSolution.Abstraction.IoC;
using BaseSolution.Abstraction.Repository.Base;
using BaseSolution.Abstraction.Repository.Repositories;
using BaseSolution.Abstraction.UnitOfWork;
using BaseSolution.Business;
using BaseSolution.Business.Abstract;
using BaseSolution.Business.Concrete;
using BaseSolution.Business.UOW;
using BaseSolution.Context.Contexts.EntityFramework;
using BaseSolution.Context.InitialData;
using BaseSolution.Core.Extensions;
using BaseSolution.Data;
using BaseSolution.Data.Repositories;
using BaseSolution.DTO.DataTransferObjects.User;
using BaseSolution.LogLayer.Logging;
using BaseSolution.MVC.Filter.Validation;
using BaseSolution.MVC.Helpers;
using BaseSolution.MVC.Localization;
using BaseSolution.MVC.Middleware;
using BaseSolution.MVC.Resources;
using BaseSolution.MVC.Validators.Users;
using BaseSolution.Utilities.Application;
using BaseSolution.Utilities.DependencyResolvers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace BaseSolution.MVC
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LocalizationService>();
            ApplicationSettings.FileLogPath = "C:\\ApplicationLog\\Log-${shortdate}.json";
            ApplicationSettings.DatabaseLogConnectionString = "Server=DESKTOP-UHPJU3L;database=MyDatabase;Integrated Security=True;";
            ApplicationSettings.MssqlConnectionString = Configuration.GetConnectionString("MssqlConnectionString");
            //LogManagerType.Log4NetSetup();
            LogManagerType.NLogSetup();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => { options.ResourcesPath = "Resources"; })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddDataAnnotationsLocalization(options => { options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResources)); });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("tr-TR")
                    };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider> { new QueryStringRequestCultureProvider(), new CookieRequestCultureProvider() };
            });

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => { options.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization(daoptions =>
                {
                    daoptions.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResources", assemblyName.Name);
                    };
                });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            });

            CookieSetting(services);

            services.AddServices();

            AuthenticationSetting(services);

            SessionSetting(services);

            services.AddHttpContextAccessor();

            services.LogDependencyResolvers();

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });



            services.AddTransient(typeof(ILocalization), typeof(LocalizationService));


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //var rewriteOptions = new RewriteOptions().Add(new FirstLoadRewriteRule());
            //app.UseRewriter(rewriteOptions);

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);



            app.UseMvc(routes =>
            {

                routes.MapRoute(
                  name: "areas",
                  template: "{culture=en-US}/{area:exists}/{controller}/{action}/{id?}"
                  );

                routes.MapRoute(
                    name: "InternationalizationDefault",
                    template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");


            });


            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            //app.UseRequestLocalization();

            app.UseSession();

            //app.UseMvc(routes =>
            //{

            //    routes.MapRoute(
            //      name: "areas",
            //      template: "{culture=en-US}/{area:exists}/{controller}/{action}/{id?}"
            //      );


            //    routes.MapRoute(
            //        name: "InternationalizationDefault",
            //        template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");


            //});
            //SeedData.EnsurePopulated(app);

        }

        private static void CookieSetting(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
        }

        private static void SessionSetting(IServiceCollection services)
        {
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30); options.Cookie.HttpOnly = true; options.Cookie.IsEssential = true; });
        }

        private static void AuthenticationSetting(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Auth/Login";
                   options.LogoutPath = "/Auth/Logout";
                   options.AccessDeniedPath = "/Auth/AccessDenied";
               });
        }

        private static void GlobalizationSettings(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                new CultureInfo("en"),
                new CultureInfo("tr"),
            };


                options.DefaultRequestCulture = new RequestCulture(culture: "tr", uiCulture: "tr");


                options.SupportedCultures = supportedCultures;


                options.SupportedUICultures = supportedCultures;


                options.RequestCultureProviders = new List<IRequestCultureProvider> { new QueryStringRequestCultureProvider(), new CookieRequestCultureProvider() };

            });
        }

        //private static void AddingControllerAndViews(IServiceCollection services)
        //{
        //    services.AddControllersWithViews()
        //                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        //                    .AddDataAnnotationsLocalization(daoptions =>
        //                    {
        //                        daoptions.DataAnnotationLocalizerProvider = (type, factory) =>
        //                        {
        //                            var assemblyName = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
        //                            return factory.Create("SharedResources", assemblyName.Name);
        //                        };
        //                    })
        //                    .AddRazorRuntimeCompilation();
        //}
    }
}
