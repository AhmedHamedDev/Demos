using ITPack.Shared.Abstractions.Commands;
using ITPack.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Shared.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemmoryCommandDispatcher>();
            services.Scan(s=>s.FromAssemblies(assembly)
            .AddClasses(c=>c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
