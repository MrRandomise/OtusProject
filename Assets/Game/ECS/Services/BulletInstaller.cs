using Leopotam.EcsLite.Entities;
using OtusProject.Component.Bullet;
using OtusProject.Component.View;
using OtusProject.Component.Zombie;

namespace OtusProject.Content
{
    public class BulletInstaller : EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new BulletDamage());
            entity.AddData(new BulletSpeed());
            entity.AddData(new BulletLife());
            entity.AddData(new MoveDirection ());
            entity.AddData(new BulletPosition { Value = transform.position });
            entity.AddData(new TransformView { Value = transform });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}