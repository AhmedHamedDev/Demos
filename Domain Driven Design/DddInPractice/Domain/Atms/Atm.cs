using Domain.Common;
using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal ComissionRate = 0.01m;

        public virtual Money MoneyInside { get; protected set; } = Money.None;
        public virtual decimal MoneyCharged { get; protected set; }


        public virtual string CanTakeMoney(decimal amount)
        {
            if (amount <= 0m)
                return "Invalid amount";

            if (MoneyInside.Amount < amount)
                return "Not enough money";

            return string.Empty;
        }

        public virtual void TakeMoney(decimal amount)
        {
            if (CanTakeMoney(amount) != string.Empty)
                throw new InvalidOperationException();

            Money output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            decimal amountWithComission = CalculateAmountWithCommision(amount);
            MoneyCharged += amountWithComission;

            AddDomainEvent(new BalanceChangedEvent(amountWithComission));
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }


        private decimal CalculateAmountWithCommision(decimal amount)
        {
            decimal commision = amount * ComissionRate;
            decimal lessThanCent = commision % 0.01m;
            if (lessThanCent > 0)
                commision = commision - lessThanCent + 0.01m;

            return amount + commision;
        }
    }
}
