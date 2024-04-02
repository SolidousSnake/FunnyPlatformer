using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.Core.Utils;
using Source.Code.Runtime.Services.InputService;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PlayingState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayingStateView _stateView;
        private readonly IInputService _inputService;
        
        public PlayingState(GameStateMachine stateMachine, PlayingStateView stateView, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _stateView = stateView;
            _inputService = inputService;
        }
        
        public void Enter()
        {
            Time.timeScale = Constants.Time.ResumedValue;
            _stateView.gameObject.SetActive(true);
            _inputService.PauseButtonPressed += EnterPauseState;
        }

        public void Exit()
        {
            Time.timeScale = Constants.Time.PausedValue;
            _stateView.gameObject.SetActive(false);
            _inputService.PauseButtonPressed -= EnterPauseState;
        }

        private void EnterPauseState() => _stateMachine.Enter<PauseState>();
    }
}