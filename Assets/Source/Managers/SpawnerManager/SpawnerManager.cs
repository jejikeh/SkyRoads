using System.Collections;
using System.Collections.Generic;
using Source.Spawners;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerManager : MonoBehaviour
{
    public int RoadsOnStart => _roadsOnStart;
    public float SpawnOffset { get; set; }
    
    [SerializeField] private int _roadsOnStart;
    [SerializeField] private float _maxSpawnTimer;
    
    [Header("Components"), Space]
    [SerializeField] private RoadSpawner _roadSpawner;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private Transform _player;
    
    private float _currentTime = 0f;
    private float _randomAsteroidRespawnTime = 0f;
    void Start()
    {
        _randomAsteroidRespawnTime = _maxSpawnTimer;
        
        for(var i = 0; i < _roadsOnStart; i++)
            _roadSpawner.Spawn(this);
    }

    void Update()
    {
        // Spawn asteroid after n seconds
        _currentTime += Time.deltaTime;
        if (_currentTime > _randomAsteroidRespawnTime)
        {
            _asteroidSpawner.Spawn(this);
            _currentTime = 0;
            _randomAsteroidRespawnTime = Random.Range(0, _maxSpawnTimer);
        }
        
        // if player close enough then spawn new road prefab
        if (!(_player.position.z - _roadSpawner.RoadLength >
              SpawnOffset - (_roadSpawner.RoadLength * _roadsOnStart))) return;

        _roadSpawner.Spawn(this);
        _roadSpawner.DeSpawnLastRoad();
    }
}
