using DG.Tweening;
using Source.Core;
using Source.EntityComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.Asteroid
{
    public class Asteroid : Entity
    {
        [SerializeField] private MoveForwardComponent.MoveForwardConfig _moveForwardConfig;
        [SerializeField] private SmoothTransformRotateComponent.SmoothTransformRotateConfig _smoothTransformRotateConfig;
        [SerializeField] private ClampPositionComponent.ClampPositionConfig _clampPositionConfig;

        private void Awake()
        {
            _moveForwardConfig.MovingSpeed = Random.Range(_moveForwardConfig.MovingSpeed / 2, _moveForwardConfig.MovingSpeed * 2);
            AddCustomComponent(new MoveForwardComponent(_moveForwardConfig));
            
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig)).RotateBeyond360(randomDirection);
            
            AddCustomComponent(new ClampPositionComponent(_clampPositionConfig));
        }

        private void Start()
        {
            transform.localScale = Vector3.zero;
            var randomScale = Random.Range(0.5f, 1f);
            transform.DOScale(new Vector3(randomScale, randomScale, randomScale), 1f);
        }

        private void Update()
        {
            UpdateComponents();
        }
    }
}