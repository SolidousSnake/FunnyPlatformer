using TMPro;
using UnityEngine;

namespace Source.Code.Runtime.MV.Wallet
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class WalletView : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI _coinLabel;

        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.CoinsAmountChanged += SetAmount;
        }

        private void SetAmount(int amount)
        {
            _coinLabel.text = $"{amount}";
        }
        
        private void OnDestroy()
        {
            _wallet.CoinsAmountChanged -= SetAmount;
        }
    }
}