using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, PagedResultDto<ReviewDto>>
    {
        public readonly IRepository<ShopReview> _shopReviewRepository;
        public readonly IRepository<CompanyReview> _companyReviewRepository;
        public readonly IMapper _mapper;

        public GetReviewsQueryHandler(IRepository<ShopReview> shopReviewRepository, IRepository<CompanyReview> companyReviewRepository, IMapper mapper)
        {
            _shopReviewRepository = shopReviewRepository;
            _companyReviewRepository = companyReviewRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var page = request.InputPage.Page - 1;
            var reviewTotalCount = 0;

            IQueryable<Review> reviews;

            if (request.ReviewType == ReviewType.Company)
            {
                reviewTotalCount = _companyReviewRepository.Read().Where(x => x.CompanyId == request.CompanyId).Count();
                reviews = _companyReviewRepository.Read()
                    .Include(x => x.User)
                    .Where(x => x.CompanyId == request.CompanyId)
                    .OrderByDescending(x => x.Date);
                if (request.ReviewId.HasValue)
                {
                    reviews = reviews.Where(x => x.ReviewId == request.ReviewId);
                }

                reviews = reviews
                    .Skip(page * request.InputPage.PageSize)
                    .Take(request.InputPage.PageSize);
            }
            else if (request.ReviewType == ReviewType.Shop)
            {
                reviewTotalCount = _shopReviewRepository.Read().Where(x => x.ShopId == request.ShopId).Count();
                reviews = _shopReviewRepository.Read()
                    .Include(x => x.User)
                    .Where(x => x.ShopId == request.ShopId)
                    .OrderByDescending(x => x.Date);
                if (request.ReviewId.HasValue)
                {
                    reviews = reviews.Where(x => x.ReviewId == request.ReviewId);
                }
                reviews = reviews
                    .Skip(page * request.InputPage.PageSize)
                    .Take(request.InputPage.PageSize);
            }
            else
            {
                throw new Exception("Invalid Review Type");
            }
            var reviewsDto = _mapper.Map<IList<ReviewDto>>(reviews.ToList());
            var response = new PagedResultDto<ReviewDto>()
            {
                PageSize = request.InputPage.PageSize,
                CurrentPage = request.InputPage.Page,
                TotalPages = (int)Math.Ceiling((decimal)reviewTotalCount / (decimal)request.InputPage.PageSize),
                Results = reviewsDto
            };
            return response;
        }
    }
}
