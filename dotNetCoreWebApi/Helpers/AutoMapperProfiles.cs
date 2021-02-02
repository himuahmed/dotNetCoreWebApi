using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotNetCoreWebApi.Dtos;
using dotNetCoreWebApi.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace dotNetCoreWebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetails>().ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.GetAge()));

            CreateMap<User, UserList>().ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetAge()));

            CreateMap<Photo, PhotoDetails>();
            CreateMap<UserUpdate, User>();
            CreateMap<UserRegistrationDto, User>();
            CreateMap<MessageDto, Message>().ReverseMap();

        }
    }
}
