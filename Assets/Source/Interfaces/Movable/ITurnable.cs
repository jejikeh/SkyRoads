using UnityEngine;

namespace Source.Interfaces.Movable
{
    public interface ITurnable
    {
        public float CurrentTurnSpeed { get; set; }
        public void Turn(Vector3 direction = new());
    }
}