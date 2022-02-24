﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_Pattern.Policies.Temperature
{
    internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Temperature > 25D;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Hat", 1),
                new("Sunglasses", 1),
                new("Cream with UV filter", 1)
            };
    }
}
