using Microsoft.EntityFrameworkCore;
using OnlineGallery.Models;

namespace OnlineGallery.Data
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Image> Image { get; set; }

        //public DbSet<OnlineGallery.ViewModels.ImageViewModels.ImageViewModel> ImageViewModels { get; set; }

    }
}