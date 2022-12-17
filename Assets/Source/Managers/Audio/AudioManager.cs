using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Source.Core;
using UnityEngine;

namespace Source.Managers.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        private float _globalVolume = 1f;
        [SerializeField] private List<AudioSource> _audioUISources = new List<AudioSource>();
        [SerializeField] private List<AudioSource> _audioGameSources = new List<AudioSource>();
        [SerializeField] private List<AudioSource> _audioMusicSources = new List<AudioSource>();
        [SerializeField] public List<AudioItem> AudioClips = new List<AudioItem>();

        private bool _isForceMute;
        public void TogleAudioVolume()
        {
            foreach (var audioSource in _audioGameSources)
            {
                var mute = audioSource.mute;
                mute = !mute;
                audioSource.mute = mute;
                _isForceMute = mute;
            }
            foreach (var audioSource in _audioMusicSources)
                audioSource.mute = !audioSource.mute;
            foreach (var audioSource in _audioUISources)
                audioSource.mute = !audioSource.mute;
        }

        public void SetMute(bool mute)
        {
            if (_isForceMute)
                return;
            
            foreach (var audioSource in _audioGameSources)
                audioSource.mute = mute;
            foreach (var audioSource in _audioMusicSources)
                audioSource.mute = mute;
            foreach (var audioSource in _audioUISources)
                audioSource.mute = mute;
        }

        public void Play(string audioName)
        {
            var audioItem = AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    PrepareAudioSourceThatDoesntPlaying(_audioGameSources, audioItem)?.Play();
                    break;
                case AudioType.Music:
                    PrepareAudioSourceThatDoesntPlaying(_audioMusicSources, audioItem)?.Play();
                    break;
                case AudioType.UI:
                    PrepareAudioSourceThatDoesntPlaying(_audioUISources, audioItem)?.Play();
                    break;
            }
        }

        [CanBeNull]
        private AudioSource PrepareAudioSourceThatDoesntPlaying(List<AudioSource> audioSources, AudioItem audioItem)
        {
            var audioSource = audioSources.FirstOrDefault(x => !x.isPlaying);
            if (audioSource is null)
                return null;
            
            audioSource.clip = audioItem.AudioClip;
            audioSource.loop = audioItem.Loop;
            audioSource.volume = audioItem.Volume * _globalVolume;
            audioSource.pitch = 1f;

            return audioSource;
        }

        [CanBeNull]
        private AudioSource FindAudioSource(List<AudioSource> audioSources, AudioItem audioItem)
        {
            var audioSource = audioSources.FirstOrDefault(x => x.clip == audioItem.AudioClip);
            return audioSource ? audioSource : null;
        }

        public void Stop(string audioName)
        {
            AudioSource findAudioSource = new AudioSource();
            var audioItem = AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    findAudioSource = FindAudioSource(_audioGameSources, audioItem);
                    break;
                case AudioType.Music:
                    findAudioSource = FindAudioSource(_audioMusicSources, audioItem);
                    break;
                case AudioType.UI:
                    findAudioSource = FindAudioSource(_audioUISources, audioItem);
                    break;
            }

            if (findAudioSource is not null)
                findAudioSource.Stop();
        }

        public void SetPitch(string audioName, float pitch)
        {
            AudioSource findAudioSource = new AudioSource();
            var audioItem = AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    findAudioSource = FindAudioSource(_audioGameSources, audioItem);
                    break;
                case AudioType.Music:
                    findAudioSource = FindAudioSource(_audioMusicSources, audioItem);
                    break;
                case AudioType.UI:
                    findAudioSource = FindAudioSource(_audioUISources, audioItem);
                    break;
            }
            
            if(findAudioSource is not null)
                findAudioSource.pitch = pitch;
        }
    }
}