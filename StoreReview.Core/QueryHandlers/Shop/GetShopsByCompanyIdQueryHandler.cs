using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetShopsByCompanyIdQueryHandler : IRequestHandler<GetShopsByCompanyIdQuery, IList<ShopDto>>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public GetShopsByCompanyIdQueryHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IList<ShopDto>> Handle(GetShopsByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var shops = await _repository.Read()
                .Include(x=>x.Company)
                .Where(x=>x.CompanyId == request.CompanyId).ToListAsync();
            var shopsDto = _mapper.Map<IList<ShopDto>>(shops);
            return shopsDto;
        }
    }
}
