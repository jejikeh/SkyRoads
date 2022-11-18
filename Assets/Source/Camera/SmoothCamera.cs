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
        
        private Vector3 _velocity = Vector3.zero;
        private void Update()
        {
            var desiredPosition = _target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _smoothTime);
        }
    }
}