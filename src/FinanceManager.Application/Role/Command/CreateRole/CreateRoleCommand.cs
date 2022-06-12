using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.Role.Command.CreateRole
{
    public class CreateRoleCommand : IRequest<Result>
    {
        public readonly string RoleName;

        public CreateRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
}
