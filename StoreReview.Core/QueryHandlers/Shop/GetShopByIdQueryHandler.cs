using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetShopByIdQueryHandler : IRequestHandler<GetShopByIdQuery, ShopDto>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public GetShopByIdQueryHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ShopDto> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
        {
            var shops = await _repository.Read()
                .Include(x => x.Company)
                .SingleAsync(x => x.Id == request.Id);
            var shopsDto = _mapper.Map<ShopDto>(shops);
            return shopsDto;
        }
    }
}
