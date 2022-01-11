﻿using AutoMapper;
using MediatR;
using StoreReview.Core.Commands;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreReview.Core.CommandHandlers
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, long>
    {
        public readonly IRepository<Shop> _repository;
        public readonly IMapper _mapper;

        public UpdateShopCommandHandler(IRepository<Shop> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<long> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var shop = _repository.GetByIdOrThrowNotFound(request.Id);

            shop.Address = request.Address;
            shop.Phone = request.Phone;
            shop.Description = request.Description;
            shop.CompanyId = request.CompanyId;

            _repository.Update(shop);
            return Task.FromResult(shop.Id);
        }
    }
}