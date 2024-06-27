using TMPro;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class HealthView : MonoBehaviour
    {
        public TMP_Text Value;

        public void SetHealthView(int ammount)
        {
            Value.text = $"x {ammount}";
        }
    }
}
