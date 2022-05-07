using Domain.Common;
using Domain.SharedKernel;

namespace Domain.SnackMachines
{
    public sealed class SnackMachine : AggregateRoot
    {
        public Money MoneyInside { get; private set; } = Money.None;
        public decimal MoneyInTransaction { get; private set; } = 0;
        public IList<Slot> Slots { get; private set; }

        public SnackMachine()
        {
            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public void RetuenMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
                throw new InvalidOperationException();

            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = Slots.Single(x=>x.Position == position);
            slot.SnackPile = snackPile;
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }
    }
}
