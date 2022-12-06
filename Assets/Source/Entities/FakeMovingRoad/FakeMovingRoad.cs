using Source.Core;
using Source.EntityComponents.MaterialUVOffsetComponent;
using Source.EntityComponents.MoveComponent;
using UnityEngine;

namespace Source.Entities.FakeMovingRoad
{
    public class FakeMovingRoad : Entity
    {
        [SerializeField] private Material _roadMaterial;
        
        private void Awake()
        {
            var materialUVOffsetConfig = new MaterialUVOffsetConfig
            {
                Material = _roadMaterial,
                MainTexId = "_MainTex",
                SpecTexId = "_SpecTex",
                NormalTexId = "_NormalTex",
                EmissionTexId = "_EmissionTex"
            };
            
            AddCustomComponent(new MaterialUVOffset(materialUVOffsetConfig));
        }

        private void Update()
        {
            UpdateComponents(GlobalSpeedBoostMultiplier.BoostSpeedMultiplier);
        }
    }
}