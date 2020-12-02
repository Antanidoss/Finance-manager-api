using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.Models
{
    public class AuthOptions
    {
        const string KEY = "financeManager_secretKey228!";  
        public const int LIFETIME = 300; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
