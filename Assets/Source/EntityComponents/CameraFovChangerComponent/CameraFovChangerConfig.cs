using UnityEngine;

namespace Source.EntityComponents.CameraFovChangerComponent
{
    [CreateAssetMenu(fileName = "CameraFovChanger", menuName = "config/component/camerafovchanger", order = 0)]
    public class CameraFovChanger : ScriptableObject
    {
        public float DefaultFov => _defaultFov;
        [SerializeField] private float _defaultFov;
    }
}