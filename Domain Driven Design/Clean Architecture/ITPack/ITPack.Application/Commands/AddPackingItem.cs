using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITPack.Shared.Abstractions.Commands;

namespace ITPack.Application.Commands
{
    public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : Shared.Abstractions.Commands.ICommand;
}
