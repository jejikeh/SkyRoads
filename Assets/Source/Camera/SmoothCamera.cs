using System;
using UnityEngine;

namespace Source.Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [Header("Movement"), Space]
        [Range(0f,1f)]
        [SerializeField] private float _smoothTime;

        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _target;
        private void LateUpdate()
        {
            var desiredPosition = _target.position + _offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothTime);
            transform.position = smoothedPosition;
        }
    }
}