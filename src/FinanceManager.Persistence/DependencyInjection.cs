using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Persistence.Common.Context;
using FinanceManager.Persistence.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDbContext>(option => option.UseSqlServer(connection));

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IDailyReportRepository, DailyReportRepository>();

            return services;
        }
    }
}