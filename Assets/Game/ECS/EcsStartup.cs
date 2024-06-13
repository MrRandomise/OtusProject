using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using OtusProject.Component.Events;
using OtusProject.System.Zombie;
using OtusProject.Systems.View;
using OtusProject.ECSEvent;
using Zenject;
using OtusProject.System.Effects;

namespace EcsEngine
{
    public sealed class EcsStartup : MonoBehaviour
    {        
        private EcsWorld _world;
        private IEcsSystems _systems;
        public EntityManager EntityManager;
        private OnDeathInECS _onDeathECS;
        private OnHitInECS _onHitEcs;
        private OnDropInECS _onDropEcs;
        
        [Inject]
        private void Construct(OnDeathInECS onDeathECS, OnHitInECS onHitEcs, OnDropInECS onDropEcs)
        {
            _onDeathECS = onDeathECS;
            _onHitEcs = onHitEcs;
            _onDropEcs = onDropEcs;
        }

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
                .Add(new DeathSystem())
                .Add(new ZombieAttackSystem())
                .Add(new MoviementSystem())
                .Add(new NavMashSystem())
                .Add(new RotateCharacterSystem())
                .Add(new TakeBulletEffectsSystem())
                .Add(new BleendingEffectSystem())
                .Add(new SlowingEffectSystem())
                .Add(new DamageSystem())
                .Add(new LifeTimerSystem())
                .Add(new DropSystem())
                .Add(new RotateInAttackSystem())
                //Views
                .Add(new AnimatorMoveSystem())
                .Add(new AnimatorAttackSystem())
                .Add(new AnimatorDamageSystem())
                .Add(new AnimatorDeathSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())

#endif
                .DelHere<AttackEvent>()
                .DelHere<DeathEvent>()
                .DelHere<HitEvent>()
                .DelHere<DamageEvent>();
        }

        private void Start()
        {
            _systems.Inject(EntityManager);
            _systems.Inject(_onDeathECS);
            _systems.Inject(_onHitEcs);
            _systems.Inject(_onDropEcs);
            
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