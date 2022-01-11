using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand, long>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public DeleteShopCommandHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<long> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(request.Id);
            return request.Id;
        }
    }
}