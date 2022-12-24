using System;
using Source.Core;
using Source.EntityComponents.SmoothFollowTarget;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.Entities.Ship
{
    public class FuelIndicator : Entity
    {
        [SerializeField] private SmoothFollowTargetComponentConfig _followTargetComponentConfig;
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetComponentConfig,
                _boostSpeedMultiplierManager));
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}