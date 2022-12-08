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
        /// <summary>
        /// Add Custom component to entity
        /// </summary>
        /// <param name="component"></param>
        /// <typeparam name="T">added component</typeparam>
        /// <returns></returns>
        /// <exception cref="EntityAlreadyHasComponentOfThisClass"></exception>
        public T AddCustomComponent<T>(T component) where T : ICustomComponent
        {
            var requiredComponent = _components.FirstOrDefault(x => component.GetType() == x.GetType());
            if (requiredComponent is not null)
                throw new EntityAlreadyHasComponentOfThisClass(component.GetType());
            
            _components.Add(component);
            return component;
        }
        
        /// <summary>
        /// Removes component by specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveCustomComponent<T>() where T : class, ICustomComponent
        {
            var component = GetCustomComponent<T>();
            _components.Remove(component);
        }
        
        /// <summary>
        /// Returns entity component by class 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityDoesntHaveRequiredComponent{T}"></exception>
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
        /// Updates only those objects that are listed in the arguments of the function
        /// </summary>
        /// <param name="timeScale"></param>
        /// <param name="specificComponents"></param>
        protected void UpdateSpecificComponents(float timeScale = 1f, params ICustomComponent[] specificComponents)
        {
            foreach (var component in _components.Where(x => x.Enabled || specificComponents.Contains(x)))
                component.Update(timeScale);
        }
        
        /// <summary>
        /// Updates only those objects that are listed in Updates only those components that are represented in the array
        /// </summary>
        /// <param name="timeScale"></param>
        /// <param name="specificComponents"></param>
        protected void UpdateSpecificComponents(ICustomComponent[] specificComponents, float timeScale)
        {
            foreach (var component in _components.Where(x => x.Enabled || specificComponents.Contains(x)))
                component.Update(timeScale);
        }
        
        private readonly List<ICustomComponent> _components = new List<ICustomComponent>();
        
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

        protected virtual void OnDestroy()
        {
            foreach (var component in _components)
                component.Destroy();
        }
    }
}
