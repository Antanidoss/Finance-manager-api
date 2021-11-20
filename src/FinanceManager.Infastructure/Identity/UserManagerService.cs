using FinanceManager.Application;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Http;
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

        private readonly IHttpContextAccessor _httpAccessor;
        public UserManagerService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<AppSettings> appSettings, IHttpContextAccessor httpAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _httpAccessor = httpAccessor;
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

        public async Task<(AppUserDTO User, Result Result)> PasswordSignInAsync(string email, string password, bool isParsistent)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return (null, Result.Failure(new string[] { "Эл.почта не найдена" }));
            }

            var check = await _userManager.CheckPasswordAsync(user, password);
            if (!check)
            {
                return (null, Result.Failure(new string[] { "Неверная эл.почта или пароль" }));
            }

           var res = await _signInManager.PasswordSignInAsync(user, password, isParsistent, false);
           if (!res.Succeeded)
           {
               return (null, Result.Failure(new string[] { "Неверная эл.почта или пароль" }));
           }

            var token = GenerateJwtToken(user.Id);
            _httpAccessor.HttpContext.Response.Cookies.Append("Token", token, new CookieOptions { HttpOnly = true });

            return (User: new AppUserDTO() { Id = user.Id, Email = email, Password = password, UserName = user.UserName, Token = token }, Result: Result.Success());
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
