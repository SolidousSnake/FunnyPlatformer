using System;
using Source.Code.Runtime.Core.Utils;
using UnityEngine;
using VContainer.Unity;

namespace Source.Code.Runtime.Services.InputService
{
    public sealed class OldInputService : IInputService, ITickable
    {
        public event Action PauseButtonPressed;
        public event Action JumpButtonPressed;
        public event Action MovementButtonReleased;
        public event Action<float> MovementButtonPressing;

        public void Tick()
        {
            if (Input.GetButton(Constants.Input.Horizontal))
                MovementButtonPressing?.Invoke(Input.GetAxisRaw(Constants.Input.Horizontal));

            if (Input.GetButtonUp(Constants.Input.Horizontal))
                MovementButtonReleased?.Invoke();
            
            if (Input.GetButtonDown(Constants.Input.Jump))
                JumpButtonPressed?.Invoke();
            
            if (Input.GetButtonDown(Constants.Input.Pause))
                PauseButtonPressed?.Invoke();
        }
    }
}