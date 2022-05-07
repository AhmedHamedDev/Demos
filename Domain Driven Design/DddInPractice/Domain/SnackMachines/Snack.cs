using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SnackMachines
{
    public class Snack : AggregateRoot
    {
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Soda = new Snack(2, "Soda");
        public static readonly Snack Gum = new Snack(3, "Gum");

        public string Name { get; protected set; }

        protected Snack()
        {

        }

        private Snack(long id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
