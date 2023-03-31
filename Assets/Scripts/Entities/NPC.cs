using System;
using Assets.Scripts.Extensions;
using Assets.Scripts.Interfaces;

using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Entities
{
    [RequireComponent(
        typeof(NavMeshAgent),
        typeof(CapsuleCollider),
    typeof(Rigidbody))]
    public class NPC : MonoBehaviour
    {
        [Inject]
        private void Construct(
            IRandomPointGenerator randomPointGenerator,
            IUniqueGenerator<int> uniqueGenerator)
        {
            _randomPointGenerator = randomPointGenerator ?? throw new NullReferenceException();
            _uniqueNumberGenerator = uniqueGenerator ?? throw new NullReferenceException();

        }

        private void Start()
        {
            _navMeshAgentHashed = gameObject.GetComponentOrThrowException<NavMeshAgent>();
            _navMeshAgentHashed.avoidancePriority = _uniqueNumberGenerator.GetUnique(0,100);
        }

        private void Update()
        {
            if (!_navMeshAgentHashed.isActiveAndEnabled) return;

            if (_navMeshAgentHashed.remainingDistance <= _navMeshAgentHashed.stoppingDistance)
            {
                if (_randomPointGenerator.GetRandomPoint(out var point))
                {
                    _destinationPointHashed = point;
                    _navMeshAgentHashed.SetDestination(point);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<NPC>(out _))
            {
                _navMeshAgentHashed.SetDestination(_destinationPointHashed);
            }
        }

        private Vector3 _destinationPointHashed;

        private NavMeshAgent _navMeshAgentHashed;
        private IRandomPointGenerator _randomPointGenerator;
        private IUniqueGenerator<int> _uniqueNumberGenerator;
    }
}