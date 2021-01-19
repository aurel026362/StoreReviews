using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class CreateShopCommand : IRequest<long>
    {
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public long CompanyId { get; set; }
    }
}
