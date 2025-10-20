using System;
using System.Threading.Tasks;
using _Project.Infrustructure.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace _Project.Infrustructure.EntryPoint
{
    public class GameBootstrapper : MonoBehaviour
    {
        private ISceneLoaderService _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoaderService sceneLoader) => 
            _sceneLoader = sceneLoader;

        private async Task Awake() => 
            await _sceneLoader.Load(SceneName.MainMenu);
    }
}