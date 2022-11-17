using UnityEngine;

namespace Source.Unit
{
    [RequireComponent(typeof(UnitSpeed))]
    public abstract class UnitMovable : MonoBehaviour
    {
        [SerializeField] public UnitSpeed UnitSpeed;
        public abstract void Move(Vector3 direction);
    }
}