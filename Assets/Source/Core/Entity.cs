using System;
using System.Collections.Generic;
using System.Linq;
using Source.Core.CustomException;
using Source.Interfaces;
using UnityEngine;

namespace Source.Core
{
    public abstract class Entity : MonoBehaviour, IComponentHandler
    {
        [SerializeField] private List<EntityComponentConfig> _componentConfigs = new List<EntityComponentConfig>();
        private readonly List<ICustomComponent> _components = new List<ICustomComponent>();
        
        protected void StartComponents()
        {
            foreach (var component in _components.Where(x => x.Enabled))
                component.Start();
        }
        
        protected void UpdateComponents()
        {
            foreach (var component in _components.Where(x => x.Enabled))
                component.Update();
        }

        public void AddCustomComponent(ICustomComponent component)
        {
            var requiredComponent = _components.FirstOrDefault(x => component.GetType() == x.GetType());
            if (requiredComponent is not null)
                throw new EntityAlreadyHasComponentOfThisClass(component.GetType());
            
            _components.Add(component);
        }

        public void RemoveCustomComponent<T>() where T : class, ICustomComponent
        {
            var component = GetCustomComponent<T>();
            _components.Remove(component);
        }

        public T GetCustomComponentConfig<T>() where T : EntityComponentConfig
        {
            var requiredConfig = _componentConfigs.FirstOrDefault(x => typeof(T) == x.GetType());
            if (requiredConfig is null)
                throw new EntityDoesntHaveRequiredConfig<T>();
            
            return requiredConfig as T;
        }
        
        public T GetCustomComponent<T>() where T : class, ICustomComponent
        {
            var requiredComponent = _components.FirstOrDefault(x => typeof(T) == x.GetType());
            if (requiredComponent is null)
                throw new EntityDoesntHaveRequiredComponent<T>();
            
            return requiredComponent as T;
        }

        public T TryGetCustomComponent<T>() where T : class, ICustomComponent
        {
            var requiredComponent = _components.FirstOrDefault(x => typeof(T) == x.GetType());
            return requiredComponent as T;
        }

        public T TryGetCustomComponentConfig<T>() where T : EntityComponentConfig
        {
            var requiredConfig = _componentConfigs.FirstOrDefault(x => typeof(T) == x.GetType());
            return requiredConfig as T;
        }

        private void OnDisable()
        {
            foreach (var component in _components)
                component.Disable();
        }

        private void OnEnable()
        {
            foreach (var component in _components)
                component.Enable();
        }
    }
}
