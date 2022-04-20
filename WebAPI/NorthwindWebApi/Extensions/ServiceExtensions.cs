using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Contracts;
using Northwind.LoggerService;
using Northwind.Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Northwind.Repository;
using Northwind.Contracts;
using Northwind.Contracts.ServiceChart;
using Northwind.Repository.CartService;

namespace NorthwindWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        // Add IIS configue options deploy to ISS
        public static void ConfigureISSIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        // Create a service once per request
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        // Configure to db
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("development")
            ));

        public static void ConfigureManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureService(this IServiceCollection services) =>
            services.AddScoped<IChartService, ChartService>();
    }
}
