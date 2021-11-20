namespace OnlineGallery.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public List<Image> Media { get; set; } = new List<Image>();
    }
}
