using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuf
{
    [ProtoContract]
    public class Product
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string? Name { get; set; }

        [ProtoMember(3)]
        public int Quantity { get; set; }

        [ProtoMember(4)]
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Quantity: {Quantity}, Price: {Price}";
        }
    }
}
