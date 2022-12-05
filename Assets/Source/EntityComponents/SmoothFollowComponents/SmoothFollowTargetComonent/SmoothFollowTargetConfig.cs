using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTargetComponent
{
    [CreateAssetMenu(fileName = "SmoothFollowTargetConfig", menuName = "config/component/smoothfollowtarget", order = 0)]
    public class SmoothFollowTargetConfig : EmptyComponentConfig
    {
        [Range(0f, 100f)] [SerializeField] private float _smoothTime;
        [SerializeField] private Vector3 _offset;

        public float SmoothTime => _smoothTime;
        public Vector3 Offset => _offset;
    }
}