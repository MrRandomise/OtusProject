using System.Collections.Generic;
using Zenject;

namespace OtusProject.ItemSystem
{
    public class Items : IInitializable
    {
        public static Dictionary<string, IItems> ItemsList = new();
        private IItems _health;

        [Inject]
        private void Construct(HealthBottle health)
        {
            _health = health;
        }

        public void Initialize()
        {
            ItemsList.Add("Health", _health);
        }
    }
}

