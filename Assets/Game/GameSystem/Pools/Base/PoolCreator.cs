using UnityEngine;

namespace OtusProject.Pools
{
    public sealed class PoolCreator
    {
        public GameObject CreatObject(GameObject prefab, Transform point, Transform pool)
        {
            return Object.Instantiate(prefab, point.position, Quaternion.identity, pool);
        }
    }
}

