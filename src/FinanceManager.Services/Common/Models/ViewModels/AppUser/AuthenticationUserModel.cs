using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class AuthenticationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsParsistent { get; set; }
    }
}
