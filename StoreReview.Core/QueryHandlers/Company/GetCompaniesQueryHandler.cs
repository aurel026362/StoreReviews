using AutoMapper;
using MediatR;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IList<CompanyDto>>
    {
        public readonly IRepository<Company> _repository;
        public readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IRepository<Company> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<IList<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = _repository.Read().ToList();
            var companiesDto = _mapper.Map<IList<CompanyDto>>(companies);
            return Task.FromResult(companiesDto);
        }
    }
}
