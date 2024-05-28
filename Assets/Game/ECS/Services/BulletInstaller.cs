using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;

namespace OtusProject.Content
{
    public class BulletInstaller : EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new BulletSpeed());
            entity.AddData(new BulletLife());
            entity.AddData(new BulletMoveDirection());
            entity.AddData(new CurrBulletLife { Value = 0 });
            entity.AddData(new BulletTransform { Value = transform });
            entity.AddData(new BulletPosition { Value = transform.position });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}