using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public DeleteShopCommandHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}