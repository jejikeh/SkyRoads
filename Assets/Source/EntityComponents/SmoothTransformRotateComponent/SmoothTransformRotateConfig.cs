using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothTransformRotateComponent
{
    [System.Serializable]
    public class SmoothTransformRotateConfig : ICustomComponentConfig
    {
        public float RotateAngle;
        public float RotateTime;
        public Transform RotatedTransform;
    }
}