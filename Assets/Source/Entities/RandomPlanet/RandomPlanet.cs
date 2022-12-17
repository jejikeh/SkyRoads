using System;
using DG.Tweening;
using Source.Core;
using Source.EntityComponents;
using Source.EntityComponents.RandomPlanetMaterial;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Entities.RandomPlanet
{
    public class RandomPlanet : Entity
    {
        [SerializeField] private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        [SerializeField] private RandomPlanetMaterialComponentConfig _randomPlanetMaterialComponentConfig;
        
        [SerializeField] private float _randomMaxSize;
        [SerializeField] private float _randomMinSize;
        private void Start()
        {
            var randomDirection = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            transform.localRotation = Quaternion.Euler(randomDirection * 100);
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig, GameManager.GetCustomComponent<BoostSpeedMultiplierManager>())).RotateBeyond360(randomDirection);
            AddCustomComponent(new RandomPlanetMaterialComponent(_randomPlanetMaterialComponentConfig));

            var randomScale = Random.Range(_randomMinSize, _randomMaxSize);
            transform.localScale = Vector3.one * randomScale;
        }

        private void Update()
        {
            UpdateComponents();
        }
    }
}
