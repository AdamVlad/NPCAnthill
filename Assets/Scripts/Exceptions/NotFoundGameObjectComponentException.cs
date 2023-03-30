using System;

namespace Assets.Scripts.Exceptions
{
    public class NotFoundGameObjectComponentException<T> : Exception
    {
        public NotFoundGameObjectComponentException() 
            : base($"Player component {typeof(T)} not found")
        {
        }
    }
}