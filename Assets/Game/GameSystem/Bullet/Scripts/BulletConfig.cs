using Leopotam.EcsLite.Entities;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Config/Bullet")]
public sealed class BulletConfig : ScriptableObject
{
    public Entity Bullet;
    public int Damage;
    public float Speed;
    public float LifeTime;
}