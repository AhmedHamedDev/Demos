﻿using ITPack.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get; }
        public PackingItemNotFoundException(string itemName) : base($"Packing item '{itemName}' was not found")
        => ItemName = itemName;
    }
}
