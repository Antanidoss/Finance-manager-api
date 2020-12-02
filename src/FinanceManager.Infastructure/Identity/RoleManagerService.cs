using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using FinanceManager.Infastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infastructure.Identity
{
    public class RoleManagerService : IRoleManagerService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result> CreateAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            return result.ToApplicationResult();
        }

        public async Task<IdentityRole> GetByNameAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            return await _roleManager.FindByNameAsync(roleName);
        }
    }
}
