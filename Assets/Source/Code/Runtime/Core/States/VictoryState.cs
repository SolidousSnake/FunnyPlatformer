using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.Core.Utils;
using Source.Code.Runtime.Services.MusicService;
using Source.Code.Runtime.MV.Timer;
using Source.Code.Runtime.Unit;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class VictoryState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MusicService _musicService;
        private readonly AudioClip _victoryClip;
        private readonly VictoryStateView _stateView;
        private readonly Timer _timer;
        private readonly PlayerFacade _playerFacade;
        
        public VictoryState(GameStateMachine stateMachine, VictoryStateView stateView, MusicService musicService
            , AudioClipConfig clipConfig, Timer timer, PlayerFacade playerFacade)
        {
            _stateMachine = stateMachine;
            _stateView = stateView;
            _musicService = musicService;
            _victoryClip = clipConfig.VictoryClip;
            _timer = timer;
            _playerFacade = playerFacade;
        }
        
        public async void Enter()
        {
            Time.timeScale = Constants.Time.PausedValue;   
            _timer.Stop();
            _musicService.PlaySpecificClip(_victoryClip, false);
         
            _stateView.Initialize(_playerFacade.Health.Current, _playerFacade.Wallet.Coins);
            await _stateView.Show();
            _stateMachine.Enter<RestartState>(); 
        }
        
        public void Exit()
        {
            Time.timeScale = Constants.Time.ResumedValue;
            _stateView.Hide();
        }
    }
}