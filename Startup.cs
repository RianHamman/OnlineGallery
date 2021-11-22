﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineGallery.Automapper;
using OnlineGallery.Data;
using OnlineGallery.Infrastructure;
using OnlineGallery.Services;
using System.Configuration;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using OnlineGallery.Models;
using static OnlineGallery.Models.ctx_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

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