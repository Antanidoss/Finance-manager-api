using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Command.CreateUser
{
    public class CreateUserQueryCommand : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserManagerService _userManagerService;

        public CreateUserQueryCommand(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userManagerService.CreateUserAsync(request.Name, request.Password, request.Email);
        }
    }
}
