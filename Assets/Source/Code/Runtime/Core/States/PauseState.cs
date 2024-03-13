using System;
using Source.Code.Runtime.Core.Enums;
using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Core.States.View;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PauseState : IState
    {
        private readonly PauseStateView _stateView;
        private readonly GameStateMachine _stateMachine;
        
        public PauseState(PauseStateView stateView, GameStateMachine stateMachine)
        {
            _stateView = stateView;
            _stateMachine = stateMachine;
        }
        
        public async void Enter()
        {
            _stateView.gameObject.SetActive(true);
            
            var result = await _stateView.Show();
            switch (result)
            {             
                case TargetStates.Resume:
                    _stateMachine.SetState<PlayingState>();
                    break;   
                case TargetStates.Restart:
                    _stateMachine.SetState<RestartState>();
                    break;
                case TargetStates.Quit:
                    Application.Quit();
                    break;
                default:
                    throw new ArgumentException("Unknown result");
            }

        }

        public void Exit()
        {
            _stateView.gameObject.SetActive(false);
        }
    }
}