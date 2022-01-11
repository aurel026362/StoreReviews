using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand,long>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<CompanyFile> _companyPhotoRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IRepository<Company> companyRepository, IRepository<CompanyFile> companyPhotoRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _companyPhotoRepository = companyPhotoRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.Read()
                .Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == request.Id);

            company.Name = request.Name;
            company.Description = request.Description;
            company.Phone = request.Phone;
            company.LogoUrl = request.LogoUrl;
            company.WebSite = request.WebSite;

            var companyPhotos = _companyPhotoRepository.Read().Where(x => x.CompanyId == company.Id).ToList();
            _companyPhotoRepository.DeleteRange(companyPhotos);

            if (request.PhotoUrls?.Count > 0)
            {
                foreach (var item in request.PhotoUrls)
                {
                    //_companyPhotoRepository.Add(new CompanyFile()
                    //{
                    //    CompanyId = company.Id,
                    //    Url = item
                    //});
                }
            }
            return company.Id;
        }
    }
}
