using FinanceManager.Services.Common.Interfaces;
using FinanceManeger.Web.Models.CreateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Api.Helpers
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(IUserService userService, IRoleService roleService)
        {
            if(await roleService.GetRoleByNameAsync("user") == null)
            {
                await roleService.CreateRoleAsync("user");
            }
            if(await roleService.GetRoleByNameAsync("admin") == null)
            {
                await roleService.CreateRoleAsync("admin");
            }
            if(!await userService.CheckIsEmailBusy("adminFinanceManager@gmail.com"))
            {
                string name = "AdminName";
                string email = "adminFinanceManager@gmail.com";
                string password = "Adminpassword123#";

                await userService.RegistrationAsync(new RegistrationModel() { Name = name, Email = email, Password = password });

                await userService.AddToRoleAsync(email, "admin");
            }
        }
    }
}
