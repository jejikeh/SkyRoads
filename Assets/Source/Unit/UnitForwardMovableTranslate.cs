using System;
using Source.Interfaces;
using Source.Interfaces.Movable;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public class UnitForwardMovableTranslate : UnitForwardMovableBase
    {
        public override void Move(Vector3 direction = new())
        {
            _unit.transform.Translate(_unitMovableConfig.UnitMoveDirection * (CurrentForwardSpeed * Time.deltaTime));
        }
    }
}