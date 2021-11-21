using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Infrastructure;
using OnlineGallery.Models;
using OnlineGallery.ViewModels.ImageViewModels;

namespace OnlineGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;

        public ImageController(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;  
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var image = _unitWork.ImageRepo.GetAll();
            var vm = _mapper.Map<List<ImageViewModel>>(image);
            return View(vm);
        }

        public ActionResult Details(int Id)
        {
            var image = _unitWork.ImageRepo.GetById(Id);
            var vm = _mapper.Map<List<ImageViewModel>>(image);
            return View(vm);
        }

        public ActionResult Create()
        {
            ViewBag.Album = _unitWork.AlbumRepo.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageCreateViewModel vm)
        {
            try
            {
                var album = _unitWork.AlbumRepo.GetById(vm.AlbumId); 
                List<Image> images = new List<Image>();

                foreach (var file in vm.Files)
                {
                    images.Add(new Image() { Url = file.FileName, Album = album });
                } 

                _unitWork.UploadImage(vm.Files);
                _unitWork.ImageRepo.AddRange(images);
                _unitWork.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Album = _unitWork.AlbumRepo.GetAll();
            var image = _unitWork.ImageRepo.GetById(Id);
            var mappedImage = _mapper.Map<ImageEditViewModel>(image);
            return View(mappedImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImageEditViewModel vm)
        {
            try
            {
                if (vm.File==null && _unitWork.ImageRepo.GetById(vm.Id).AlbumId == vm.AlbumId)
                {
                    RedirectToAction(nameof(Index));
                }
                else if(vm.File != null)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);
                    var updateImage = _unitWork.ImageRepo.GetById(vm.Id);
                    updateImage.Url = vm.File.FileName;

                    _unitWork.UploadImage(files);
                    _unitWork.ImageRepo.Update(updateImage);
                    _unitWork.Save();
                    RedirectToAction(nameof(Index));
                }
                else if(_unitWork.ImageRepo.GetById(vm.Id).AlbumId != vm.AlbumId)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);
                    var updateImage = _unitWork.ImageRepo.GetById(vm.Id);
                    updateImage.AlbumId = vm.AlbumId;
                    updateImage.Url = _unitWork.ImageRepo.GetById(vm.Id).Url;

                    //_unitWork.UploadImage(files);
                    _unitWork.ImageRepo.Update(updateImage);
                    _unitWork.Save();
                    RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Delete(int Id)
        {
            var model = _unitWork.ImageRepo.GetById(Id);
            var vm = _mapper.Map<ImageCreateViewModel>(model);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                //add delete function here 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
