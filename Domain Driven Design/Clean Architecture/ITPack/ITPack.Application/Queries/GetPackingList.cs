using ITPack.Application.Dtos;
using ITPack.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}
