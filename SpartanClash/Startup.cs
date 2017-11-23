using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SpartanClash.Data;
using SpartanClash.Models;
using SpartanClash.Services;



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

                        //Require HTTPS everywhere
                        services.Configure<MvcOptions>(options =>
                        {
                            options.Filters.Add(new RequireHttpsAttribute());
                        });

            //Make clash db available to the application
            services.AddDbContext<clashdbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("clashDBConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("clashDBCredsConnection")));

            //Make local db available to the application
            //            services.AddDbContext<ApplicationDbContext>(options =>
            //                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>{
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
            }); 

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

 //           var options = new RewriteOptions()
 //               .AddRedirectToHttps();

            app.UseStaticFiles();

 //           app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{company?}");
            });
        }
    }
}
