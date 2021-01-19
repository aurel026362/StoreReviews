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
                .ForMember(dest => dest.Ratting, opt => opt.MapFrom(x => x.Reviews.Select(y => y.Ratting).Average()))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(x => x.Company.Name));

            CreateMap<CreateShopCommand, Shop>();
            CreateMap<UpdateShopCommand, Shop>();

            //Company 
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Ratting, opt => opt.MapFrom(x => CalculateAvg(x.Reviews.Select(y => y.Ratting).ToList())));


            //Review 
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.HasReplies, opt => opt.MapFrom(x => x.Replies.Any()))
                .ForMember(dest => dest.OwnerFullName, opt => opt.MapFrom(x => x.User.FullName))
                .ForMember(dest => dest.ReviewType, opt => opt.MapFrom(x => ReviewType.Shop))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(x => GetReviewReferenceId(x, ReviewType.Company)))
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(x => GetReviewReferenceId(x, ReviewType.Shop)));

            CreateMap<AddReviewCommand, ShopReview>();
            CreateMap<AddReviewCommand, CompanyReview>();
        }
        private float? CalculateAvg(IEnumerable<float?> list)
        {
            if (list.Any())
            {
                return list.Average();
            }
            return null;
        }

        private long? GetReviewReferenceId(Review review, ReviewType reviewType)
        {
            if (review is CompanyReview && reviewType == ReviewType.Company)
            {
                return ((CompanyReview)review).CompanyId;
            }
            else if (review is ShopReview && reviewType == ReviewType.Shop)
            {
                return ((ShopReview)review).ShopId;
            }
            return null;
        }
    }
}