using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTargetComponent
{
    [CreateAssetMenu(fileName = "SmoothLookAtTargetConfig", menuName = "config/component/smoothlookattarget", order = 0)]
    public class SmoothLookAtTargetConfig : EmptyComponentConfig
    {
        public float SmoothTime => _smoothTime;
        [Range(0f, 100f)] [SerializeField] private float _smoothTime;
    }
}