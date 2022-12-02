using System;
using Source.Interfaces;

namespace Source.Core.CustomException
{
    public class EntityDoesntHaveRequiredComponent<T> : Exception where T : ICustomComponent
    {
        private const string ExceptionMessage = "The entity does not have the required component";
        public EntityDoesntHaveRequiredComponent() { }
        public EntityDoesntHaveRequiredComponent(string message = "") : base($"{ExceptionMessage} {typeof(T).FullName}") { }
        public EntityDoesntHaveRequiredComponent(Exception inner, string message = "") : base($"{ExceptionMessage} {typeof(T).FullName}", inner) { }
    }
}