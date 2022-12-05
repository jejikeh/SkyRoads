using System;
using Source.Core;
using Source.EntityComponents.MoveComponent.MoveForwardComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Asteroid
{
    public class Asteroid : Entity
    {
        private void Awake()
        {
            AddCustomComponent(new MoveForward(this));
            AddCustomComponent(new SmoothTransformRotate(this, transform.GetChild(0)));
        }

        private void Start()
        {
            StartComponents();
            
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            GetCustomComponent<SmoothTransformRotate>().RotateBeyond360(randomDirection);
        }

        private void Update()
        {
            UpdateComponents();
        }
    }
}