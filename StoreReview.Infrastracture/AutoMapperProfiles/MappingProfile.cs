using AutoMapper;
using Microsoft.AspNetCore.Http;
using StoreReview.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IFormFile, AddFileCommand>()
                .ForMember(dest => dest.Path, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length));
        }
    }
}