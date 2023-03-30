using Assets.Scripts.Interfaces;

using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class NavMeshRandomPointGenerator : IRandomPointGenerator
    {
        public NavMeshRandomPointGenerator(Vector3 surfaceCenter, float searchRadius)
        {
            _surfaceCenter = surfaceCenter;
            _searchRadius = searchRadius;
        }

        public bool GetRandomPoint(out Vector3 result)
        {
            for (uint i = 0; i < 30; i++)
            {
                var randomPoint = _surfaceCenter + Random.insideUnitSphere * _searchRadius;

                if (NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }

            result = Vector3.zero;
            return false;
        }

        private readonly Vector3 _surfaceCenter;
        private readonly float _searchRadius;
    }
}