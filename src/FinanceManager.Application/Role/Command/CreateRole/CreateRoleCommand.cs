using FinanceManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
