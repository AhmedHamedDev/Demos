using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Dtos
{
    public class PackingItemDto
    {
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public bool IsPacked { get; set; }
    }
}
