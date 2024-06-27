using TMPro;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class KillsView : MonoBehaviour
    {
        public TMP_Text Kills;

        public void SetKillView(int ammount)
        {
            Kills.text = $"x {ammount}";
        }
    }
}

