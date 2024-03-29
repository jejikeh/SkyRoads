﻿using JetBrains.Annotations;

namespace Source.Interfaces
{
    public interface IComponentHandler
    {
        public T AddCustomComponent<T>(T component) where T : ICustomComponent;
        public void RemoveCustomComponent<T>() where T : class, ICustomComponent;
        public T GetCustomComponent<T>() where T : class, ICustomComponent;
        [CanBeNull] public T TryGetCustomComponent<T>() where T : class, ICustomComponent;
    }
}