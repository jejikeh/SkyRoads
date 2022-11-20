using System;
using DG.Tweening;
using Source.Unit;
using UnityEngine;

namespace Source.Asteroid
{
    public class AsteroidSmoothRotate : UnitSmoothRotate
    {
        public float RandomRotateTime { get; set; }
        public override void Rotate(Vector3 direction)
        {
            Unit.transform.GetChild(0).DORotate(direction, RandomRotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
    }
}