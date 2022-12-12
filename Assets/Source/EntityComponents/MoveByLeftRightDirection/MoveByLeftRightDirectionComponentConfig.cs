using System;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MoveByLeftRightDirection
{
    [Serializable]
    public class MoveByLeftRightDirectionComponentConfig : ICustomComponentConfig
    {
        public float Speed;
        public Transform Handler;
    }
}