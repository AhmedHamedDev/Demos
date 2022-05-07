using ITPack.Application.Dtos;
using ITPack.Application.Queries;
using ITPack.Infrastructure.EF.Contexts;
using ITPack.Infrastructure.EF.Models;
using ITPack.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public GetPackingListHandler(ReadDbContext context)
            => _packingLists = context.PackingLists;
        public Task<PackingListDto> HandleAsync(GetPackingList query)
            => _packingLists
                .Include(x => x.Items)
                .Where(x => x.Id == query.Id)
                .Select(x => x.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}
