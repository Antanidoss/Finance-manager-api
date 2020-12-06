using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManeger.Web.Models.CreateModel;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Interfaces
{
    public interface IUserService
    {
        string GetCurrentUserId();
        Task<Result> RegistrationAsync(RegistrationModel model);
        Task<Result> AuthenticationAsync(AuthenticationModel model);
        Task<bool> CheckIsEmailBusy(string email);
        Task<Result> AddToRoleAsync(string email, string roleName);
        Task<AuthenticationResponceModel> GetCurrentUser();
        Task Logout();
    }
}
