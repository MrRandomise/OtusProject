using UnityEngine;
using UnityEngine.UI;

namespace OtusProject.ModulesUI
{
    public sealed class ProductView : MonoBehaviour
    {
        public Image Icon;
        public BuyButton BuyButton;

        public void RemoveContent()
        { 
            Destroy(gameObject);
        }
    }
}