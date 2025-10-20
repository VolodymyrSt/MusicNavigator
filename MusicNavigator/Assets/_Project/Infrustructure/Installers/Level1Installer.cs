using _Project.Configs.Sound;
using UnityEngine;
using Zenject;

namespace _Project.Infrustructure.Installers
{
    public class Level1Installer : MonoInstaller
    {
        [SerializeField] private SceneSoundConfigSO _soundConfig;
        
        public override void InstallBindings() => 
            BindSoundConfig();

        private void BindSoundConfig()
        {
            Container
                .Bind<SceneSoundConfigSO>()
                .FromInstance(_soundConfig)
                .AsSingle();
        }
    }
}