namespace OnlineGallery.ViewModels.ImageViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        //public IFormFile File { get; set; }
        public string AlbumTitle { get; set; }
        public int Tags { get; set; }
        public int Geolocation { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedDate { get; set; }
    }
}
