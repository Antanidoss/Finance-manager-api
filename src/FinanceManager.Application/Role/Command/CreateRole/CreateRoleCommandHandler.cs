using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Role.Command.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result>
    {
        private readonly IRoleManagerService _roleManagerService;
        public CreateRoleCommandHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerService.CreateAsync(request.RoleName);
        }
    }
}
