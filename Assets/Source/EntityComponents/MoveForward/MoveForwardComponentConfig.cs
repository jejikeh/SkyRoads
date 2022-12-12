using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MoveForward
{
    [System.Serializable]
    public class MoveForwardComponentConfig : ICustomComponentConfig
    {
        public float MovingSpeed;
        public Vector3 MoveDirection;

        public Transform Handler;
    }
}