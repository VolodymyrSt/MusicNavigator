using System.Threading.Tasks;
using _Project.Configs.Sound;
using UnityEngine;

namespace _Project.Infrustructure.Services.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void Init(SceneSoundConfigSO soundConfig, Vector3 position, Transform parent)
        {
            _audioSource.clip = soundConfig.AudioClip;
            _audioSource.volume = soundConfig.Volume;
            
            transform.position = position;
            transform.SetParent(parent);
        }
        
        public async Task Emit()
        {
            _audioSource.Play();

            var duration = Mathf.CeilToInt(_audioSource.clip.length * 1000) + 100;
            await Task.Delay(duration);
            Destroy(gameObject);
        }

        private void OnValidate() => 
            _audioSource ??= GetComponent<AudioSource>();
    }
}