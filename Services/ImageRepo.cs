using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineGallery.Data;
using OnlineGallery.Infrastructure;
using OnlineGallery.Models;

namespace OnlineGallery.Services
{
    public class ImageRepo : IImageRepo //implamented by the interface for Image repo.
    {
        private readonly MyContext _ctx; //used to directly comm with the db.

        public ImageRepo(MyContext ctx) //constructor method for Image Repo. 
        {
            _ctx = ctx;
        }

        public void AddRange(List<Image> images) //used to add multiple image files to the database via a list. 
        {
            _ctx.Image.AddRange(images);
        }

        public void Delete(int id) //used to remove images from the db using the image ID. 
        {
            var imageManager = GetById(id);
            _ctx.Image.Remove(imageManager);
        }

        public List<Image> GetAll() //used to get all the images in a list form from the db. 
        {
            var meta = _ctx.Image.Include(a => a.Album).ToList();
            return meta;
        }

        public Image GetById(int Id) //used to get one image from the db via the image id, can also be used to search for image with a keyword. 
        {
            return _ctx.Image.Where(a => a.Id == Id).Include(a => a.Album).FirstOrDefault();
        }

        public void Insert(Image imageManager) //used to add an image to the db. 
        {
            _ctx.Image.Add(imageManager);
        }

        public void Update(Image imageManager) //used to update and change an image in the db. 
        {
            _ctx.Image.Update(imageManager);
        }
    }
}
