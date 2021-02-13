using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Infastructure.Identity;
using FinanceManager.Persistence.Common.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication();                

            services.AddAuthorization();

            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;

                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EFDbContext>();

            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IRoleManagerService, RoleManagerService>();

            return services;
        }
    }
}
