using System;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.BoxColliderSizeChanger
{
    [Serializable]
    public class BoxColliderSizeChangerComponentConfig : ICustomComponentConfig
    {
        public BoxCollider Collider;
        public Vector3 DefaultSize;
        public Vector3 MaxSize;
        public Vector3 MinSize;
    }
}