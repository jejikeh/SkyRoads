using System.Collections.Generic;
using Source.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.ObjectSpawner
{
    public class AsteroidSpawner : Entity
    {
        private float _currentTime = 0f;
        private float _randomAsteroidRespawnTime = 0f;
        [SerializeField] private float _maxSpawnTimer;
        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

        private void Spawn()
        {
            Instantiate(_asteroidPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
        }

        private void Start()
        {
            Spawn();
        }
    }
}