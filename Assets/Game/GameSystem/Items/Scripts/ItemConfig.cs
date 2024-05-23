using OtusProject.RecourcesConfig;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Config/Item")]
    public sealed class ItemConfig : ScriptableObject
    {
        public string Name;
        public Sprite ItemIcon;

        [SerializeField] public Items item;


        public ResourceConfig Resource;
        public int Price;
        public int MaxBuy;
        public int CurrBuy;

        public void UseItem()
        {
            item.Components.BuyItem();
        }

        public void SetCurrBuy()
        {
            CurrBuy++;
        }

        public int GetCurrBuy()
        {
            return CurrBuy;
        }

        private void OnDisable()
        {
            CurrBuy = 0;
        }
    }
}
