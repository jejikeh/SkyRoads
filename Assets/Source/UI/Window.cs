using UnityEngine;

namespace Source.UI
{
    public class Window : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}