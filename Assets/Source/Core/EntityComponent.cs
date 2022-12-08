using System;
using Source.Interfaces;

namespace Source.Core
{
    public class EmptyConfig : ICustomComponentConfig { }

    public abstract class EntityComponent<T> : ICustomComponent where T : ICustomComponentConfig
    {
        public bool Enabled => _enabled;
        
        #region EnableDisable
        
        private bool _enabled = true;
        
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
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
        
        #endregion

        protected T Config => _config;

        private readonly T _config; 
        protected EntityComponent(T config)
        {
            _config = config;
        }
        
        /// <summary>
        /// Implies calling yourself in Update
        /// </summary>
        /// <param name="timeScale"></param>
        public abstract void Update(float timeScale);
    }
}