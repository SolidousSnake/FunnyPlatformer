using System;
using Source.Code.Runtime.Config;
using Source.Code.Runtime.Core.Data;
using Source.Code.Runtime.Core.Enums;
using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Core.States.View;
using Source.Code.Runtime.MV.Timer;
using Source.Code.Runtime.Services.MusicService;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class VictoryState : IState
    {
        private readonly MusicService _musicService;
        private readonly AudioClip _victoryClip;
        private readonly ResultView _resultView;
        private readonly ISceneLoader _sceneLoader;
        private readonly Timer _timer;
        
        public VictoryState(ResultView view, ISceneLoader sceneLoader, MusicService musicService
            , AudioClipConfig clipConfig, Timer timer)
        {
            _resultView = view;
            _sceneLoader = sceneLoader;
            _musicService = musicService;
            _victoryClip = clipConfig.VictoryClip;
            _timer = timer;
        }
        
        public async void Enter()
        {
            _timer.Stop();
            _resultView.gameObject.SetActive(true);
            _musicService.PlaySpecificClip(_victoryClip, false);
            
             var result = await _resultView.Show();
             
             switch (result)
             {
                 case TargetStates.Restart:
                     _sceneLoader.LoadScene(Constants.Scene.Game);
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
        }
    }
}