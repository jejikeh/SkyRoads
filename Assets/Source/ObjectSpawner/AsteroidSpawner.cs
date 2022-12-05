using System;
using Source.Core;
using UnityEngine;

namespace Source.ObjectSpawner
{
    public class Spawner : Entity
    {
        [SerializeField] 
        
        private void Awake()
        {
            AddCustomComponent();
        }
    }
}