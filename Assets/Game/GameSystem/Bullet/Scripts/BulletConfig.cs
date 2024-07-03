using Leopotam.EcsLite.Entities;
using UnityEngine;


namespace OtusProject.Weapons
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Config/Bullet")]
    public sealed class BulletConfig : ScriptableObject
    {
        [SerializeReference] public IEffects Effects;
        public Entity Bullet;
        public float Speed;
        public float LifeTime;
    }
}