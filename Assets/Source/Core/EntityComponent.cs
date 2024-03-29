﻿using Source.Interfaces;

namespace Source.Core
{
    public class EmptyConfig : ICustomComponentConfig { }

    public abstract class EntityComponent<T> : ICustomComponent where T : ICustomComponentConfig
    {
        public bool Enabled => _enabled;
        protected T ComponentConfig { get; }
        private bool _enabled = true;
        
        private void OnEnable() { }
        
        private void OnDisable() { }
        
        protected virtual void OnDestroy() { }
        
        /// <summary>
        /// Enable component
        /// </summary>
        public void Enable()
        {
            _enabled = true;
            OnEnable();
        }

        /// <summary>
        /// Disable component
        /// </summary>
        public void Disable()
        {
            _enabled = false;
            OnDisable();
        }

        public void Destroy()
        {
            OnDestroy();
        }
        
        protected EntityComponent(T componentConfig)
        {
            ComponentConfig = componentConfig;
        }

        /// <summary>
        /// Implies calling yourself in Update
        /// </summary>
        /// <param name="timeScale"></param>
        public abstract void Update(float timeScale);
    }
}