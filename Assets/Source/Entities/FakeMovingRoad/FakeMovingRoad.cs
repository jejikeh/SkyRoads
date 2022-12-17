using Source.Core;
using Source.EntityComponents.MaterialUVOffset;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.Entities.FakeMovingRoad
{
    public class FakeMovingRoad : Entity
    {
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private Material _roadMaterial;
        
        private void Start()
        {
            var materialUVOffsetConfig = new MaterialUVOffsetEntityComponentConfig
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
            UpdateComponents(_boostSpeedMultiplierManager.MoveMultiplier);
        }
    }
}