using Source.Core;
using UnityEngine;

namespace Source.Entities.DeleteArea
{
    public class DeleteArea : Entity
    {
        private void OnTriggerEnter(Collider other)
        {
            var o = other.gameObject;
            Destroy(o);
        }
    }
}
