using System;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.CameraFovChangerComponent
{
    [Serializable]
    public class CameraFovChangerConfig : ICustomComponentConfig
    {
        public float DefaultFov;
        public float AffectByFovBoost;
        public float AffectByFovStop;
        public UnityEngine.Camera Camera;
        
        public CameraFovChangerConfig(float affectByFovStop, float affectByFovBoost, float defaultFov, UnityEngine.Camera camera)
        {
            AffectByFovStop = affectByFovStop;
            AffectByFovBoost = affectByFovBoost;
            DefaultFov = defaultFov;
            Camera = camera;
        }
    }
}