using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Source.UI
{
    public class WindowManager : MonoBehaviour
    {
        private static Stack<Tuple<Window, object>> _windowQueneStack = new Stack<Tuple<Window, object>>();
        [SerializeField] private List<GameObject> _windowPrefabs;
        
        private Canvas _canvas;
        private List<Window> _windows = new List<Window>();
        private static List<GameObject> _windowStaticPrefabs = new List<GameObject>();

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _windowStaticPrefabs = _windowPrefabs;
        }

        public async Task Open<T>([CanBeNull] object data) where T : Window
        {
            if (_windows.Find(x => x.GetType() == typeof(T)) != null) return;
            var windowPrefab = _windowPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _canvas.transform).GetComponent<T>();
            _windows.Add(window);
            
            await window.OnOpenStart(data);
        }

        private async void Start()
        {
            if (_windowQueneStack.Count == 0) return;

            while (_windowQueneStack.Count != 0)
            {
                var quenedWindow = _windowQueneStack.Pop();
                Instantiate(quenedWindow.Item1.gameObject, _canvas.transform);
                _windows.Add(quenedWindow.Item1);

                await quenedWindow.Item1.OnOpenStart(quenedWindow.Item2);
            }
        }

        public static void SaveToQuene<T>([CanBeNull] object data) where T : Window
        {
            var windowPrefab = _windowStaticPrefabs.Find(x => x.GetComponent<T>() != null).GetComponent<T>();
            _windowQueneStack.Push(new Tuple<Window, object>(windowPrefab, data));
        }
        
        public async Task Close<T>() where T : MonoBehaviour
        {
            var window = _windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            _windows.Remove(window);
            await window.OnCloseStart();
            // Destroy(window.gameObject);
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
