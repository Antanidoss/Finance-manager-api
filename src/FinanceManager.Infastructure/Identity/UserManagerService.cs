using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public UserManagerService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result> AddToRoleAsync(string email, string roleName)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRoleAsync(appUser, roleName);

            return result.ToApplicationResult();
        }

        public async Task<Result> CreateUserAsync(string name, string email, string password)
        {
            if (await CheckIsEmailBusy(email))
            {
                return IdentityResultExtensions.EmailIsBusy();
            }

            var user = new AppUser() { UserName = name, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(email), "user");
                await _signInManager.SignInAsync(user, true);
            }

            return result.ToApplicationResult();
        }

        public async Task<bool> CheckIsEmailBusy(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null 
                ? true 
                : false;
        }

        public async Task<AppUser> GetUserByIdAsync(string appUserId)
        {
            return await _userManager.FindByIdAsync(appUserId);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }       

        public async Task<Result> PasswordSignInAsync(string email, string password, bool isParsistent)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Result.Failure(new string[] { "Эл.почта не найдена" });
            }

            var check = await _userManager.CheckPasswordAsync(user, password);
            if (!check)
            {
                return Result.Failure(new string[] { "Неверная эл.почта или пароль" });
            }

            await _signInManager.PasswordSignInAsync(user, password, isParsistent, false);

            return Result.Success();
        }
    }
}
