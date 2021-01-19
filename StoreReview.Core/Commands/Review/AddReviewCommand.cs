using MediatR;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreReview.Core.Commands
{
    public class AddReviewCommand : IRequest<long>
    {
        public ReviewType ReviewType { get; set; }
        [Required]
        public string Description { get; set; }
        public long? ReviewId { get; set; }
        public float? Ratting { get; set; }
        public long? CompanyId { get; set; }
        public long? ShopId { get; set; }
        //public ReviewPhoto[] Photos { get; set; }
    }
}
