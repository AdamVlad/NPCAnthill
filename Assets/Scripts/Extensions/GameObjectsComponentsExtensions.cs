using Assets.Scripts.Exceptions;

using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class GameObjectsComponentsExtensions
    {
        public static T GetComponentOrThrowException<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? throw new NotFoundGameObjectComponentException<T>();
        }
    }
}