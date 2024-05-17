using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Config/Bullet")]
public sealed class BulletConfig : ScriptableObject
{
    public int Damage;
    public float Speed;
    public float LifeTime;
}