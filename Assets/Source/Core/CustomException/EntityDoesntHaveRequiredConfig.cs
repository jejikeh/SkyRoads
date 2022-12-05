using System;

namespace Source.Core.CustomException
{
    public class EntityDoesntHaveRequiredConfig<T> : Exception where T : EmptyComponentConfig
    {
        private const string ExceptionMessage = "The entity does not have the required config";
        public EntityDoesntHaveRequiredConfig() { }
        public EntityDoesntHaveRequiredConfig(string message = "") : base($"{ExceptionMessage} {typeof(T).FullName}") { }
        public EntityDoesntHaveRequiredConfig(Exception inner, string message = "") : base($"{ExceptionMessage} {typeof(T).FullName}", inner) { }
    }
}