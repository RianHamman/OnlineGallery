using Microsoft.AspNetCore.Mvc;

namespace OnlineGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public IActionResult Index()
        {
            List<string> images = Directory.GetFiles(wwwrootDirectory, "*.png").Select(Path.GetFileName).ToList();
            return View(images);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myFile)
        {
            if (myFile != null)
            {
                var path = Path.Combine(wwwrootDirectory, DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
    }
}
