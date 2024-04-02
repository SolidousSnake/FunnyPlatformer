using Cysharp.Threading.Tasks;
using Source.Code.Runtime.Core.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Code.Runtime.Core.States.View
{
    public class BaseStateView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        protected UniTaskCompletionSource<TargetStates> result;

        public UniTask<TargetStates> Show()
        {
            gameObject.SetActive(true);
            result = new UniTaskCompletionSource<TargetStates>();
            return result.Task;
        }

        public void Hide() => gameObject.SetActive(false);
        
        private void OnEnable() => Enable();

        private void OnDisable() => Disable();

        protected virtual void Enable()
        {
            _restartButton.onClick.AddListener(() => result.TrySetResult(TargetStates.Restart));
            _quitButton.onClick.AddListener(() => result.TrySetResult(TargetStates.Quit));
        }

        protected virtual void Disable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }
    }
}