using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineGallery.Models
{
    public class ctx_Model
    {
        public class cxt_context : DbContext
        {
            public cxt_context(DbContextOptions<cxt_context> options) : base(options)
            { }

            public DbSet<Album> Album { get; set; }
            public DbSet<Image> Image { get; set; }
        }
    }
}
