using Microsoft.AspNetCore.Identity;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            services.AddMvc();
            var connection = @"Server=(localdb)\\mssqllocaldb;Database=OnlineGalleryProject;Trusted_Connection=True;MultipleResultSets=True";
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /*services.AddDbContext<ctx>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //used to link db in startup. 
            services.AddTransient<IUnitWork, UnitWork>();
            var config = new AutoMapper.MapperConfiguration(cfg => 
        {
                cfg.AddProfile(new MyProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper); */

            services.AddDefaultIdentity<OnlineGalleryUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<OnlineGalleryDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();//razor pages support/uses
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();//razor page location
            });
        }
    }
}