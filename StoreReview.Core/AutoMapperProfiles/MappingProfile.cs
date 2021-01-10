using AutoMapper;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Shop
            CreateMap<Shop, ShopDto>();
            CreateMap<CreateShopCommand, Shop>();
            CreateMap<UpdateShopCommand, Shop>();
        }
    }
}