using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.SmoothTransformRotateComponent
{
    [CreateAssetMenu(fileName = "SmoothRotateConfig", menuName = "config/component/smoothrotate", order = 0)]
    public class SmoothTransformRotateConfig : EntityComponentConfig
    {
        [SerializeField] private float _rotateAngle;
        [SerializeField] private float _rotateTime;
        public float RotateAngle => _rotateAngle;
        public float RotateTime => _rotateTime;
    }
}