using System.Collections.Generic;
using Source.Core;
using Source.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.ObjectSpawner
{
    public class AsteroidSpawner : Entity
    {
        [SerializeField] private Vector2 _maxSize;
        [SerializeField] private Vector2 _minSize;
        private float _currentTime = 0f;
        private float _randomAsteroidRespawnTime = 0f;
        [SerializeField] private float _maxSpawnTimer;
        [SerializeField] private GameObject _asteroidPrefab;

        private void Spawn()
        {
            Instantiate(_asteroidPrefab, GetRandomVector3(), Quaternion.identity);
        }

        private void Start()
        {
            _randomAsteroidRespawnTime = 1;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _randomAsteroidRespawnTime)
            {
                Spawn();
                _currentTime = 0;
                _randomAsteroidRespawnTime = Random.Range(0, _maxSpawnTimer / GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier);
            }

        }
        
        private Vector3 GetRandomVector3()
        {
            return new Vector3(
                Random.Range(_minSize.x, _maxSize.x),
                Random.Range(_minSize.y, _maxSize.y),
                transform.position.z);
        }
    }
}