using Assets.Scripts.Interfaces;

using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public sealed class NPCInstaller : MonoInstaller
    {
        [SerializeField] private Transform _surfaceCenter;
        [SerializeField] private float _searchRange;

        public override void InstallBindings()
        {
            InstallRandomPointGenerator();
        }

        private void InstallRandomPointGenerator()
        {
            Container
                .Bind<IRandomPointGenerator>()
                .To<NavMeshRandomPointGenerator>()
                .AsSingle()
                .WithArguments(_surfaceCenter.position, _searchRange);
        }
    }
}