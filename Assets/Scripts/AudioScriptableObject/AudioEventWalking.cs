using UnityEngine;

namespace DefaultNamespace.AudioScriptableObject
{
    [CreateAssetMenu(fileName = "AudioEventWalking", menuName = "Player/WalkingAudioEvent", order = 0)]
    
    
    
    public class AudioEventWalking : AudioEventBase
    {
        //picks a random sound from the audio sources chosen in unity
        //!!! MUST ADD THE ASSET IN UNITY AND INCREASE THE AUDIO SIZE THEN SELECT THE AUDIO FILES
        public override void Play(AudioSource _audioSource)
        {
            if (randomSound.Length < 0) return;
            {

                _audioSource.clip = randomSound[Random.Range(0, randomSound.Length)];
                _audioSource.Play();

            }
        }
    }
}