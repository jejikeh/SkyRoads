using UnityEngine;

namespace Source.Interfaces.Movable
{
    public interface IForwardMovable
    {
        public float CurrentForwardSpeed { get; set; }
        public void Move(Vector3 direction = new());
    }
}