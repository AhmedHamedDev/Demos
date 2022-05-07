using ITPack.Application.Exceptions;
using ITPack.Domain.Reposatories;
using ITPack.Domain.ValueObjects;
using ITPack.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Commands.Handlers
{
    internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public AddPackingItemHandler(IPackingListRepository packingListRepository)
         => this._packingListRepository = packingListRepository;

        public async Task HandleAsync(AddPackingItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
