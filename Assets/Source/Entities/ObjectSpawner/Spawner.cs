using System.Collections.Generic;
using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.ObjectSpawner
{
    public class Spawner : Entity
    {
        [SerializeField] private Vector2 _maxSize;
        [SerializeField] private Vector2 _minSize;
        [SerializeField] private float _maxSpawnTimer;
        [SerializeField] private List<GameObject> _objectPrefab;
        private float _randomObjectRespawnTime;
        private float _currentTime;

        private void Spawn()
        {
            var spawnGameObject = _objectPrefab[Random.Range(0, _objectPrefab.Count)];
            Instantiate(spawnGameObject, GetRandomVector3(), Quaternion.identity);
        }

        private void Start()
        {
            _randomObjectRespawnTime = 1;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _randomObjectRespawnTime)
            {
                Spawn();
                _currentTime = 0;
                _randomObjectRespawnTime = Random.Range(0, _maxSpawnTimer / GameManager.GetCustomComponent<BoostSpeedMultiplierManager>().BoostSpeedMultiplier);
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