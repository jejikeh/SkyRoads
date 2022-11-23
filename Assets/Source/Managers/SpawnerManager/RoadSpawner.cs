using System.Collections.Generic;
using UnityEngine;

namespace Source.Spawners
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _roadPrefabs;
        [SerializeField] private float _roadLength = 81;
        public float RoadLength => _roadLength;

        private List<GameObject> _spawnedRoads = new List<GameObject>();
        
        public void Spawn(SpawnerManager spawnerManager)
        {
            _spawnedRoads.Add(Instantiate(_roadPrefabs, (transform.forward * spawnerManager.SpawnOffset) + transform.position, transform.rotation));
            spawnerManager.SpawnOffset += _roadLength;
        }

        public void DeSpawnLastRoad()
        {
            Destroy(_spawnedRoads[0]);
            _spawnedRoads.RemoveAt(0);
        }
    }
}
