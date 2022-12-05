using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.CameraFovChangerComponent
{
    [CreateAssetMenu(fileName = "CameraFovChanger", menuName = "config/component/camerafovchanger", order = 0)]
    public class CameraFovChangerConfig : EmptyComponentConfig
    {
        public float DefaultFov => _defaultFov;
        public float AffectByFovBoost => _affectByFovBoost;
        public float AffectByFovStop => _affectByFovStop;
        [SerializeField] private float _defaultFov;
        [SerializeField] private float _affectByFovBoost;
        [SerializeField] private float _affectByFovStop;
    }
}