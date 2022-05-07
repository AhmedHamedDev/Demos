using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Shared.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
