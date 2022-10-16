using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public long Id { get; set; }
    }
}
