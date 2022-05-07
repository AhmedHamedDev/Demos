using ITPack.Application.Services;
using ITPack.Infrastructure.EF.Contexts;
using ITPack.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.EF.Services
{
    internal sealed class SqlServerPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public SqlServerPackingListReadService(ReadDbContext readDbContext)
            => _packingLists = readDbContext.PackingLists;

        public Task<bool> ExistsByNameAsync(string name)
            => _packingLists.AnyAsync(x => x.Name == name);
    }
}
