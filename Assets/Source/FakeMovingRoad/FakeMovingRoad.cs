using System;
using Source.Core;
using Source.EntityComponents.MaterialUVOffsetComponent;
using Source.EntityComponents.MoveComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.FakeMovingRoad
{
    public class FakeMovingRoad : Entity
    {
        [SerializeField] private Material _roadMaterial;
        private ICustomComponent _materialUVOffset;
        
        private void Awake()
        {
            _materialUVOffset = AddCustomComponent(new MaterialUVOffset(this, _roadMaterial));
        }

        private void Update()
        {
            UpdateSpecificComponents(MoveComponentsBoostMultiplier.BoostSpeedMultiplier, _materialUVOffset);
        }
    }
}