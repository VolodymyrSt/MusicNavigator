using _Project.Configs.Sound;
using UnityEngine;

namespace _Project.Infrustructure.Services.AudioSystem
{
    public class SoundBuilder
    {
        private readonly SoundEmitter _emitter;

        private Vector3 _position = default;
        private Transform _parent = null;
        
        public SoundBuilder(SoundEmitter emitter) => 
            _emitter = emitter;

        public SoundBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        } 
        
        public SoundBuilder WithParent(Transform parent)
        {
            _parent  = parent;
            return this;
        }

        public async void Play(SceneSoundConfigSO soundConfig)
        {
            _emitter.Init(soundConfig, _position, _parent);
            await _emitter.Emit();
        }
    }
}