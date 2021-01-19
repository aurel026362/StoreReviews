using MediatR;
using StoreReview.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Core.Queries
{
    public class GetShopsByCompanyIdQuery : IRequest<IList<ShopDto>>
    {
        public long CompanyId { get; set; }
    }
}
