using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Source.Core;
using UnityEngine;

namespace Source.Managers.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private List<AudioSource> _audioUISources = new List<AudioSource>();
        [SerializeField] private List<AudioSource> _audioGameSources = new List<AudioSource>();
        [SerializeField] private List<AudioSource> _audioMusicSources = new List<AudioSource>();
        [SerializeField] public List<AudioItem> AudioClips = new List<AudioItem>();

        private readonly float _globalVolume = 1f;
        
        public static void ToggleAudioVolume()
        {
            foreach (var audioSource in Instance._audioGameSources)
            {
                var mute = audioSource.mute;
                mute = !mute;
                audioSource.mute = mute;
            }
            foreach (var audioSource in Instance._audioMusicSources)
                audioSource.mute = !audioSource.mute;
            foreach (var audioSource in Instance._audioUISources)
                audioSource.mute = !audioSource.mute;
        }
        
        public static void Play(string audioName)
        {
            var audioItem = Instance.AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    PrepareAudioSourceThatDoesntPlaying(Instance._audioGameSources, audioItem)?.Play();
                    break;
                case AudioType.Music:
                    PrepareAudioSourceThatDoesntPlaying(Instance._audioMusicSources, audioItem)?.Play();
                    break;
                case AudioType.UI:
                    PrepareAudioSourceThatDoesntPlaying(Instance._audioUISources, audioItem)?.Play();
                    break;
            }
        }

        [CanBeNull]
        private static AudioSource PrepareAudioSourceThatDoesntPlaying(List<AudioSource> audioSources, AudioItem audioItem)
        {
            var audioSource = audioSources.FirstOrDefault(x => !x.isPlaying);
            if (audioSource is null)
                return null;
            
            audioSource.clip = audioItem.AudioClip;
            audioSource.loop = audioItem.Loop;
            audioSource.volume = audioItem.Volume * Instance._globalVolume;
            audioSource.pitch = 1f;

            return audioSource;
        }

        [CanBeNull]
        private static AudioSource FindAudioSource(List<AudioSource> audioSources, AudioItem audioItem)
        {
            var audioSource = audioSources.FirstOrDefault(x => x.clip == audioItem.AudioClip);
            return audioSource ? audioSource : null;
        }

        public static void Stop(string audioName)
        {
            var findAudioSource = new AudioSource();
            var audioItem = Instance.AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    findAudioSource = FindAudioSource(Instance._audioGameSources, audioItem);
                    break;
                case AudioType.Music:
                    findAudioSource = FindAudioSource(Instance._audioMusicSources, audioItem);
                    break;
                case AudioType.UI:
                    findAudioSource = FindAudioSource(Instance._audioUISources, audioItem);
                    break;
            }

            if (findAudioSource is not null)
                findAudioSource.Stop();
        }

        public static void SetPitch(string audioName, float pitch)
        {
            var findAudioSource = new AudioSource();
            var audioItem = Instance.AudioClips.Find(x => x.AudioClip.name == audioName);
            switch (audioItem.AudioType)
            {
                case AudioType.Game:
                    findAudioSource = FindAudioSource(Instance._audioGameSources, audioItem);
                    break;
                case AudioType.Music:
                    findAudioSource = FindAudioSource(Instance._audioMusicSources, audioItem);
                    break;
                case AudioType.UI:
                    findAudioSource = FindAudioSource(Instance._audioUISources, audioItem);
                    break;
            }
            
            if(findAudioSource is not null)
                findAudioSource.pitch = pitch;
        }
    }
}