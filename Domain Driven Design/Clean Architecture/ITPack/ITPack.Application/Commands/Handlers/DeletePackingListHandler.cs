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
    internal sealed class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        private readonly IPackingListRepository _packingListRepository;

        public DeletePackingListHandler(IPackingListRepository packingListRepository)
         =>   this._packingListRepository = packingListRepository;

        public async Task HandleAsync(DeletePackingList command)
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
