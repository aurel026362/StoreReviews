using MediatR;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Queries
{
    public class GetReviewsQuery: IRequest<PagedResultDto<ReviewDto>>
    {
        public InputPageResultDto InputPage { get; set; }
        public ReviewType ReviewType { get; set; }
        public long? CompanyId { get; set; }
        public long? ShopId { get; set; }
    }
}
