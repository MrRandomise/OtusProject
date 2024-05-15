using OtusProject.Component.Events;
using OtusProject.SpawnSystem;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.MoviementSystem;
using OtusProject.Systems.View;

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
                .Add(new ZombieMoviement())
                //Views
                .Add(new AnimatorViewSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                //Clean Up
                .DelHere<SpawnEvent>()
                .DelHere<ZombieMoveEvent>();
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