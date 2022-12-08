using Source.Core;
using Source.EntityComponents;
using Source.Managers;
using UnityEngine;

namespace Source.Entities.FakeMovingRoad
{
    public class FakeMovingRoad : Entity
    {
        [SerializeField] private Material _roadMaterial;
        
        private void Awake()
        {
            var materialUVOffsetConfig = new MaterialUVOffsetComponent.MaterialUVOffsetEntityComponentConfig
            {
                Material = _roadMaterial,
                MainTexId = "_MainTex",
                SpecTexId = "_SpecTex",
                NormalTexId = "_NormalTex",
                EmissionTexId = "_EmissionTex"
            };
            
            AddCustomComponent(new MaterialUVOffsetComponent(materialUVOffsetConfig));
        }

        private void Update()
        {
            UpdateComponents(GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier);
        }
    }
}