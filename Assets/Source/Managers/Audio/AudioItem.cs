using System;
using UnityEngine;

namespace Source.Managers.Audio
{
    [Serializable]
    public class AudioItem
    {
        public AudioType AudioType;
        public AudioClip AudioClip;
        public bool Loop;
        public float Volume = 1f;
    }
}