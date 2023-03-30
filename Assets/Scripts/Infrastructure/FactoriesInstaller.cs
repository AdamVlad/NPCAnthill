using Assets.Scripts.Factories;

using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private NPC _npcPrefab;

        public override void InstallBindings()
        {
            InstallPlayerFactory();
        }

        private void InstallPlayerFactory()
        {
            Container
                .BindFactory<NPC, NPCFactory>()
                .FromComponentInNewPrefab(_npcPrefab);
        }
    }
}