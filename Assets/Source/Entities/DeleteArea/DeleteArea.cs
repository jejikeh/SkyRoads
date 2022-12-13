using Source.Core;
using Source.Managers;
using UnityEngine;

namespace Source.Entities.DeleteArea
{
    public class DeleteArea : Entity
    {
        private void OnTriggerEnter(Collider other)
        {
            GameManager.ScoreManager.Bonus();
            var o = other.gameObject;
            Destroy(o);
        }
    }
}
