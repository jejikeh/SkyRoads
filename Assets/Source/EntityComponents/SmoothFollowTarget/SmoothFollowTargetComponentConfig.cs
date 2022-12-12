using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTarget
{
    [System.Serializable]
    public class SmoothFollowTargetComponentConfig : ICustomComponentConfig
    {
        public float SmoothTime;
        public Vector3 Offset;
        public Transform Target;
        public bool AffectBySpeed;
        public Transform Handler;

        public SmoothFollowTargetComponentConfig(float smoothTime, Vector3 offset, Transform target, bool affectBySpeed, Transform handler)
        {
            SmoothTime = smoothTime;
            Offset = offset;
            Target = target;
            AffectBySpeed = affectBySpeed;
            Handler = handler;
        }
    }
}