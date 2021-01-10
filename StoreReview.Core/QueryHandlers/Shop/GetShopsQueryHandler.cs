using AutoMapper;
using MediatR;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetShopsQueryHandler : IRequestHandler<GetShopsQuery, IList<ShopDto>>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public GetShopsQueryHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IList<ShopDto>> Handle(GetShopsQuery request, CancellationToken cancellationToken)
        {
            var shops = _repository.Read().ToList();
            var shopsDto = _mapper.Map<IList<ShopDto>>(shops);
            return shopsDto;
        }
    }
}
