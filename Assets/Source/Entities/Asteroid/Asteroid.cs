using Source.Core;
using Source.EntityComponents.MoveComponent.MoveForwardComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.Asteroid
{
    public class Asteroid : Entity
    {
        [SerializeField] private MoveForwardConfig _moveForwardConfig;
        [SerializeField] private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        
        private void Awake()
        {
            AddCustomComponent(new MoveForward(_moveForwardConfig));
            AddCustomComponent(new SmoothTransformRotate(_smoothTransformRotateConfig));
        }

        private void Start()
        {
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            GetCustomComponent<SmoothTransformRotate>().RotateBeyond360(randomDirection);
        }

        private void Update()
        {
            UpdateComponents();
        }
    }
}