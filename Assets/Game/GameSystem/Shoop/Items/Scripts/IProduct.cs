using UnityEngine;
namespace OtusProject.ItemSystem
{
    public interface IProduct
    {
        public Sprite GetIcon();
        void BuyItem();
    }
}

