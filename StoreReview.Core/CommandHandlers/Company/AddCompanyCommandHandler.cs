using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, long>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<CompanyFile> _companyPhotoRepository;
        private readonly IMapper _mapper;

        public AddCompanyCommandHandler(IRepository<Company> companyRepository, IRepository<CompanyFile> companyPhotoRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _companyPhotoRepository = companyPhotoRepository;
            _mapper = mapper;
        }

        public Task<long> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            var createdCompany = _companyRepository.Add(company);

            if (request.PhotoUrls?.Count > 0)
            {
                foreach(var item in request.PhotoUrls)
                {
                    //_companyPhotoRepository.Add(new CompanyFile()
                    //{
                    //    CompanyId = createdCompany.Id,
                    //    Url = item
                    //});
                }
            }
            return Task.FromResult(createdCompany.Id);
        }
    }
}
