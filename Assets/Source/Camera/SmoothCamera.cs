using System;
using Source.Core;
using Source.EntityComponents.CameraFovChangerComponent;
using Source.EntityComponents.MoveComponent;
using Source.EntityComponents.SmoothFollowTargetComponent;
using UnityEngine;

namespace Source.Camera
{
    public class SmoothCamera : Entity
    {
        [Header("SmoothFollowTarget"), Space]
        [SerializeField] private Transform _target;

        private void Awake()
        {
            AddCustomComponent(new SmoothFollowTarget(this, _target));
            AddCustomComponent(new CameraSpeedFovChanger(this, GetComponent<UnityEngine.Camera>()));
        }

        private void Start()
        {
            StartComponents();
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}