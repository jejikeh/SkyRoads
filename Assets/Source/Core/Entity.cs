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
        [SerializeField] private List<EmptyComponentConfig> _componentConfigs = new List<EmptyComponentConfig>();
        private readonly List<ICustomComponent> _components = new List<ICustomComponent>();
        
        protected void StartComponents()
        {
            foreach (var component in _components.Where(x => x.Enabled))
                component.Start();
        }
        
        /// <summary>
        /// Update each component draped over an entity
        /// </summary>
        /// <param name="timeScale"></param>
        protected void UpdateComponents(float timeScale = 1f)
        {
            foreach (var component in _components.Where(x => x.Enabled))
                component.Update(timeScale);
        }
        
        /// <summary>
        /// Updates only those components that were specified in the arguments
        /// </summary>
        /// <param name="timeScale">The scale at which time passes for components</param>
        /// <param name="specificComponents"></param>
        protected void UpdateSpecificComponents(float timeScale = 1f, params ICustomComponent[] specificComponents)
        {
            foreach (var component in _components.Where(x => x.Enabled || specificComponents.Contains(x)))
                component.Update(timeScale);
        }
        
        /// <summary>
        /// Updates only those components that were specified in the array
        /// </summary>
        /// <param name="timeScale">The scale at which time passes for components</param>
        /// <param name="specificComponents"></param>
        protected void UpdateSpecificComponents(ICustomComponent[] specificComponents, float timeScale)
        {
            foreach (var component in _components.Where(x => x.Enabled || specificComponents.Contains(x)))
                component.Update(timeScale);
        }

        public ICustomComponent AddCustomComponent(ICustomComponent component)
        {
            var requiredComponent = _components.FirstOrDefault(x => component.GetType() == x.GetType());
            if (requiredComponent is not null)
                throw new EntityAlreadyHasComponentOfThisClass(component.GetType());
            
            _components.Add(component);
            return component;
        }

        public void RemoveCustomComponent<T>() where T : class, ICustomComponent
        {
            var component = GetCustomComponent<T>();
            _components.Remove(component);
        }

        public T GetCustomComponentConfig<T>() where T : EmptyComponentConfig
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

        public T TryGetCustomComponentConfig<T>() where T : EmptyComponentConfig
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
