using System;
using Assets.Scripts.Factories;

using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _npcSpawnPoints;

        [Inject]
        private void Construct(NPCFactory npcFactory)
        {
            _npcFactory = npcFactory;
        }

        private void Awake()
        {
            if (_npcSpawnPoints == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void Start()
        {
            foreach (var spawnPoint in _npcSpawnPoints)
            {
                var npc = _npcFactory.Create();
                npc.transform.position = spawnPoint.position;
            }
        }

        private NPCFactory _npcFactory;
    }
}