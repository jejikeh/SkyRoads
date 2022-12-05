using UnityEngine;

namespace Source
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T Instance { get; set; }

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = GetComponent<T>();
            DontDestroyOnLoad(Instance);
        }
    }
}
