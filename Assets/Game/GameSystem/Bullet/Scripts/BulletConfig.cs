using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Content;
using UnityEngine;


namespace OtusProject.Config.Weapons
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