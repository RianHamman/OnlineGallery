using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineGallery.Models;
using OnlineGallery.ViewModels.AlbumViewModels;
using OnlineGallery.ViewModels.ImageViewModels;

namespace OnlineGallery.Automapper
{
    public class MyProfile : Profile
    {
        public MyProfile() //used as a constructor. 
        {
            CreateMap<Album, AlbumViewModel>().ReverseMap();
            CreateMap<Album, EditAlbumViewModel>().ReverseMap();
            CreateMap<Album, CreateAlbumViewModel>().ReverseMap();

            CreateMap<Image, ImageEditViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.AlbumName));
        }
    }

}
