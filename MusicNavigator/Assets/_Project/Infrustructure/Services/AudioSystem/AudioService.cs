using System;
using _Project.Configs.Sound;

namespace _Project.Infrustructure.Services.AudioSystem
{
    public class AudioService : IAudioService
    {
        private readonly SoundEmitterFactory _soundEmitterFactory;
        
        public AudioService() => 
            _soundEmitterFactory  = new SoundEmitterFactory();
        
        public SoundBuilder Build() =>
            new SoundBuilder(_soundEmitterFactory.Create());
    }
}