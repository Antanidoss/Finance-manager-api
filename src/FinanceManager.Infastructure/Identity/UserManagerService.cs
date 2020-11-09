using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserManagerService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> CreateUserAsync(string name, string password, string email)
        {
            if (await EmailIsBusy(email))
            {
                return IdentityResultExtensions.EmailIsBusy();
            }

            var result = await _userManager.CreateAsync(new AppUser() { UserName = name, Email = email }, password);

            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(email), "user");
            //}

            return result.ToApplicationResult();
        }

        public async Task<AppUser> GetAppUserByIdAsync(string appUserId)
        {
            return await _userManager.FindByIdAsync(appUserId);
        }

        private async Task<bool> EmailIsBusy(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null
                ? true
                : false;
        }
    }
}
