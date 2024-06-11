using OtusProject.RecourcesConfig;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Config/Item")]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeReference] public IItems Component;
        public string Name;
        public ResourceConfig Resource;
        public int Price;
        public int MaxBuy;
        public int CurrBuy;
    }
}
