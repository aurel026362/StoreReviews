using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class RemoveFileCommandHandler : IRequestHandler<RemoveFileCommand, long>
    {
        private readonly IRepository<File> _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public RemoveFileCommandHandler(IRepository<File> repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<long> Handle(RemoveFileCommand message, CancellationToken cancellationToken)
        {
            var file = _repository.GetByIdOrThrowNotFound(message.FileId);

            _fileService.DeleteAsync(file.Path);

            _repository.Delete(file);
            return file.Id;
        }
    }
}