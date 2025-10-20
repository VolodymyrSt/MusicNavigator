using UnityEngine;

namespace _Project.Configs.Sound
{
    [CreateAssetMenu(fileName = "Scene Sound Config", menuName = "AudioService")]
    public class SceneSoundConfigSO : ScriptableObject
    {
        public AudioClip AudioClip;
        public float Volume;
    }
}