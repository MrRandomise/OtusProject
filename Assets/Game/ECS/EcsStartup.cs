using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.Component.Events;
using OtusProject.System.Zombie;
using OtusProject.Systems.View;

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
                .Add(new MoviementSystem())
                .Add(new NavMashSystem())
                .Add(new RotateCharacterSystem())
                .Add(new TakeBulletEffectsSystem())
                .Add(new DamageSystem())
                .Add(new DeathSystem())
                .Add(new LifeTimerSystem())
                .Add(new DropSystem())
                .Add(new RotateInAttackSystem())
                //Views
                .Add(new AnimatorSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())

#endif
                .DelHere<AttackEvent>()
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