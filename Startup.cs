using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineGallery.Automapper;
using OnlineGallery.Data;
using OnlineGallery.Infrastructure;
using OnlineGallery.Services;
using System.Configuration;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace OnlineGallery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ctx>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //used to link db in startup. 
            services.AddTransient<IUnitWork, UnitWork>();
            var config = new AutoMapper.MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new MyProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper); 
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
