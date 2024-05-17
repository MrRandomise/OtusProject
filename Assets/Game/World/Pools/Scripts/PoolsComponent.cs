using System;
using UnityEngine;

namespace OtusProject.PoolsSystem
{

    public class PoolsComponent : MonoBehaviour
    {
        [SerializeField] private Transform _inActivePool;
        public event Action OnBulletEvent;

        public GameObject GetOrCreateBullet(GameObject bullet, Transform point)
        {
            GameObject newBullet;

            if (_inActivePool.childCount > 0)
            {
                newBullet = _inActivePool.GetChild(0).gameObject;
            }
            else
            {
                newBullet = Instantiate(bullet, point.position, Quaternion.identity);
            }
            newBullet.transform.SetParent(transform, false);
            OnBulletEvent?.Invoke();
            return newBullet;
        }
    }
}
