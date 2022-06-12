using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.User.Commands.AddToRole
{
    public class AddToRoleCommand : IRequest<Result>
    {
        public readonly string Email;

        public readonly string RoleName;

        public AddToRoleCommand(string email, string roleName)
        {
            Email = email;
            RoleName = roleName;
        }
    }
}
