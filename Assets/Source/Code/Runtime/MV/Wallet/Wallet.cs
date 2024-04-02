using System;

namespace Source.Code.Runtime.MV.Wallet
{
    public sealed class Wallet
    {
        private readonly WalletView _walletView;
        
        public Wallet(WalletView walletView)
        {
            Coins = 0;
            _walletView = walletView;
        }

        public Wallet(WalletView walletView, int startAmount)
        {
            Coins = startAmount;
            _walletView = walletView;
        }

        public int Coins { get; private set; }

        public void AddCoin(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("amount less than zero");
            
            Coins += amount;
            _walletView.SetAmount(Coins);
        }
    }
}