using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("PackingListName Can't be Empty.");
            }

            Value = value;
        }

        public static implicit operator string(PackingListName name)
            => name.Value;

        public static implicit operator PackingListName(string name)
            => new(name);
    }
}
