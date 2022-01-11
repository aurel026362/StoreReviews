//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using StoreReview.Core.Domain;
//using StoreReview.Core.DtoModels;
//using StoreReview.Core.Interfaces;
//using StoreReview.Core.Queries;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace StoreReview.Core.QueryHandlers
//{
//    public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDto>
//    {
//        public readonly IRepository<User> _repository;
//        public readonly IMapper _mapper;

//        public GetUserDataQueryHandler(IRepository<User> repository, IMapper mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }
//        public async Task<UserDto> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
//        {
//            var user = await _repository.Read()
//                .SingleAsync(x => x.Id == request.UserId);
//            var userDto = _mapper.Map<UserDto>(user);
//            return userDto;
//        }
//    }
//}
