﻿using FinanceManager.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IRoleManagerService
    {
        Task<Result> CreateAsync(string roleName);
        Task<IdentityRole> GetByNameAsync(string roleName);
    }
}
