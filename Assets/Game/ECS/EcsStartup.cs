using OtusProject.System.Spawn;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.Component.Events;
using OtusProject.System.Zombie;
using OtusProject.Systems.View;
using OtusProject.System.Bullet;
using EcsEngine.Systems.View;
using Client;

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
                .Add(new ZombieStartSpawn())
                .Add(new ZombieSpawnSystem())
                .Add(new ZombieControl())
                .Add(new ZombieTakeDamage())
                .Add(new ZombieDeath())
                .Add(new ZombieMoviement())
                .Add(new ZombieEndWave())
                .Add(new BulletSpawn())
                .Add(new BulletHit())
                .Add(new BulletMove())

                //Views
                .Add(new AnimatorZombieSystem())
                .Add(new TransformViewSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif

                .DelHere<AttackEvent>()
                .DelHere<MoveEvent>()
                .DelHere<SpawnEvents>()
                .DelHere<DeathEvent>();
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

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}