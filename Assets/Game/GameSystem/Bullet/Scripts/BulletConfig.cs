using Leopotam.EcsLite.Entities;
using UnityEngine;


namespace OtusProject.Config.Weapons
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Config/Bullet")]
    public sealed class BulletConfig : ScriptableObject
    {
        public Entity Bullet;
        public int Damage;
        public float Speed;
        public float LifeTime;
    }
}