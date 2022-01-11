using MediatR;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Queries
{
    public class GetUserDataQuery: IRequest<UserDto>
    {
        public long UserId { get; set; }
    }
}
