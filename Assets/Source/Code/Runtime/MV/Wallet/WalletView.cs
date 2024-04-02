using TMPro;
using UnityEngine;

namespace Source.Code.Runtime.MV.Wallet
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class WalletView : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI _coinLabel;

        public void SetAmount(int amount)
        {
            _coinLabel.text = $"{amount}";
        }
    }
}