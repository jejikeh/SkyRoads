using DG.Tweening;
using UnityEngine;

namespace Source.Unit
{
    public class UnitTransformMovable : UnitMovable
    {
        [SerializeField] private Unit _unit;
        
        public override void Move(Vector3 direction)
        {
            _unit.transform.Translate(((_unit.Config.MoveDirection * UnitSpeed.CurrentForwardSpeed) + (direction * UnitSpeed.CurrentTurnSpeed)) * Time.deltaTime);
        }
    }
}