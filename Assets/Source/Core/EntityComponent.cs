using System;
using Source.Interfaces;

namespace Source.Core
{
    public abstract class EntityComponent<T> : ICustomComponent where T : EmptyComponentConfig
    {
        private bool _enabled = true;
        public bool Enabled => _enabled;
        public abstract void Start();
        public abstract void Update(float timeScale);
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        
        public void Enable()
        {
            _enabled = true;
            OnEnable();
        }

        public void Disable()
        {
            _enabled = false;
            OnDisable();
        }
        
        protected readonly T Config;
        protected Entity Entity;
        protected EntityComponent(IComponentHandler entity)
        {
            Entity = entity as Entity;
            if (Entity is null)
                throw new NullReferenceException("Object is not Entity");
            
            Config = Entity.GetCustomComponentConfig<T>();
        }

        public T GetConfig => Config;
    }
}