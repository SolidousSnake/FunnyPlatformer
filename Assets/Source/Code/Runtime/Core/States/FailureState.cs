using System;
using Source.Code.Runtime.Core.Data;
using Source.Code.Runtime.Core.Enums;
using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.Core.States.View;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class FailureState : IState
    {
        private readonly ResultView _resultView;
        private readonly ISceneLoader _sceneLoader;
        
        public FailureState(ResultView resultView, ISceneLoader sceneLoader)
        {
            _resultView = resultView;
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter()
        {
            _resultView.gameObject.SetActive(true);
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