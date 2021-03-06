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
    internal sealed class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public SearchPackingListsHandler(ReadDbContext context)
            => _packingLists = context.PackingLists;

        public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingLists.Include(x => x.Items).AsQueryable();

            if(query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.Like(x.Name, 
                    $"%{query.SearchPhrase}%"));
            }

            return await dbQuery.Select(x => x.AsDto())
                         .AsNoTracking()
                         .ToListAsync();
        }
    }
}
