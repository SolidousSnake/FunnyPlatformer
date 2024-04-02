using Source.Code.Runtime.Core.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Code.Runtime.Core.States.View
{
    public sealed class PauseStateView : BaseStateView
    {
        [SerializeField] private Button _resumeButton;

        protected override void Enable()
        {
            base.Enable();
            _resumeButton.onClick.AddListener(() => result.TrySetResult(TargetStates.Resume));
        }

        protected override void Disable()
        {
            base.Disable();
            _resumeButton.onClick.RemoveAllListeners();
        }
    }
}