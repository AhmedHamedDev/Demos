using ITPack.Domain.Consts;
using ITPack.Domain.Entities;
using ITPack.Domain.Policies;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
            => _policies = policies;

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new(id, name, localization);

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, 
            Gender gender, Temperature temperature, Localization localization)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
            var pakingList = Create(id, name, localization);

            pakingList.AddItems(items);

            return pakingList;
        }
    }
}
