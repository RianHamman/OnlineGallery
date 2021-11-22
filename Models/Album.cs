using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
