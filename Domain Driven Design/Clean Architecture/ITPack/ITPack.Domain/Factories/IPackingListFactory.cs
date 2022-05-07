using ITPack.Domain.Consts;
using ITPack.Domain.Entities;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Factories
{
    public interface IPackingListFactory
    {
        PackingList Create(PackingListId id, PackingListName name, Localization localization);
        PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days,
            Gender gender, Temperature temperature, Localization localization);
    }
}
