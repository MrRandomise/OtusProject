using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.Weapons
{
    public sealed class BulletConfigProvider 
    {
        public bool TryGetBulletConfig(GameObject bullet, out BulletConfig bulletConf)
        {
            if(bullet.TryGetComponent<Bullet>(out var bulletConfig))
            {
                bulletConf = bulletConfig.BulletConfig;
                return true;
            }
            bulletConf = null;
            return false;
        }
    }
}

