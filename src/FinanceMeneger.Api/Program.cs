using System.Threading.Tasks;
using FinanceManager.Api.Helpers;
using FinanceManager.Services.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceManeger.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var userService = service.GetRequiredService<IUserService>();
                var roleService = service.GetRequiredService<IRoleService>();

                await IdentityInitializer.InitializeAsync(userService, roleService);

                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
