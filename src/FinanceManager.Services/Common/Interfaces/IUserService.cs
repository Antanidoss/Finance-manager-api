using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManager.Services.Common.Models.ViewModels.Token;
using FinanceManeger.Web.Models.CreateModel;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<Token> GenerateToken(TokenCreateModel model);
        Task<AuthenticationResponceModel> GetCurrentUser();
        Task Logout();
    }
}
