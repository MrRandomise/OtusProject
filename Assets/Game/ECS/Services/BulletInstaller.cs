using Leopotam.EcsLite.Entities;
using OtusProject.Component;

namespace OtusProject.Content
{
    public class BulletInstaller : EntityInstaller
    {
        protected override void Install(Entity entity)
        {
            entity.AddData(new Speed());
            entity.AddData(new MoveDirection());
            entity.AddData(new CurrentTransform { Value = transform });
            entity.AddData(new BulletTag ());
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}