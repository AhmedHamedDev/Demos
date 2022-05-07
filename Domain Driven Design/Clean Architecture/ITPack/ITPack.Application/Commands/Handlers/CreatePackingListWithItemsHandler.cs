using ITPack.Application.Exceptions;
using ITPack.Application.Services;
using ITPack.Domain.Factories;
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
    public sealed class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _packingListRepository;
        private readonly IPackingListFactory _packingListFactory;
        private readonly IPackingListReadService _packingListReadService;
        private readonly IWeatherService _weatherService;
        public CreatePackingListWithItemsHandler(IPackingListRepository packingListRepository, IPackingListFactory packingListFactory,
            IPackingListReadService packingListReadService, IWeatherService weatherService)
        {
            _packingListRepository = packingListRepository;
            _packingListFactory = packingListFactory;
            _packingListReadService = packingListReadService;
            _weatherService = weatherService;
        }


        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;

            if (await _packingListReadService.ExistsByNameAsync(name))
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if(weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _packingListFactory.CreateWithDefaultItems(id, name, days, gender,
                weather.Temperature, localization);

            await _packingListRepository.AddAsync(packingList);
        }
    }
}
