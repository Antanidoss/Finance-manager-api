using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManeger.Web.Models.CreateModel;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IUserService
    {
        Task<Result> RegistrationAsync(RegistrationModel model);
        Task<Response<AppUserDTO>> AuthenticationAsync(AuthenticationModel model);
        Task<bool> CheckIsEmailBusy(string email);
        Task<Result> AddToRoleAsync(string email, string roleName);
        Task<Response<AppUserDTO>> GetUserById(string userId);
        string GetCurrentUserId();
        Task Logout();
    }
}
