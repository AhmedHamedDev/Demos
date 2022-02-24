using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new Exception("Guid Can't be Empty");
            }

            Value = value;
        }

        public static implicit operator Guid(PackingListId id)
            => id.Value;

        public static implicit operator PackingListId(Guid id)
            => new(id);
    }
}
