using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveForwardComponent
{
    [System.Serializable]
    public class MoveForwardConfig : ICustomComponentConfig
    {
        public float MovingSpeed;
        public Vector3 MoveDirection;

        public Transform Handler;
    }
}