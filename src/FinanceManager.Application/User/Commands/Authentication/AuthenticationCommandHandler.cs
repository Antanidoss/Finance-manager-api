using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.Authentication
{
    public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, Result>
    {
        private readonly IUserManagerService _userManagerService;

        public AuthenticationCommandHandler(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        public async Task<Result> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            return await _userManagerService.PasswordSignInAsync(request.Email, request.Password, request.IsPersisitent);
        }
    }
}
