using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.ClampPosition
{
    [System.Serializable]
    public class ClampPositionComponentConfig : ICustomComponentConfig
    {
        public float LimitMinXPosition;
        public float LimitMaxXPosition;
        public float LimitMinYPosition;
        public float LimitMaxYPosition;
        public Transform Handler;
    }
}