using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using OnlineGallery.Infrastructure;
using OnlineGallery.Models;

namespace OnlineGallery.Services
{
    public class AlbumRepo : IAlbumRepo //implamented by the interface for Album repo. 
    {
        private readonly ctx _ctx; //used to directly comm with the db. 

        public AlbumRepo(ctx ctx) //context constructor. 
        {
            _ctx = ctx;
        }

        public void Delete(int id) //used to delete an album by using the album ID. 
        {
            var album = GetById(id);
            _ctx.Album.Remove(album); 
        }

        public List<Album> GetAll() //used to get all the albums in a list. 
        {
            return _ctx.Album.ToList();
        }

        //public async Task<List<Album>> GetAllAsync() //Create an async list of all the albums. 
        //{
        //    return (await _ctx.Album.ToListAsync());
        //}

        public Album GetById(int Id) //get all of the albums by id in the context by id. 
        {
            return _ctx.Album.Where(a => a.Id == Id).FirstOrDefault();
        }

        public void Insert(Album album) //used to add to the album. 
        {
            _ctx.Album.Add(album);
        }

        public void Update(Album album) //used to update the album. 
        {
            _ctx.Album.Update(album);
        }
    }
}
