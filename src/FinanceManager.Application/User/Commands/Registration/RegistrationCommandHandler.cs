using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Result>
    {
        private readonly IUserManagerService _userManagerService;
        public RegistrationCommandHandler(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        public async Task<Result> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            return await _userManagerService.CreateUserAsync(request.Name, request.Email, request.Password);
        }
    }
}
