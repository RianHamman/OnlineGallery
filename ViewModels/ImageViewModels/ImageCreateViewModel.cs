namespace OnlineGallery.ViewModels.ImageViewModels
{
    public class ImageCreateViewModel
    {
        public List<IFormFile> Files { get; set; }
        public int AlbumId { get; set; }
        public int Tags { get; set; }
        public int Geolocation { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedDate { get; set; }
    }
}
