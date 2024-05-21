using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OtusProject.View
{
    public class ItemsPanel : MonoBehaviour
    {
        public Image Icon;
        public Button BuyButton;
        public Image CoinIcon;
        public TMP_Text PriceText;

        public void RemoveContent()
        { 
            Destroy(gameObject);
        }
    }
}