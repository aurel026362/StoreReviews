using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class RemoveFileCommand : IRequest<long>
    {
        public long FileId { get; set; }
    }
}
