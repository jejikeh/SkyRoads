using System;
using Source.Unit;
using UnityEngine;

namespace Source.Asteroid
{
    public class UnitAsteroid : Unit.Unit
    {
        [SerializeField] private UnitForwardMovableBase _unitForwardMovable;
        [SerializeField] private AsteroidSmoothRotate _asteroidSmoothRotate;
        public UnitForwardMovableBase UnitForwardMovableBase => _unitForwardMovable;
        public AsteroidSmoothRotate AsteroidSmoothRotate => _asteroidSmoothRotate;
        
        private void Update()
        {
            _unitForwardMovable.Move();
        }
    }
}
