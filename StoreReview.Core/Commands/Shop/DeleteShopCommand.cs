using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class DeleteShopCommand: IRequest<long>
    {
        public long Id { get; set; }
    }
}
