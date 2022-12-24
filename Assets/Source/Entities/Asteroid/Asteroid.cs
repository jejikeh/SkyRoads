using DG.Tweening;
using Source.Core;
using Source.EntityComponents.ClampPosition;
using Source.EntityComponents.MoveForward;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Source.Entities.Asteroid
{
    public class Asteroid : Entity
    {
        [SerializeField] private MoveForwardComponentConfig _moveForwardConfig;
        [SerializeField] private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        [FormerlySerializedAs("ClampPositionComponentConfig")] [SerializeField] private ClampPositionComponentConfig _clampPositionComponentConfig;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        
        private void Start()
        {
            _boostSpeedMultiplierManager = FindObjectOfType<BoostSpeedMultiplierManager>();
            _moveForwardConfig.MovingSpeed = Random.Range(_moveForwardConfig.MovingSpeed / 2, _moveForwardConfig.MovingSpeed * 4);
            AddCustomComponent(new MoveForwardComponent(_moveForwardConfig, _boostSpeedMultiplierManager));
            
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig, _boostSpeedMultiplierManager))
                .RotateBeyond360(randomDirection);
            AddCustomComponent(new ClampPositionComponent(_clampPositionComponentConfig));
            
            transform.localScale = Vector3.zero;
            var randomScale = Random.Range(_minSize, _maxSize);
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