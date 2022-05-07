using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SnackMachines
{
    public class Slot : Entity
    {
        public SnackPile SnackPile { get; set; }
        public SnackMachine SnackMachine { get; protected set; }
        public int Position { get; protected set; }

        protected Slot()
        {

        }

        public Slot(SnackMachine snackMachine, int position) : this()
        {
            SnackMachine = SnackMachine;
            Position = position;
            SnackPile = SnackPile.Empty;
        }
    }
}
