using System;
using System.Collections.Generic;
using Source.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.ObjectSpawner
{
    public class AsteroidSpawner : Entity
    {
        [SerializeField] private GameObject _asteroidPrefab;

        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

        private void Spawn()
        {
            Instantiate(_asteroidPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
        }
    }
}