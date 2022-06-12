using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));

            return services;
        }
    }
}
