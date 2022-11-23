using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<GameObject> _windowPrefabs;
        [SerializeField] private Canvas _canvas;
        
        private List<Window> _windows = new List<Window>();
        
        private void Start()
        {
            foreach (var window in _canvas.GetComponentsInChildren<Window>())
                _windows.Add(window);
        }

        public T OpenWindow<T>() where T : MonoBehaviour
        {
            var windowPrefab = _windowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _canvas.transform);
            _windows.Add(window.GetComponent<Window>());

            return window.GetComponent<T>();
        }

        public T FindWindow<T>() where T : MonoBehaviour
        {
            return _windows.FirstOrDefault(x => typeof(T) == x.GetType()) as T;
        }

        public void CloseWindow<T>() where T : MonoBehaviour
        {
            var window = _windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            _windows.Remove(window);
            window.Close();
        }
    }
}
