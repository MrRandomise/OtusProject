using Leopotam.EcsLite.Entities;
using OtusProject.Component;
using OtusProject.Component.Bullet;
using OtusProject.Component.Request;

namespace OtusProject.Content
{
    public class BulletInstaller : EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new Speed());
            entity.AddData(new MoveDirection () );
            entity.AddData(new CurrentTransform { Value = transform });
            entity.AddData(new Pool ());
            entity.AddData(new LifeTime ());
            entity.AddData(new BulletTag ());
            entity.AddData(new CurrentTimer { Value = 0} );
            entity.AddData(new LifeTimerRequest());
            entity.AddData(new CurrentEntity { Value = entity });
            entity.AddData(new BulletEffects());
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}