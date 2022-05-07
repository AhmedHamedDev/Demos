using ITPack.Application.Dtos.External;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(Localization localization);
    }
}
