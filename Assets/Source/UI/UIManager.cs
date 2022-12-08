using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

namespace Source.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<GameObject> _windowPrefabs;

        private static Canvas _staticCanvas;
        private static List<Window> _windows = new List<Window>();
        private static List<GameObject> _staticWindowPrefabs = new List<GameObject>();
        private void Start()
        {
            var tempObject = GameObject.Find("Canvas");
            if(tempObject != null){
                //If we found the object , get the Canvas component from it.
                _staticCanvas = tempObject.GetComponent<Canvas>();
                if(_staticCanvas == null){
                    Debug.Log("Could not locate Canvas component on " + tempObject.name);
                }
            }
            _staticWindowPrefabs = _windowPrefabs;
            foreach (var window in _staticCanvas.GetComponentsInChildren<Window>())
                _windows.Add(window);
        }

        public static async Task<T> OpenWindow<T>() where T : MonoBehaviour
        {
            var windowPrefab = _staticWindowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _staticCanvas.transform);
            var windowComponent = window.GetComponent<Window>();
            _windows.Add(windowComponent);
            await windowComponent.OpenStartAsync();
            await windowComponent.OpenCompleteAsync();
            return window.GetComponent<T>();
        }
        
        public static async Task<T> OpenWindow<T>(object data) where T : MonoBehaviour
        {
            var windowPrefab = _staticWindowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _staticCanvas.transform);
            var windowComponent = window.GetComponent<Window>();
            _windows.Add(windowComponent);
            await windowComponent.OpenStartAsync(data);
            await windowComponent.OpenCompleteAsync();
            return window.GetComponent<T>();
        }

        public T FindWindow<T>() where T : MonoBehaviour
        {
            return _windows.FirstOrDefault(x => typeof(T) == x.GetType()) as T;
        }

        public async Task CloseWindow<T>() where T : MonoBehaviour
        {
            var window = _windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            _windows.Remove(window);
            await window.CloseStartAsync();
            await window.CloseCompleteAsync();
            Destroy(window.gameObject);
        }
        
        public static async Task CloseAllWindows()
        {
            foreach (var window in _windows)
            {
                if(window is null)
                    return;

                await window.CloseStartAsync();
                await window.CloseCompleteAsync();
                Destroy(window.gameObject);
            }
        }
    }
}
