using FinanceManager.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class AuthenticationResponceModel
    {
        public AppUserViewModel User { get; set; }
        public bool IsAuthenticated { get; set; }

        public AuthenticationResponceModel(AppUserViewModel user, bool isAuthenticated)
        {
            User = user;
            IsAuthenticated = isAuthenticated;
        }        
    }
}
