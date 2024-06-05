using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Pools
{
    public interface IPoolView
    {
        public Transform GetActivePools();
        public Transform GetInActivePools();
        public GameObject GetGameObject();
        public Transform GetSpawnPoint();
    }
}

