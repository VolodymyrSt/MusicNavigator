using System;
using _Project.Configs.Sound;
using _Project.Infrustructure.Services.AudioSystem;
using _Project.Infrustructure.Services.SceneLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace _Project.UILogic.Hub
{
    public class HubNavigator : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button _nextSceneButton; 
        [SerializeField] private Button _previousSceneButton; 
        [SerializeField] private Button _playSoundButton;
        
        [Header("Scenes")]
        [SerializeField] private SceneName _nextSceneName;
        [SerializeField] private SceneName _previousSceneName;
        
        private ISceneLoaderService _sceneLoader;
        private IAudioService _audioService;
        private SceneSoundConfigSO _soundConfig;
        
        [Inject]
        private void Construct(ISceneLoaderService sceneLoader, SceneSoundConfigSO soundConfig,
            IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _soundConfig = soundConfig;
            _audioService = audioService;
        }

        private void Start() => 
            InitButtons();

        private void InitButtons()
        {
            _playSoundButton.onClick.AddListener(() => {
                var camraPosition = Camera.main.transform.position;
                _audioService.Build().WithPosition(camraPosition).WithParent(transform).Play(_soundConfig);
            });
            
            _nextSceneButton.onClick.AddListener( () => {
                _sceneLoader.Load(_nextSceneName);
            });
            
            _previousSceneButton.onClick.AddListener( () => {
                _sceneLoader.Load(_previousSceneName);
            });
        }

        private void OnDestroy()
        {
            _playSoundButton.onClick.RemoveAllListeners();
            _previousSceneButton.onClick.RemoveAllListeners();
            _nextSceneButton.onClick.RemoveAllListeners();
        }
    }
}