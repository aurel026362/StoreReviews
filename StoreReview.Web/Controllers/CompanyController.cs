﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IList<CompanyDto>>> GetCompanies()
        {
            var query = new GetCompaniesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

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
    }
}