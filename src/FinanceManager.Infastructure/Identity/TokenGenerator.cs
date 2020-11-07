using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infastructure.Identity
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<AppUser> _userManager;

        public TokenGenerator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Token> GenerateToken(string name, string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return null; //TODO:
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = CreateClaims(user.Id, name, email);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = CreateToken(claims);    

            return new Token(new JwtSecurityTokenHandler().WriteToken(token), email);
        }

        private List<Claim> CreateClaims(string appUserId, string name, string email)
        {
            return  new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, appUserId),
                new Claim(ClaimTypes.Name, name),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeMilliseconds().ToString())
            };
        }

        private JwtSecurityToken CreateToken(List<Claim> claims)
        {
            return new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                new SigningCredentials(AuthOptions.GetSummetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }
    }
}
