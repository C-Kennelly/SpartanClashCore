using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SpartanClash.Data;
using SpartanClash.Models.ClashDB;
using Identity.Models;
using Identity.EmailSender;
using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace SpartanClash
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //{1} is controller, {0} is the action.  Use {2} for area.
            //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Components/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Components/_SharedViews/{0}" + RazorViewEngine.ViewExtension);

                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Components/{2}/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/Components/_SharedViews/{0}" + RazorViewEngine.ViewExtension);
            });

            //Require HTTPS everywhere
            /****** HTTPS disabled while we deal with certs. *****************

                        services.Configure<MvcOptions>(options =>
                        {
                            options.Filters.Add(new RequireHttpsAttribute());
                        });
            *****************************************************************/

            //Make clash db available to the application
            services.AddDbContext<clashdbContext>(options =>
                options.UseMySql(Environment.GetEnvironmentVariable("SPARTANCLASH_CLASHDBSTRING")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseMySql(Configuration.GetConnectionString("clashDBCredsConnection")));

            services.AddTransient<UserBehaviorTracking.UserBehaviorTracker>();
/****** Authentication disabled while we deal with certs. *****************

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>{
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
            }); 

****************************************************************************/

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

/****** HTTPS disabled while we deal with certs. *****************

            var options = new RewriteOptions()
                .AddRedirectToHttps();

*******************************************************************/

            app.UseStaticFiles();


/****** Authentication disabled while we deal with certs. *****************

            app.UseAuthentication();
************************************************************************/


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            });


        }
    }
}
