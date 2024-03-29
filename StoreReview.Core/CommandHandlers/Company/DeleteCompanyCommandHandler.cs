﻿using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<CompanyFile> _companyPhotoRepository;

        public DeleteCompanyCommandHandler(IRepository<Company> companyRepository, IRepository<CompanyFile> companyPhotoRepository)
        {
            _companyRepository = companyRepository;
            _companyPhotoRepository = companyPhotoRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyPhotos = _companyPhotoRepository.Read().Where(x => x.CompanyId == request.Id).ToList();
            _companyPhotoRepository.DeleteRange(companyPhotos);
            await _companyRepository.DeleteByIdAsync(request.Id);

            return Unit.Value;
        }
    }
}
