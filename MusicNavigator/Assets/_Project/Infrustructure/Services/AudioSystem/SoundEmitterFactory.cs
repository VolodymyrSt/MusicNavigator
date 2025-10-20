using _Project.Factory;
using UnityEngine;

namespace _Project.Infrustructure.Services.AudioSystem
{
    public class SoundEmitterFactory : BaseFactory<SoundEmitter>
    {
        private const string SOUND_EMITTER_PATH = "SoundEmitter";
        
        public override SoundEmitter Create()
        {
            var emitter = Resources.Load<SoundEmitter>(SOUND_EMITTER_PATH);
            return Object.Instantiate(emitter);
        }
    }
}