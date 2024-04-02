using Source.Code.Runtime.Core.SceneManagement;
using Source.Code.Runtime.Core.Utils;
using UnityEngine;

namespace Source.Code.Runtime.Core.States
{
    public sealed class RestartState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public RestartState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadScene(Constants.Scene.Game);
        }

        public void Exit()
        {
            Debug.Log("Scene has been restarted");
        }
    }
}