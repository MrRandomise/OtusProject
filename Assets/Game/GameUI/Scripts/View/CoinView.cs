using TMPro;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class CoinView : MonoBehaviour
    {
        public TMP_Text Value;

        public void SetCoinView(int ammount)
        {
            Value.text = $"x {ammount}";
        }
    }
}