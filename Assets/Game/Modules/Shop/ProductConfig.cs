using OtusProject.RecourcesConfig;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [CreateAssetMenu(fileName = "New Product", menuName = "Config/New Product")]
    public sealed class ProductConfig : ScriptableObject
    {
        [SerializeReference] public IProduct Product;
        public Sprite Icon;
        public string Name;
        public ResourceConfig Resource;
        public int Price;
        public int MaxBuy;
        public int CurrBuy;

        private void OnDisable()
        {
            CurrBuy = 0;
        }
    }
}
