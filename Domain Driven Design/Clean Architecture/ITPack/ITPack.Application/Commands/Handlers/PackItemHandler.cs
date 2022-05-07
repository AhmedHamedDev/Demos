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
    internal sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public PackItemHandler(IPackingListRepository packingListRepository)
         => this._packingListRepository = packingListRepository;

        public async Task HandleAsync(PackItem command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.PackItem(command.Name);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}
