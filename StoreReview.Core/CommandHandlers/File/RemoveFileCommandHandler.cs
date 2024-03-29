﻿using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class RemoveFileCommandHandler : IRequestHandler<RemoveFileCommand>
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

        public async Task<Unit> Handle(RemoveFileCommand message, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdOrThrowNotFoundAsync(message.FileId);

            await _fileService.DeleteAsync(file.Path);

            _repository.Delete(file);

            return Unit.Value;
        }
    }
}