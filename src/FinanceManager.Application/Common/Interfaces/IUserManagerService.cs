using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<Result> CreateUserAsync(string name, string password, string email);
        Task<AppUser> GetAppUserByIdAsync(string appUserId);
    }
}
