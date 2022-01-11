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
            CreateMap<AddCompanyCommand, Company>();
            CreateMap<UpdateShopCommand, Company>();

            //Review 
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Ratting, opt => opt.MapFrom(x => x.Ratting.HasValue ? ((float)Math.Round((float)x.Ratting, 2)) : x.Ratting))
                .ForMember(dest => dest.HasReplies, opt => opt.MapFrom(x => x.Replies.Any()))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(x => x.User))
                .ForMember(dest => dest.ReviewType, opt => opt.MapFrom(x => ReviewType.Shop))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(x => GetReviewReferenceId(x, ReviewType.Company)))
                .ForMember(dest => dest.ShopId, opt => opt.MapFrom(x => GetReviewReferenceId(x, ReviewType.Shop)));

            CreateMap<AddReviewCommand, ShopReview>();
            CreateMap<AddReviewCommand, CompanyReview>();

            //User
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

        }
        private float? CalculateAvg(IEnumerable<float?> list)
        {
            if (list.Any())
            {
                var average = list.Average();
                return average.HasValue ? ((float)Math.Round((float)average, 2)) : average;
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