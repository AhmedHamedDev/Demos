using ITPack.Domain.Factories;
using ITPack.Domain.Policies;
using ITPack.Shared;
using ITPack.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ITPack.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(s => s.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

            return services;
        }
    }
}
