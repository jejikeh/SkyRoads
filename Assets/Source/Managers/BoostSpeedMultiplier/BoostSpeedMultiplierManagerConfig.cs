using System;
using DG.Tweening;
using Source.Interfaces;

namespace Source.Managers.BoostSpeedMultiplier
{
    [Serializable]
    public class BoostSpeedMultiplierManagerConfig : ICustomComponentConfig
    {
        public Ease _boostEase;
        public float _duration;
        public float _defaultSpeedMultiplier;
        public float _boostSpeedMultiplier;
        public float _stopSpeedMultiplier;
    }
}