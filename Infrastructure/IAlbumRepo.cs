using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGallery.Models;

namespace OnlineGallery.Infrastructure
{
    public interface IAlbumRepo
    {
        List<Album> GetAll(); //used to get all the Albums in a list. 
        Album GetById(int id); //used to get all the albums by using the ID of an album.
        void Insert(Album album); //used to add an album.
        void Update(Album album); //used to update the album. 
        void Delete(int id); //used to delete the album via id. 
    }
}
