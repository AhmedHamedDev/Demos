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
    internal sealed class RemovePackingListHandler : ICommandHandler<RemovePackingList>
    {
        private readonly IPackingListRepository _packingListRepository;

        public RemovePackingListHandler(IPackingListRepository packingListRepository)
         =>   this._packingListRepository = packingListRepository;

        public async Task HandleAsync(RemovePackingList command)
        {
            var packingList = await _packingListRepository.GetAsync(command.Id);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            await _packingListRepository.DeleteAsync(packingList);
        }
    }
}
