using ITPack.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public Guid Id { get; }
        public PackingListNotFoundException(Guid id) 
            : base($"Packing list with Id: '{id}' not found.")
        {
            this.Id = id;
        }
    }
}
