using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<Result> CreateUserAsync(string name, string email, string password);
        Task<AppUser> GetUserByIdAsync(string appUserId);
        Task<Result> AddToRoleAsync(string email, string roleName);
        Task<bool> CheckIsEmailBusy(string email);
        Task<(AppUserDTO User, Result Result)> PasswordSignInAsync(string email, string password, bool isParsistent);
        Task SignOutAsync();
    }
}
