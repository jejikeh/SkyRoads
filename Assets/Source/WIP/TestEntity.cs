using System;
using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.WIP
{
    public class TestEntity : Entity
    {
        [SerializeField] private PlayerInputUser _playerInputUser;

        private void Awake()
        {
            AddCustomComponent(new TestEntityComponent(this));
        }
        
        private void Start()
        {
            StartComponents();
            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => ApplyBoostMode();
        }

        private void Update()
        {
            UpdateComponents();
        }

        private void ApplyBoostMode()
        {
            RemoveCustomComponent<TestEntityComponent>();
            AddCustomComponent(new TestEntityComponent2(this));
        }
    }
}