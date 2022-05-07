using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.EF.Models
{
    internal class PackingListReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public LocalizationReadModel Localization { get; set; }
        public ICollection<PackingItemReadModel> Items { get; set; }
    }
}
