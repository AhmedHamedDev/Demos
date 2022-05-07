using ITPack.Application.Dtos.External;
using ITPack.Application.Services;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.Services
{
    internal class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}
