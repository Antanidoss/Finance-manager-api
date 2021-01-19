using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IRoleService
    {
        Task<Result> CreateRoleAsync(string roleName);
        Task<Response<RoleViewModel>> GetRoleByNameAsync(string roleName);
    }
}
