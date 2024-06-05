using UnityEngine;

namespace OtusProject.Config.Zombie
{
    [CreateAssetMenu(fileName ="Zombie config", menuName="Config/Zombie")]
    public sealed class ZombieConfig : ScriptableObject
    {
        public int Health;
        public float MoveSpeed;
        public float RotateSpeed;
        public float AttackDistance;
        public float DeathTimeout;
        public int Damage;
    }
}