using System;
using Source.Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Asteroid
{
    public class AsteroidRandomCreate : MonoBehaviour
    {
        [SerializeField] private UnitAsteroid _asteroid;

        private void Start()
        {
            var _astroidConfig = _asteroid.Config as UnitConfigAsteroid;
            
            if (_astroidConfig is null)
                throw new FieldAccessException($"{_astroidConfig.GetType()} expected UnitAsteroidConfig");

            var randomSize = Random.Range(_astroidConfig.MinSize, _astroidConfig.MaxSize);
            _asteroid.transform.GetChild(0).localScale = new Vector3(randomSize, randomSize, randomSize);

            var randomSpeed = Random.Range(_astroidConfig.MinSpeed, _astroidConfig.MaxSpeed);
            _asteroid.UnitForwardMovableBase.CurrentForwardSpeed = randomSpeed;

            var randomRotation = new Vector3(
                Random.Range(-_astroidConfig.RotateAngle, _astroidConfig.RotateAngle),
                Random.Range(-_astroidConfig.RotateAngle, _astroidConfig.RotateAngle),
                Random.Range(-_astroidConfig.RotateAngle, _astroidConfig.RotateAngle));
            var randomRotateTime = Random.Range(1f, _astroidConfig.RotateTime);
            _asteroid.AsteroidSmoothRotate.RandomRotateTime = randomRotateTime;
            _asteroid.AsteroidSmoothRotate.Rotate(randomRotation);
        }
    }
}
