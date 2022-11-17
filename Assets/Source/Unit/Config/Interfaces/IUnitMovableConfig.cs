using UnityEngine;

namespace Source.Unit.Config.Interfaces
{
    public interface IUnitMovableConfig
    {
        public float UnitForwardSpeed { get; }
        public Vector3 UnitMoveDirection { get; }
    }
}