using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ITPack.Shared.Abstractions.Commands;

namespace ITPack.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Domain.Consts.Gender Gender,
        LocalizationWriteModel Localization) : Shared.Abstractions.Commands.ICommand;

    public record LocalizationWriteModel(string City, string Country);
}
