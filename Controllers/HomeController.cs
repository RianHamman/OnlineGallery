using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineGallery.Infrastructure;
using OnlineGallery.Models;
using OnlineGallery.ViewModels.ImageViewModels;
using System.Diagnostics;

namespace OnlineGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitWork _unitwork;
        private readonly IMapper _mapper;

        public HomeController(IUnitWork unitWork, IMapper mapper) //deafualt home controller constructor.
        {
            _unitwork = unitWork;
            _mapper = mapper;
        }

        public IActionResult Index() //getting all of the images and albums and converting it into a viewmodel 
        {
            var model = _unitwork.AlbumRepo.GetAll();
            var vm = _mapper.Map<List<ImageViewModel>>(model);

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}