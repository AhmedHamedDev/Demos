using ITPack.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Exceptions
{
    internal class EmptyPackingListItemNameException : PackItException
    {
        public EmptyPackingListItemNameException() : base("Pacjing item name cannot be empty.")
        {
        }
    }
}
