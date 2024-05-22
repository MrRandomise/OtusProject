using OtusProject.RecourcesConfig;
using UnityEngine;

namespace OtusProject.ItemSystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Config/Item")]
    public sealed class ItemConfig : ScriptableObject
    {
        public string Name;
        public Sprite ItemIcon;
        public IItems Item;
        public ResourceConfig Resource;
        public int Price;
        public int MaxBuy;
        private int currBuy;

        public void UseItem()
        {
            Item = FindItem();
            Item.UseItem();
        }

        public IItems FindItem()
        {
            return Items.ItemsList.ContainsKey(Name) ? Items.ItemsList[Name]  : null;
        }

        public void SetCurrBuy()
        {
            currBuy++;
        }

        public int GetCurrBuy()
        {
            return currBuy;
        }

        private void OnDisable()
        {
            currBuy = 0;
        }
    }
}
