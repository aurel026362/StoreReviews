using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, FileDto>
    {
        public readonly IRepository<File> _repository;
        public readonly IMapper _mapper;

        public AddFileCommandHandler(IRepository<File> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FileDto> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            var newFile = _mapper.Map<File>(request);
            var createdFile = await _repository.AddAsync(newFile);

            return _mapper.Map<FileDto>(createdFile);
        }
    }
}