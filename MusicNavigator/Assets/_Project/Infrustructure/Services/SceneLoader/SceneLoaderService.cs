using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Infrustructure.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private SceneName _currentScene;
        
        public SceneName CurrentScene => _currentScene;
        
        public async Task Load(SceneName scene, Action onLoaded = null)
        {
            await Load(scene.ToString(), onLoaded);
            _currentScene = scene;
        }

        private async Task Load(string sceneName, Action onLoaded = null)
        {
            var activeScene = SceneManager.GetActiveScene().name;
            if (activeScene == sceneName)
            {
                onLoaded?.Invoke();
                return;
            }
            
            var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            while (!operation.isDone)
                await Task.Yield();

            Debug.Log(sceneName + " loaded!");
            onLoaded?.Invoke();
        }
    }
}