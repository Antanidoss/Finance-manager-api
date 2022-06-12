using FinanceManager.Application;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly AppSettings _appSettings;

        public UserManagerService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public async Task<Result> AddToRoleAsync(string email, string roleName)
        {
            var appUser = await _userManager.FindByEmailAsync(email);

            return (await _userManager.AddToRoleAsync(appUser, roleName)).ToApplicationResult();
        }

        public async Task<Result> CreateUserAsync(string name, string email, string password)
        {
            if (await CheckIsEmailBusy(email))
                return Result.Failure(ErrorMessageConstants.EmailIsBusy);

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
            return (await _userManager.FindByEmailAsync(email)) != null;
        }

        public async Task<(AppUser User, string Token)> GetUserByIdAsync(string appUserId)
        {
            var user = await _userManager.FindByIdAsync(appUserId);
            if (user == null)
                return default;

            return (User: user, Token: GenerateJwtToken(appUserId));
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<(AppUser User, string Token, Result Result)> PasswordSignInAsync(string email, string password, bool isParsistent)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return (null, null, Result.Failure(ErrorMessageConstants.EmailNotFound));

            var checkPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!checkPassword)
                return (null, null, Result.Failure(ErrorMessageConstants.InvalidEmailOrPassword));

            var res = await _signInManager.PasswordSignInAsync(user, password, isParsistent, false);
            if (!res.Succeeded)
                return (null, null, Result.Failure(ErrorMessageConstants.InvalidEmailOrPassword));

            return (User: user, Token: GenerateJwtToken(user.Id), Result: Result.Success());
        }

        private string GenerateJwtToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
