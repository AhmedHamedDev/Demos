using ITPack.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Shared.Commands
{
    internal sealed class InMemmoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemmoryCommandDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetService<ICommandHandler<TCommand>>();

            await handler.HandleAsync(command);
        }
    }
}
