using ITPack.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Application.Exceptions
{
    public class PackingListAlreadyExistsException : PackItException
    {
        public string Name { get; }
        public PackingListAlreadyExistsException(string name)
            : base($"Packing list with name '{name}' already exists.")
        {
            Name = name;
        }
    }
}
