using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreReview.Core.Commands;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ShopDto>>> GetShops()
        {
            var query = new GetShopsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-companyId/{companyId:long}")]
        public async Task<ActionResult<IList<ShopDto>>> GetShopsByCompanyId([FromRoute] long companyId)
        {
            var query = new GetShopsByCompanyIdQuery()
            {
                CompanyId = companyId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{shopId:long}")]
        public async Task<ShopDto> GetShopById([FromRoute] long shopId)
        {
            var query = new GetShopByIdQuery()
            {
                Id = shopId
            };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<long> CreateShop([FromBody] CreateShopCommand command)
        {
            var entityId = await _mediator.Send(command);
            return entityId;
        }

        [HttpPut("{shopId:long}")]
        public async Task<ActionResult> UpdateShop([FromRoute] long shopId, [FromBody] UpdateShopCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{shopId:long}")]
        public async Task<ActionResult> DeleteShop([FromRoute] long shopId)
        {
            await _mediator.Send(new DeleteShopCommand()
            {
                Id = shopId
            });
            return NoContent();
        }
    }
}