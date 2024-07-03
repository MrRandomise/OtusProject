using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletConfig _bulletConfig;

        public BulletConfig BulletConfig => _bulletConfig;
    }
}