using OtusProject.Component.Events;
using OtusProject.Component.Request;
using OtusProject.System.Spawn;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.System.Zombie;
using OtusProject.Systems.View;
using OtusProject.System.Weapon;
using OtusProject.System.PlayerUpdate;

namespace EcsEngine
{
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        IEcsSystems _systems;
        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new EntityManager();
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems
                //Systems
                .Add(new ZombieSpawnSystem())
                .Add(new ZombieControl())
                .Add(new ZombieMoviement())
                .Add(new PlayerAtack())
                .Add(new StartPlayerAttack())
                .Add(new PlayerUpdate())
                //Views
                .Add(new AnimatorZombieSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                //Clean Up
                .DelHere<SpawnEvent>();
        }

        private void Start()
        {
            _entityManager.Initialize(_world);
            _systems.Inject(_entityManager);
            _systems.Init();
        }

        private void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}