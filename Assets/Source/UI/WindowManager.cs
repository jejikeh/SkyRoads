using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Source.UI
{
    public class WindowManager : Singleton<WindowManager>
    {
        [SerializeField] private List<GameObject> _windowPrefabs;

        private static Canvas _canvas;
        private static List<Window> _windows = new List<Window>();

        private static List<GameObject> _windowsStaticPrefabs;
        
        protected override void Awake()
        {
            base.Awake();
            
            _canvas ??= GetComponent<Canvas>();
            _windowsStaticPrefabs ??= _windowPrefabs;
        }

        public static T Open<T>([CanBeNull] object data) where T : Window
        {
            if (_windows.Find(x => x.GetType() == typeof(T)) != null) return null;
            var windowPrefab = _windowsStaticPrefabs.Find(x => x.GetComponent<T>() != null);
            var window = Instantiate(windowPrefab, _canvas.transform).GetComponent<T>();
            _windows.Add(window);
            
            window.OnOpenStart(data);

            // Task.WaitAll();
            return window;
        }
        
        public static void Close<T>() where T : MonoBehaviour
        {
            var window = _windows.Find(x => x.GetComponent<T>() != null);
            if (window is null)
                return;
            
            _windows.Remove(window);
            window.OnCloseStart();
            Destroy(window.gameObject);
        }
        
        public static void CloseAllWindows()
        {
            foreach (var window in _windows)
            {
                window.OnCloseStart();
                Destroy(window.gameObject);
            }
            
            _windows.Clear();
        }
    }
}
