using FinanceManager.Application.Common.DTO;
using MediatR;

namespace FinanceManager.Application.Role.Query.GetRoleByName
{
    public class GetRoleByNameQuery : IRequest<RoleDTO>
    {
        public readonly string RoleName;

        public GetRoleByNameQuery(string roleName)
        {
            RoleName = roleName;
        }
    }
}
