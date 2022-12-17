using Source.Interfaces;
using UnityEngine;

namespace Source.Core
{
    public class Entity : MonoBehaviour
    {
        private static float _entityTimeScale = 1f;
        public float GlobalEntityTimeScale => _entityTimeScale;
        private readonly ComponentHandler _componentHandler = new ComponentHandler();
        
        public T AddCustomComponent<T>(T component) where T : ICustomComponent
        {
            return _componentHandler.AddCustomComponent(component);
        }
        
        public void RemoveCustomComponent<T>() where T : class, ICustomComponent
        {
            _componentHandler.RemoveCustomComponent<T>();
        }
        
        public T GetCustomComponent<T>() where T : class, ICustomComponent
        {
            return _componentHandler.GetCustomComponent<T>();
        }

        public T TryGetCustomComponent<T>() where T : class, ICustomComponent
        {
            return _componentHandler.TryGetCustomComponent<T>();
        }
        
        protected void UpdateComponents(float timeScale)
        {
            _componentHandler.UpdateComponents(timeScale);
        }
        
        public void UpdateComponents()
        {
            _componentHandler.UpdateComponents(_entityTimeScale);
        }

        public static void SetGlobalEntityTimeScale(float entityTimeScale)
        {
            _entityTimeScale = entityTimeScale;
        }
        
        public void UpdateSpecificComponents(float timeScale = 1f, params ICustomComponent[] specificComponents)
        {
            _componentHandler.UpdateSpecificComponents(timeScale, specificComponents);
        }
        
        protected virtual void OnDestroy()
        {
            _componentHandler.DestroyAllComponents();
        }

        protected virtual void OnEnable()
        {
            _componentHandler.EnableAllComponents();
        }

        protected virtual void OnDisable()
        {
            _componentHandler.DisableAllComponents();
        }
    }
}
