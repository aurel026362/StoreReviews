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
        public readonly IRepository<ShopReview> _shopRepository;
        public readonly IRepository<CompanyReview> _companyRepository;
        public readonly IMapper _mapper;

        public GetReviewsQueryHandler(IRepository<ShopReview> shopRepository, IRepository<CompanyReview> companyRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var page = request.InputPage.Page - 1;
            IQueryable<Review> reviews;
            if (request.ReviewType == ReviewType.Company)
            {
                reviews = _companyRepository.Read()
                    .Include(x => x.User).OrderByDescending(x => x.Date)
                    .Skip(page * request.InputPage.PageSize)
                    .Take(request.InputPage.PageSize);
            }
            else if (request.ReviewType == ReviewType.Shop)
            {
                reviews = _shopRepository.Read()
                    .Include(x => x.User).OrderByDescending(x => x.Date)
                    .Skip(page * request.InputPage.PageSize)
                    .Take(request.InputPage.PageSize);
            }
            else
            {
                reviews = null;
            }
            var reviewsDto = _mapper.Map<IList<ReviewDto>>(reviews.ToList());
            var reviewTotalCount = reviews.Count();
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
