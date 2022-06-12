using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.AddToRole
{
    public class AddToRoleCommandHandler : IRequestHandler<AddToRoleCommand, Result>
    {
        private readonly IUserManagerService _userManagerService;

        public AddToRoleCommandHandler(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        public async Task<Result> Handle(AddToRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userManagerService.AddToRoleAsync(request.Email, request.RoleName);
        }
    }
}
