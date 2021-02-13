using FinanceManager.Application;
using FinanceManager.Infastructure;
using FinanceManager.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddIfastructure(Configuration);           
            services.AddServices();            

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

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseCookiePolicy(new CookiePolicyOptions
            //{
            //    MinimumSameSitePolicy = SameSiteMode.Strict,
            //    HttpOnly = HttpOnlyPolicy.Always,
            //    Secure = CookieSecurePolicy.Always
            //});

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
