using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Core.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Code.Runtime.Core.States.View
{
    public sealed class ResultView :  MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private UniTaskCompletionSource<TargetStates> _result;

        public UniTask<TargetStates> Show()
        {
            _result = new UniTaskCompletionSource<TargetStates>();
            return _result.Task;
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(() => _result.TrySetResult(TargetStates.Restart));
            _quitButton.onClick.AddListener(() => _result.TrySetResult(TargetStates.Quit));
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }
    }
}