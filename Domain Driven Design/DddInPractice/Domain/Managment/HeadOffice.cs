using Domain.Atms;
using Domain.Common;
using Domain.SharedKernel;
using Domain.SnackMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Managment
{
    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }
        public virtual Money Cach { get; protected set; } = Money.None;


        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }

        public virtual void UnloadCashFromSnackMachine(SnackMachine snackMachine)
        {

        }

        public virtual void LoadCashToAtm(Atm atm)
        {

        }
    }
}
