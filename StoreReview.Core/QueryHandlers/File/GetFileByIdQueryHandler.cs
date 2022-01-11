using AutoMapper;
using MediatR;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.QueryHandlers
{
    public class GetFileByIdQueryHandler:IRequestHandler<GetFileByIdQuery, FileDto>
    {
        public readonly IRepository<File> _repository;
        public readonly IMapper _mapper;

        public GetFileByIdQueryHandler(IRepository<File> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<FileDto> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var file = _repository.GetByIdOrThrowNotFound(request.FileId);
            var fileDto = _mapper.Map<FileDto>(file);
            return fileDto;
        }
    }
}
