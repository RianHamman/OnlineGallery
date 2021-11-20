namespace OnlineGallery.Infrastructure
{
    public interface IUnitWork
    {
        IAlbumRepo AlbumRepo { get; } //used to get Information from the AlbumRepo Interface.
        IImageRepo ImageRepo { get; } //used to get infromation from the ImageRepo Interface. 
        void Save(); //used to save changes. 
        void UploadImage(List<IFormFile> files); //used to upload a new image with the list of files. 
    }
}
