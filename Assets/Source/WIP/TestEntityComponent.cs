using System.Runtime.ConstrainedExecution;
using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.WIP
{
    public class TestEntityComponent : EntityComponent<TestComponentConfig>
    {
        public TestEntityComponent(Entity entity) : base(entity)
        {
        }
        public override void Start()
        {
        }

        public override void Update()
        {
            Debug.Log(Config.Number);
        }

    }
}   