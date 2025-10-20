using _Project.Infrustructure.Services.AudioSystem;
using _Project.Infrustructure.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace _Project.Infrustructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindAudioService();
        }

        private void BindSceneLoader() => 
            Container
                .Bind<ISceneLoaderService>()
                .To<SceneLoaderService>()
                .AsSingle();
        
        private void BindAudioService() => 
            Container
                .Bind<IAudioService>()
                .To<AudioService>()
                .AsSingle();
    }
}
