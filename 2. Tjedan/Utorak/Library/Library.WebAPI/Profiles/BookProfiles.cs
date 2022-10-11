using AutoMapper;
using Library.Common;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Library.WebAPI.Profiles
{
    public class BookProfiles : Profile
    {
        public BookProfiles()
        {
            CreateMap<BookRest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => $"{src.BookId}"))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => $"{src.AuthorId}"))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.Title}"))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => $"{src.PublishYear}"))
                .ForMember(dest => dest.OriginalLanguage, opt => opt.MapFrom(src => $"{src.OriginalLanguage}"))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => $"{src.ISBN}"));

            CreateMap<Book, BookRest>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => $"{src.BookId}"))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => $"{src.AuthorId}"))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => $"{src.Title}"))
                .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => $"{src.PublishYear}"))
                .ForMember(dest => dest.OriginalLanguage, opt => opt.MapFrom(src => $"{src.OriginalLanguage}"))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => $"{src.ISBN}"));

        }

    }
}