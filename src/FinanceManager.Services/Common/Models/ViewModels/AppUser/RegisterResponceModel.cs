using FinanceManager.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class RegisterResponceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Result Result { get; set; }

        public RegisterResponceModel(string id, string name, string email, Result result)
        {
            Id = id;
            Name = name;
            Email = email;
            Result = result;
        }

        public RegisterResponceModel(Result result)
        {
            Result = result;
        }
    }
}
