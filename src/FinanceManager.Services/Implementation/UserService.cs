using AutoMapper;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.User.Command.GetUserById;
using FinanceManager.Application.User.Commands.AddToRole;
using FinanceManager.Application.User.Commands.Authentication;
using FinanceManager.Application.User.Commands.Logout;
using FinanceManager.Application.User.Commands.Registration;
using FinanceManager.Application.User.Queries.GetUserByEmail;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManeger.Web.Models.CreateModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMapper _mapper;

        public UserService(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<Result> AddToRoleAsync(string email, string roleName)
        {
            return await _mediator.Send(new AddToRoleCommand(email, roleName));
        }

        public async Task<Result> AuthenticationAsync(AuthenticationModel model)
        {
            return await _mediator.Send(new AuthenticationCommand(model.Email, model.Password, model.IsParsistent));         
        }

        public async Task<bool> CheckIsEmailBusy(string email)
        {
            return await _mediator.Send(new CheckIsEmailBusyQuery(email));
        }

        public async Task<Response<AuthenticationResponseModel>> GetCurrentUser()
        {
            var user = _mapper.Map<AppUserViewModel>(await _mediator.Send(new GetUserByIdQuery(GetCurrentUserId())));
            var authenticationModel = new AuthenticationResponseModel(user, user != null ? true : false);

            return new Response<AuthenticationResponseModel>(authenticationModel, Result.Success());
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;            
        }

        public async Task Logout()
        {
            await _mediator.Send(new LogoutCommand());
        }

        public async Task<Result> RegistrationAsync(RegistrationModel model)
        {
            return await _mediator.Send(new RegistrationCommand(model.Name, model.Email, model.Password));          
        }
    }
}
