using UnityEngine;
using UnityEngine.UI;

namespace OtusProject.View
{
    public sealed class ItemsShopPanel : MonoBehaviour
    {
        public Image Icon;
        public BuyButton BuyButton;

        public void RemoveContent()
        { 
            Destroy(gameObject);
        }
    }
}