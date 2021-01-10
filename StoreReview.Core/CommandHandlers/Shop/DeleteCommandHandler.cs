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
        public async Task Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteById(request.Id);
        }

        Task<Unit> IRequestHandler<DeleteShopCommand, Unit>.Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}