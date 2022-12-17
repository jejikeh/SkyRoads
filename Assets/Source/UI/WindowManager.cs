using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Source.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.UI
{
    public class WindowManager : Singleton<WindowManager>
    {
        [SerializeField] private List<GameObject> _windowPrefabs;
        private EventSystem _eventSystem;
        
        [SerializeField] private Canvas _canvas;
        private List<Window> _windows = new List<Window>();
        

        public async Task Open<T>([CanBeNull] object data) where T : Window
        {
            _eventSystem = FindObjectOfType<EventSystem>();
            if (_windows.Find(x => x.GetType() == typeof(T)) != null) return;
            var windowPrefab = _windowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _canvas.transform).GetComponent<T>();
            _windows.Add(window);
            
            _eventSystem.firstSelectedGameObject = window.GetFirstSelectedButton();
            
            await window.OnOpenStart(data);
        }

        public async Task Close<T>() where T : MonoBehaviour
        {
            var window = _windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            _windows.Remove(window);
            await window.OnCloseStart();
            Destroy(window.gameObject);
        }
        
        public async Task CloseAllWindows()
        {
            foreach (var window in _windows)
            {
                await window.OnCloseStart();
                Destroy(window.gameObject);
            }
            
            _windows.Clear();
        }
    }
}
