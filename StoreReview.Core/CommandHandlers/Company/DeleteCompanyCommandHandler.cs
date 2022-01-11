using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, long>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<CompanyFile> _companyPhotoRepository;

        public DeleteCompanyCommandHandler(IRepository<Company> companyRepository, IRepository<CompanyFile> companyPhotoRepository)
        {
            _companyRepository = companyRepository;
            _companyPhotoRepository = companyPhotoRepository;
        }

        public Task<long> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyPhotos = _companyPhotoRepository.Read().Where(x => x.CompanyId == request.Id).ToList();
            _companyPhotoRepository.DeleteRange(companyPhotos);
            _companyRepository.DeleteById(request.Id);
            return Task.FromResult(request.Id);
        }
    }
}
