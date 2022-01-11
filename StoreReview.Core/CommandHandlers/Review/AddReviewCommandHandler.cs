using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;

namespace StoreReview.Core.CommandHandlers
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, long>
    {
        private readonly IRepository<ShopReview> _shopRepository;
        private readonly IRepository<CompanyReview> _companyRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;

        public AddReviewCommandHandler(IRepository<ShopReview> shopRepository, IRepository<CompanyReview> companyRepository, ICurrentUser currentUser, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<long> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            if (request.ReviewType == ReviewType.Shop && request.ShopId.HasValue)
            {
                var review = _mapper.Map<ShopReview>(request);
                review.UserId = (long)_currentUser.Id;
                review.Date = DateTime.Now;
                var createdReview = _shopRepository.Add(review);
                return createdReview.Id;
            }
            else if (request.ReviewType == ReviewType.Company && request.CompanyId.HasValue)
            {
                var review = _mapper.Map<CompanyReview>(request);
                review.UserId = (long)_currentUser.Id;
                review.Date = DateTime.Now;
                var createdReview = _companyRepository.Add(review);
                return createdReview.Id;
            };
            throw new Exception("Invalidat Review Type");
        }
    }
}