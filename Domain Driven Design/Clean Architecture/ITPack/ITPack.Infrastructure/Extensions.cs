using ITPack.Application.Services;
using ITPack.Infrastructure.EF;
using ITPack.Infrastructure.Services;
using ITPack.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITPack.Infrastructure.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();
            return services;
        }
    }
}
