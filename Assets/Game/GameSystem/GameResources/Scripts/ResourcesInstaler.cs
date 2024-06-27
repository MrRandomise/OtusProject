using Leopotam.EcsLite.Entities;
using OtusProject.Component;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesInstaler : EntityInstaller
    {
        public ResourceConfig Resources;
        public int Ammount = 1;

        protected override void Install(Entity entity)
        {
            entity.AddData(new CurrentTimer { Value = 0 });
            entity.AddData(new Pool());
            entity.AddData(new LifeTime { Value = Resources.LifeTime});
            entity.AddData(new CurrentEntity { Value = entity });
        }

        protected override void Dispose(Entity entity)
        {

        }
    }
}
