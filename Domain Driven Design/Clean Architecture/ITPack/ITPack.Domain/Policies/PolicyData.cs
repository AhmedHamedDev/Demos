using ITPack.Domain.Consts;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);
}
