using System;

namespace Source.Code.Runtime.MV.Wallet
{
    public sealed class Wallet
    {
        private int _coins;

        public Wallet()
        {
            _coins = 0;
        }

        public Wallet(int startAmount)
        {
            _coins = startAmount;
        }

        public event Action<int> CoinsAmountChanged;

        public void AddCoin(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("amount less than zero");
            
            _coins += amount;
            CoinsAmountChanged?.Invoke(_coins);
        }
    }
}