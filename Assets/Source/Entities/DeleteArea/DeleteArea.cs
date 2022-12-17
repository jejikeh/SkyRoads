using Source.Core;
using Source.Managers;
using Source.Managers.Audio;
using Source.Managers.Score;
using UnityEngine;

namespace Source.Entities.DeleteArea
{
    public class DeleteArea : Entity
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Asteroid")) return;
            AudioManager.Instance.Play("asteroid");
            GameManager.GetCustomComponent<ScoreManager>().Bonus();
            var otherGameObject = other.gameObject;
            Destroy(otherGameObject);

        }
    }
}
