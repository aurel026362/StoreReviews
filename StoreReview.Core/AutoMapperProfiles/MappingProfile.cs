using AutoMapper;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreReview.Core.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Shop
            CreateMap<Shop, ShopDto>()
                .ForMember(dest => dest.Ratting, opt => opt.MapFrom(x => x.Reviews.Select(y => y.Ratting).Average()));
            CreateMap<CreateShopCommand, Shop>();
            CreateMap<UpdateShopCommand, Shop>();

            //Company 
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Ratting, opt => opt.MapFrom(x => x.Reviews.Select(y => y.Ratting).Average()));
        }
    }
}