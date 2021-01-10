using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, long>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public CreateShopCommandHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var newShop = _mapper.Map<Shop>(request);
            var createdShop = _repository.Add(newShop);
            return createdShop.Id;
        }
    }
}