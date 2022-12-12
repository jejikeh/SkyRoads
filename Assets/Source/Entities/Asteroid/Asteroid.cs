using DG.Tweening;
using Source.Core;
using Source.EntityComponents;
using Source.EntityComponents.ClampPosition;
using Source.EntityComponents.MoveForward;
using Source.EntityComponents.SmoothTransformRotate;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.Asteroid
{
    public class Asteroid : Entity
    {
        [SerializeField] private MoveForwardComponentConfig _moveForwardConfig;
        [SerializeField] private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        [SerializeField] private ClampPositionComponentConfig ClampPositionComponentConfig;
        
        private void Start()
        {
            _moveForwardConfig.MovingSpeed = Random.Range(_moveForwardConfig.MovingSpeed / 2, _moveForwardConfig.MovingSpeed * 4);
            AddCustomComponent(new MoveForwardComponent(_moveForwardConfig));
            
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig)).RotateBeyond360(randomDirection);
            AddCustomComponent(new ClampPositionComponent(ClampPositionComponentConfig));
            
            transform.localScale = Vector3.zero;
            var randomScale = Random.Range(0.5f, 1f);
            transform.DOScale(Vector3.one * randomScale,1f);
        }

        protected override void OnDestroy()
        {
            transform.DOKill();
            base.OnDestroy();
        }

        private void Update()
        {
            UpdateComponents();
        }
    }
}