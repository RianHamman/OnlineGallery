namespace OnlineGallery.ViewModels.ImageViewModels
{
    public class ImageEditViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public int AlbumId { get; set; }

    }
}
