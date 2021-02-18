using AutoMapper;
using FinanceManager.Application;
using FinanceManager.Application.Common.Mappings;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Mappings;
using FinanceManager.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {           
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ReportViewModelProfile());
                mc.AddProfile(new ReportDTOProfile());
                mc.AddProfile(new DailyReportDTOProfile());
                mc.AddProfile(new AppUserDTOProfile());
                mc.AddProfile(new RoleDTOProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IDailyReportService, DailyReportService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStatisticsService, StatisticsService>();

            return services;
        }
    }
}
