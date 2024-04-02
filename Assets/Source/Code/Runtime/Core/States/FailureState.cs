using System;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Enums;
using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.Services.MusicService;
using Source.Code.Runtime.MV.Timer;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class FailureState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MusicService _musicService;
        private readonly AudioClip _failureClip;
        private readonly BaseStateView _stateView;
        private readonly Timer _timer;
        
        public FailureState(GameStateMachine stateMachine, BaseStateView stateView, MusicService musicService
            , AudioClipConfig clipConfig, Timer timer)
        {
            _stateMachine = stateMachine;
            _stateView = stateView;
            _musicService = musicService;
            _failureClip = clipConfig.FailureClip;
            _timer = timer;
        }
        
        public async void Enter()
        {
            _timer.Stop();
            _musicService.PlaySpecificClip(_failureClip, false);
            
            var result = await _stateView.Show();
             
            switch (result)
            {
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
            _stateView.Hide();
        }
    }
}