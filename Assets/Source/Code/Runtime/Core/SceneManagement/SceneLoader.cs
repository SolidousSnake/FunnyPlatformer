using Source.Code.Runtime.Core.Interfaces;
using UnityEngine.SceneManagement;

namespace Source.Code.Runtime.Core.SceneManagement
{
    public sealed class SceneLoader : ISceneLoader
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}