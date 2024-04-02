using System;
using Source.Code.Runtime.Core.Enums;
using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.Core.Utils;
using Source.Code.Runtime.Services.InputService;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PauseState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PauseStateView _stateView;
        private readonly IInputService _inputService;
 
        public PauseState(GameStateMachine stateMachine, PauseStateView stateView, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _stateView = stateView;
            _inputService = inputService;
        }
        
        public async void Enter()
        {
            Time.timeScale = Constants.Time.PausedValue;
            _inputService.PauseButtonPressed += EnterPlayingState;
            var result = await _stateView.Show();
             
            switch (result)
            {
                case TargetStates.Resume:
                    EnterPlayingState();
                    break;
                case TargetStates.Restart:
                    _stateMachine.Enter<RestartState>();
                    break;
                case TargetStates.Quit:
                    Application.Quit();
                    break;
                default:
                    throw new ArgumentException("There is no result of that type");
            }
        }

        public void Exit()
        {
            Time.timeScale = Constants.Time.ResumedValue;
            _stateView.Hide();
            _inputService.PauseButtonPressed -= EnterPlayingState;
        }

        private void EnterPlayingState() => _stateMachine.Enter<PlayingState>();
    }
}