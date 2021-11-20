using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Infrastructure;
using OnlineGallery.Models;
using OnlineGallery.ViewModels.AlbumViewModels;

namespace OnlineGallery.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;

        public AlbumController(IUnitWork unitWork, IMapper mapper) //defualt controller for the albumController
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var albums = _unitWork.AlbumRepo.GetAll();
            var mappedAlbums = _mapper.Map<List<AlbumViewModel>>(albums);
            return View(mappedAlbums);
        }

        public ActionResult Details(int id)
        {
            var album = _unitWork.AlbumRepo.GetById(id);
            var mappedAlbums = _mapper.Map<AlbumViewModel>(album);
            return View(mappedAlbums);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAlbumViewModel album)
        {
            try
            {
                var mappedAlbum = _mapper.Map<Album>(album);
                _unitWork.AlbumRepo.Insert(mappedAlbum);
                _unitWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var album = _unitWork.AlbumRepo.GetById(id);
            var mappedAlbum = _mapper.Map<EditAlbumViewModel>(album);
            return View(mappedAlbum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditAlbumViewModel vm)
        {
            try
            {
                var album = _mapper.Map<Album>(vm);
                _unitWork.AlbumRepo.Update(album);
                _unitWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            var album = _unitWork.AlbumRepo.GetById(Id);
            var mappedAlbum = _mapper.Map<AlbumViewModel>(album);
            return View(mappedAlbum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, AlbumViewModel album)
        {
            try
            {
                _unitWork.AlbumRepo.Delete(Id);
                _unitWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
