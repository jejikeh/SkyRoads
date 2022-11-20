using System;
using Source.Interfaces.Movable;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public class UnitTurnableTranslate : UnitTurnableBase
    {
        public override void Turn(Vector3 direction = new())
        {
            _unit.transform.Translate(direction * (CurrentTurnSpeed * Time.deltaTime));
        }
    }
}