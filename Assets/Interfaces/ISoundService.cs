using UnityEngine;

namespace Assets.Interfaces
{
    public interface ISoundService
    {
        void SetAudioSource(AudioSource audioSource);

        void PlaySound();
    }
}
