using System;
using Source.Interfaces;

namespace Source.Core.CustomException
{
    public class EntityAlreadyHasComponentOfThisClass : Exception
    {
        private const string ExceptionMessage = "The entity already has a component of this class";
        public EntityAlreadyHasComponentOfThisClass(Type type) { }
        public EntityAlreadyHasComponentOfThisClass(Type type,string message = "") : base($"{ExceptionMessage} {type.FullName}") { }
        public EntityAlreadyHasComponentOfThisClass(Type type,Exception inner, string message = "") : base($"{ExceptionMessage} {type.FullName}", inner) { }
    }
}