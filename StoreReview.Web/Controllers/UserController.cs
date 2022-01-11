using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreReivew.Infrastracture.Data;
using StoreReview.Core.Domain;
using StoreReview.Core.DtoModels;
using StoreReview.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreReview.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly StoreReviewDbContext _dbContext;
        private readonly ICurrentUser _currentUser;

        public UserController(IMediator mediator, StoreReviewDbContext dbContext, ICurrentUser currentUser, IMapper mapper)
        {
            _mediator = mediator;
            _dbContext = dbContext;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            if (!_currentUser.Id.HasValue) {
                return BadRequest();
            }
            var user = await _dbContext.Users
                .SingleAsync(x => x.Id == _currentUser.Id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
