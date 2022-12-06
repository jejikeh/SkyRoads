using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComonent
{
    [System.Serializable]
    public class SmoothFollowTargetConfig : ICustomComponentConfig
    {
        public float SmoothTime;
        public Vector3 Offset;
        public Transform Target;
        public bool AffectBySpeed;
        public Transform Handler;

        public SmoothFollowTargetConfig(float smoothTime, Vector3 offset, Transform target, bool affectBySpeed, Transform handler)
        {
            SmoothTime = smoothTime;
            Offset = offset;
            Target = target;
            AffectBySpeed = affectBySpeed;
            Handler = handler;
        }
    }
}