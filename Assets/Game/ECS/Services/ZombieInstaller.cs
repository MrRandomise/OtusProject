using Leopotam.EcsLite.Entities;
using UnityEngine;
using OtusProject.Component.Zombie;
using UnityEngine.AI;
using OtusProject.Config.Zombie;

namespace OtusProject.Content
{
    public sealed class ZombieInstaller : EntityInstaller
    {
        public int Damage;
        [SerializeField] private NavMeshAgent _agent; 
        [SerializeField] private ZombieConfig _zombieConfig;
        [SerializeField] private GameObject _drop;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _healthBar;

        private void Awake()
        {
            _agent.speed = _zombieConfig.MoveSpeed;
            _agent.stoppingDistance = _zombieConfig.AttackDistance;
            Damage = _zombieConfig.Damage;
        }

        protected override void Install(Entity entity)
        {
            entity.AddData(new ZombieNavAgent { Value = _agent });
            entity.AddData(new ZombieTag { Value = "Zombie" });
            entity.AddData(new ZombieTransform { Value = transform });
            entity.AddData(new ZombieHealth { Value = _zombieConfig.Health });
            entity.AddData(new ZombieCurrHealth { Value = _zombieConfig.Health });
            entity.AddData(new ZombiePosition { Value = transform.position });
            entity.AddData(new ZombieRotateSpeed { Value = _zombieConfig.RotateSpeed });
            entity.AddData(new ZombieAttackDistance { Value = _zombieConfig.AttackDistance });
            entity.AddData(new ZombieAnimator { Value = _animator });
            entity.AddData(new ZombieDrop { Value = _drop });
            entity.AddData(new ZombieDeathTimeout { Value = _zombieConfig.DeathTimeout });
            entity.AddData(new ZombieDeathCurrTimeout { Value = 0 });
            entity.AddData(new HealthBar { Value = _healthBar });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
