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
        [SerializeField] private Canvas _canvas;
        
        private List<Window> _windows = new List<Window>();
        private EventSystem _eventSystem;
        
        public static async Task Open<T>([CanBeNull] object data) where T : Window
        {
            Instance._eventSystem = FindObjectOfType<EventSystem>();
            if (Instance._windows.Find(x => x.GetType() == typeof(T)) != null) return;
            var windowPrefab = Instance._windowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, Instance._canvas.transform).GetComponent<T>();
            Instance._windows.Add(window);
            Instance._eventSystem.firstSelectedGameObject = window.GetFirstSelectedButton();
            
            await window.OnOpenStart(data);
        }

        public static async Task Close<T>() where T : MonoBehaviour
        {
            var window = Instance._windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            Instance._windows.Remove(window);
            await window.OnCloseStart();
            Destroy(window.gameObject);
        }
    }
}
