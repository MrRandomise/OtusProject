using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.Component.Events;
using OtusProject.System.Zombie;
using OtusProject.Systems.View;
using OtusProject.System.Bullet;

namespace EcsEngine
{
    public sealed class EcsStartup : MonoBehaviour
    {        
        private EcsWorld _world;
        private IEcsSystems _systems;
        public EntityManager EntityManager;


        public EcsWorld GetWorld()
        {
            return _world;
        }

        private void Awake()
        {
            EntityManager = new EntityManager();
            _world = new EcsWorld();
            EntityManager.Initialize(_world);
            _systems = new EcsSystems(_world);
            _systems
                //Systems
                .Add(new ZombieControl())
                .Add(new ZombieMoviement())
                .Add(new MoviementCharacter())
                .Add(new RotateCharacter())
                .Add(new HitSystem())
                .Add(new ZombieTakeEffects())
                .Add(new DamageSystem())
                .Add(new DeathSystem())
                .Add(new DropSystem())
                .Add(new ZombieMoviement())
                .Add(new RotateInAttackSystem())
                .Add(new BulletMove())
                //Views
                .Add(new AnimatorZombieSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())

#endif
                .DelHere<AttackEvent>()
                .DelHere<MoveEvent>()
                .DelHere<DeathEvent>()
                .DelHere<HitEvent>();
        }

        private void Start()
        {
            _systems.Inject(EntityManager);
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