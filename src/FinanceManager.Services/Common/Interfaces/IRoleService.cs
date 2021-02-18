using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IRoleService
    {
        Task<Result> CreateRoleAsync(string roleName);
        Task<Response<RoleDTO>> GetRoleByNameAsync(string roleName);
    }
}
