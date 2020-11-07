using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.User.Command.CreateUser;
using FinanceManager.Application.User.Command.GenerateToken;
using FinanceManager.Application.User.Command.GetUserById;
using FinanceManeger.Web.Models.CreateModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("token/{token}")]
        public async Task<Token> GenerateToken(CreateTokenModel model)
        {
            return await _mediator.Send(new GenerateTokenQuery(model.Name, model.Email, model.Password));
        }

        [HttpPost("create")]
        public async Task<Result> CreateUser(CreateUserModel model)
        {
            return await _mediator.Send(new CreateUserCommand(model.Name, model.Email, model.Password));
        }

        [HttpPost("get/{userId}")]
        public async Task<AppUserDTO> GetUserById(string userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));
        }
    }
}
