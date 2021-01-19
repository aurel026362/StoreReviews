using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDto>
    {
        public readonly IRepository<Company> _repository;
        public readonly IMapper _mapper;

        public GetCompanyByIdQueryHandler(IRepository<Company> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = _repository.Read().Include(x=>x.Reviews).Single(x=>x.Id == request.CompanyId);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Task.FromResult(companyDto);
        }
    }
}
