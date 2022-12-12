using DG.Tweening;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.CameraSpeedFovChanger
{
    [System.Serializable]
    public class CameraSpeedEffectsChangerComponentConfig : ICustomComponentConfig
    {
        [Header("FOV")]
        public float DefaultFov;
        public float FovBoost;
        public float FovStop;
        public Camera Camera;
        
        [Header("Shaker")]
        public float ShakeStrength;
        public float ShakeDuration;
        public int ShakeVibration;
        public ShakeRandomnessMode ShakeRandomnessMode;
        
        public Ease Ease;
    }
}