using JetBrains.Annotations;
using Source.Core;

namespace Source.Interfaces
{
    public interface IComponentHandler
    {
        public ICustomComponent AddCustomComponent(ICustomComponent component);
        public void RemoveCustomComponent<T>() where T : class, ICustomComponent;
        public T GetCustomComponentConfig<T>() where T : EmptyComponentConfig;
        public T GetCustomComponent<T>() where T : class, ICustomComponent;
        [CanBeNull] public T TryGetCustomComponent<T>() where T : class, ICustomComponent;
        [CanBeNull] public T TryGetCustomComponentConfig<T>() where T : EmptyComponentConfig;
    }
}