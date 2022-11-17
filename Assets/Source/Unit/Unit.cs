using Source.Unit.Config;
using UnityEngine;

namespace Source.Unit
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitConfig _unitConfig;
        public UnitConfig Config => _unitConfig;
    }
}