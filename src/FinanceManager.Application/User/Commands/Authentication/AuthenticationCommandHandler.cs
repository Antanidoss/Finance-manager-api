using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.Authentication
{
    public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, (AppUserDTO User, Result Result)>
    {
        private readonly IUserManagerService _userManagerService;

        public AuthenticationCommandHandler(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        public async Task<(AppUserDTO ,Result)> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            return await _userManagerService.PasswordSignInAsync(request.Email, request.Password, request.IsPersisitent);
        }
    }
}
