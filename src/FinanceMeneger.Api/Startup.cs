using FinanceManager.Api.Helpers;
using FinanceManager.Application;
using FinanceManager.Infastructure;
using FinanceManager.Persistence;
using FinanceManager.Persistence.Common.Context;
using FinanceManager.Services.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManeger.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddControllers();

            AddAuthentication(services);

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddIfastructure(Configuration);
            services.AddServices();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x =>
            x.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseRouting();
            app.UseSession();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseDeveloperExceptionPage();
            app.UseAuthentication();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(context =>
            {
                context.Response.Redirect("swagger/index.html");
                return Task.CompletedTask;
            });

            Task.Run(async () => await InitializeDB(app));
        }

        private async Task InitializeDB(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EFDbContext>();
                if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                    context.Database.EnsureCreated();
                }

                var service = serviceScope.ServiceProvider;
                var userService = service.GetRequiredService<IUserService>();
                var roleService = service.GetRequiredService<IRoleService>();

                await IdentityInitializer.InitializeAsync(userService, roleService);
            }
        }

        private void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "FinanceManagerServer",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").Value)),
                    ValidAudience = "FinanceManagerClient",
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };
            });
        }
    }
}
