using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IRandomPointGenerator
    {
        bool GetRandomPoint(out Vector3 result);
    }
}