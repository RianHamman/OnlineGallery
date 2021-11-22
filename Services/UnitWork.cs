using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGallery.Data;
using OnlineGallery.Infrastructure;

namespace OnlineGallery.Services
{
    public class UnitWork : IUnitWork //used to combine the Album and image repo services. Implamented by using the Interface IUnitWork. 
    {
        private readonly MyContext _ctx;
        private IAlbumRepo _albumRepo;
        private IImageRepo _imageRepo;
        private readonly IHostEnvironment _hostEnviorment; 

        public UnitWork(MyContext ctx, IHostEnvironment hostEnvironment)
        {
            _ctx = ctx; 
            this._hostEnviorment = hostEnvironment;
        }

        public IAlbumRepo AlbumRepo
        {
            get
            {
                return _albumRepo = _albumRepo ?? new AlbumRepo(_ctx);
            }
        }

        public IImageRepo ImageRepo
        {
            get
            {
                return _imageRepo ?? new ImageRepo(_ctx);
            }
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public async void UploadImage(List<IFormFile> files) //used to upload multiple image files to a local folder, will implament blob storage on azure soon. 
        {
            foreach(IFormFile item in files)
            {
                long totalBytes = files.Sum(fl => fl.Length);
                string imagename = item.FileName.Trim('"');
                imagename = EnsureImageName(imagename);
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = File.Create(GetUrlAndImageName(imagename)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readBytes;
                        while((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }

        private string EnsureImageName(string imagename)
        {
            if(imagename.Contains("\\"))
                imagename = imagename.Substring(imagename.LastIndexOf("\\") + 1);
            return imagename;
        }

        private string GetUrlAndImageName(string imagename)
        {
            string url = _hostEnviorment.ContentRootPath + "\\uploads\\";
            if (!Directory.Exists(url))
                Directory.CreateDirectory(url);
            return url + imagename;
        }
        
    }
}
