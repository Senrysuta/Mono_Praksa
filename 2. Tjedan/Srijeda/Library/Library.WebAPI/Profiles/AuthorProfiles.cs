using AutoMapper;
using Library.Common;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebAPI.Profiles
{
    public class AuthorProfiles : Profile
    {
        public AuthorProfiles()
        {
            CreateMap<AuthorRest, Author>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => $"{src.AuthorId}"))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName}"))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => $"{src.LastName}"));

            CreateMap<Author, AuthorRest>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => $"{src.AuthorId}"))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName}"))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => $"{src.LastName}"));


        }
    }
}