using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<Result> CreateUserAsync(string name, string email, string password);
        Task<(AppUser User, string Token)> GetUserByIdAsync(string appUserId);
        Task<Result> AddToRoleAsync(string email, string roleName);
        Task<bool> CheckIsEmailBusy(string email);
        Task<(AppUser User, string Token, Result Result)> PasswordSignInAsync(string email, string password, bool isParsistent);
        Task SignOutAsync();
    }
}