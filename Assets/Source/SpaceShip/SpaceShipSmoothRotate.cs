using DG.Tweening;
using UnityEngine;

namespace Source.Unit
{
    public class SpaceShipSmoothRotate : UnitSmoothRotate
    {
        public override void Rotate(Vector3 direction)
        {
            Unit.transform.DOLocalRotate(new Vector3((-direction.y * RotateableConfig.RotateAngle) / 2,0,0), RotateableConfig.RotateTime);
            Unit.transform.GetChild(0).DOLocalRotate(new Vector3(0,0,-direction.x * RotateableConfig.RotateAngle), RotateableConfig.RotateTime);
        }
    }
}