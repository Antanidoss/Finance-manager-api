using FinanceManager.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManeger.Api.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            _next = requestDelegate;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserManagerService userManagerService)
        {
            string token = context.Request.Headers["Authorization"];
            if(token != null)
            {
                AttachUserToContext(context, userManagerService, token);
            }

            await _next(context);
        }

        public void AttachUserToContext(HttpContext context, IUserManagerService userManagerService, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            context.Items["User"] = userManagerService.GetAppUserByIdAsync(userId);
        }
    }
}
