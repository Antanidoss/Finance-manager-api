using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));

            services.AddIdentity<AppUser, IdentityRole>(option =>
            {

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}
