using System;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Services.MusicService;
using Source.Code.Runtime.Unit;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class PreparingState : IState, IDisposable
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MusicService _musicService;
        private readonly AudioClipConfig _clipConfig;
        private readonly PlayerFacade _playerFacade; 
        
        public PreparingState(GameStateMachine stateMachine, MusicService musicService, AudioClipConfig clipConfig
            , PlayerFacade playerFacade)
        {
            _stateMachine = stateMachine;
            _musicService = musicService;
            _clipConfig = clipConfig;
            _playerFacade = playerFacade;
        }
        
        public void Enter()
        {
            _musicService.EnqueueClip(_clipConfig.StartClip);
            _musicService.EnqueueClip(_clipConfig.LoopClip);
            _musicService.PlayQueue().Forget();

            _playerFacade.Health.Depleted += EnterFailureState;

            _stateMachine.Enter<PlayingState>();
        }

        public void Exit()
        {
            Debug.Log("Exiting preparing state");
        }

        private void EnterFailureState()
        {
            _stateMachine.Enter<FailureState>();
        }


        public void Dispose()
        {
            _playerFacade.Health.Depleted -= EnterFailureState;
        }
    }
}