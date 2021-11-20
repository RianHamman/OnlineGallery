using OnlineGallery.Models;

namespace OnlineGallery.Infrastructure
{
    public interface IImageRepo
    {
        List<Image> GetAll(); //used to get all the images.
        Image GetById(int Id); //used to get images via ID. 
        void Insert(Image imageManager); //used to add a new image. 
        void Update(Image imageManager); //used to change an image and update.
        void Delete(int id); //used to delete an image by using the id.
        void AddRange(List<Image> model); 

    }
}
