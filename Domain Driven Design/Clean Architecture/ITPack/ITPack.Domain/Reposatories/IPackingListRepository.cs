using ITPack.Domain.Entities;
using ITPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Reposatories
{
    public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId id);
        Task AddAsync(PackingList packingList);
        Task UpdateAsync(PackingList packingList);
        Task DeleteAsync(PackingList packingList);
    }
}
