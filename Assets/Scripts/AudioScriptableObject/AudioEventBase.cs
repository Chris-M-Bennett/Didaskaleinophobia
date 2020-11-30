using UnityEngine;

namespace DefaultNamespace.AudioScriptableObject
{
    [CreateAssetMenu(fileName = "AudioEventBase", menuName = "Player/AudioEventBase", order = 0)]
    public abstract class AudioEventBase : ScriptableObject
    {
        public AudioClip[] randomSound;
        public abstract void Play(AudioSource _audioSource);
    }
}