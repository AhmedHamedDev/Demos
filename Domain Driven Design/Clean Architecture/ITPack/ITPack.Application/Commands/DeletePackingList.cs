using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Commands
{
    public record DeletePackingList(Guid Id) : Shared.Abstractions.Commands.ICommand;
}
