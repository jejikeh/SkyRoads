using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowComponents.SmoothLookAtTargetComponent
{
    [System.Serializable]
    public class SmoothLookAtTargetConfig : ICustomComponentConfig
    {
        [Range(0f, 100f)] public float SmoothTime;
        public Transform Target;
        public Transform Handler;
    }
}