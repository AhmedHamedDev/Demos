using ITPack.Domain.ValueObjects;
using ITPack.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Exceptions
{
    internal class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; }

        public MissingLocalizationWeatherException(Localization localization) 
            : base($"Couldn't fetch weather data for localization '{localization.Country}/{localization.City}'")
        {
            Localization = localization;
        }
    }
}
