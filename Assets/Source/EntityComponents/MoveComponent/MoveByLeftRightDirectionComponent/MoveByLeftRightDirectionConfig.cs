using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent
{
    [System.Serializable]
    public class MoveByLeftRightDirectionConfig : ICustomComponentConfig
    {
        public float Speed;
        public Transform Handler;
    }
}