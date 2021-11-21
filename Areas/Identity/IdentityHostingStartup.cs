using System;
using OnlineGallery.Areas.Identity.Data;
using OnlineGallery.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(OnlineGallery.Areas.Identity.IdentityHostingStartup))]
namespace OnlineGallery.Areas.Identity
{
    public class IdentityHostingStartup : Microsoft.AspNetCore.Hosting.IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => 
            { 
                services.AddDbContext<OnlineGalleryDbContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("OnlineGalleryDbContextConnection")));

                services.AddDefaultIdentity<OnlineGalleryUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<OnlineGalleryDbContext>();
            });  
        }
    }
}
