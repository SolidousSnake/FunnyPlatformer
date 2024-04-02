using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Code.Runtime.Core.States.View
{
    public sealed class VictoryStateView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthLabel;
        [SerializeField] private TextMeshProUGUI _coinsLabel;
        [SerializeField] private Button _continueButton;
        
        private UniTaskCompletionSource<bool> _result;

        public void Initialize(float health, int coins)
        {
            _healthLabel.text = $"{health}";
            _coinsLabel.text = $"{coins}";
        }
        
        public UniTask<bool> Show()
        {
            gameObject.SetActive(true);
            _result = new UniTaskCompletionSource<bool>();
            return _result.Task;
        }

        public void Hide() => gameObject.SetActive(false);

        private void OnEnable() => _continueButton.onClick.AddListener(() => _result.TrySetResult(true));

        private void OnDisable() => _continueButton.onClick.RemoveAllListeners();
    }
}