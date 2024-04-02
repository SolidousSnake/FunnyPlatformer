using System;

namespace Source.Code.Runtime.Services.InputService
{
    public interface IInputService
    {
        public event Action PauseButtonPressed;
        public event Action JumpButtonPressed;
        public event Action MovementButtonReleased;
        public event Action<float> MovementButtonPressing;
    }
}