using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; } = new Album();
    }
}
