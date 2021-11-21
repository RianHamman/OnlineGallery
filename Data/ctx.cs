using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Models;

namespace OnlineGallery.Data
{
    public class ctx : DbContext 
    {
        public ctx(DbContextOptions<ctx> options) : base(options)
        {

        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Image> Image { get; set; }

    }
}
