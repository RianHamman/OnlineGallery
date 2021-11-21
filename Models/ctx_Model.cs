using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineGallery.Models
{
    public class ctx_Model
    {
        public class ctx : DbContext
        {
            public ctx(DbContextOptions<ctx> options) : base(options)
            { }

            public DbSet<Album> Album { get; set; }
            public DbSet<Image> Image { get; set; }
        }
        public class Album
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

        public class Image
        {
            public int Id { get; set; }
            public string Url { get; set; }
            //public IFormFile File { get; set; }
            public string AlbumTitle { get; set; }
        }
    }
}
