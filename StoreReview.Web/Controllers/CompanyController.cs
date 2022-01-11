using MediatR;
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
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetCompanies()
            => await _mediator.Send(new GetCompaniesQuery());

        [HttpGet("{companyId:long}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyById([FromRoute] long companyId)
        {
            var query = new GetCompanyByIdQuery()
            {
                CompanyId = companyId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<long> CreateCompany([FromBody] AddCompanyCommand command)
        {
            var entityId = await _mediator.Send(command);
            return entityId;
        }

        [HttpPut("{companyId:long}")]
        public async Task<ActionResult> UpdateCompany([FromRoute] long companyId, [FromBody] UpdateCompanyCommand command)
        {
            command.Id = companyId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{companyId:long}")]
        public async Task<ActionResult> DeleteCompany([FromRoute] long companyId)
        {
            await _mediator.Send(new DeleteCompanyCommand
            {
                Id = companyId
            });
            return NoContent();
        }
    }
}