using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreReview.Core;
using StoreReview.Core.Commands;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Queries;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/reviews/{reviewType}")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get")]
        public async Task<ActionResult<PagedResultDto<CompanyDto>>> GetReviews([FromRoute] ReviewType reviewType, [FromBody] GetReviewsQuery query)
        {
            query.ReviewType = reviewType;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<long>> AddReview([FromRoute] ReviewType reviewType, [FromBody] AddReviewCommand query)
        {
            query.ReviewType = reviewType;
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}