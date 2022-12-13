using UnityEngine;

namespace Source
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; set; }

        protected virtual void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = GetComponent<T>();
            DontDestroyOnLoad(Instance);
        }
    }
}
