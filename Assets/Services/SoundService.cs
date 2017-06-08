using System;
using Assets.Interfaces;
using UnityEngine;

namespace Assets.Services
{
    public class SoundService : ISoundService
    {
        private AudioSource _audioSource;

        public void SetAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void PlaySound()
        {
            if (_audioSource == null)
            {
                throw new Exception("Audio source not set.");
            }

            _audioSource.Play();
        }
    }
}
