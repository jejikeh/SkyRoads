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
        
        private float _currentAngle;
        public override void Rotate(Vector3 direction)
        {
            transform.DOLocalRotate(new Vector3((-direction.y * _unit.Config.RotateAngle) / 2,0,0), _unit.Config.RotateTime);
            transform.GetChild(0).DOLocalRotate(new Vector3(0,0,-direction.x * _unit.Config.RotateAngle), _unit.Config.RotateTime);
        }
    }
}  