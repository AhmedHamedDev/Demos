using ITPack.Application.Exceptions;
using ITPack.Domain.Reposatories;
using ITPack.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Commands.Handlers
{
    internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public RemovePackingItemHandler(IPackingListRepository packingListRepository)
         => this._packingListRepository = packingListRepository;

        public async Task HandleAsync(RemovePackingItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.RemoveItem(command.Name);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
