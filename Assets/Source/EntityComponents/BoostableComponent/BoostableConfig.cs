using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.BoostableComponent
{
    [CreateAssetMenu(fileName = "BoostableConfig", menuName = "config/component/boostable", order = 0)]
    public class BoostableConfig : EntityComponentConfig
    {
        public float BoostMultiplier => _boostMultiplier;
        public float StopMultiplier => _stopMultiplier;
        public float Duration => _duration;
        
        [SerializeField] private float _boostMultiplier ;
        [SerializeField] private float _stopMultiplier;
        [SerializeField] private float _duration;

    }
}