using Source.Core;
using Source.Managers.Score;
using UnityEngine;

namespace Source.Entities.DeleteArea
{
    public class DeleteArea : Entity
    {
        [SerializeField] private ScoreManager _scoreManager;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Asteroid")) 
                return;
            
            _scoreManager.Bonus();
            Destroy(other.gameObject);
        }
    }
}
