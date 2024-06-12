using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class WaveView : MonoBehaviour
    {
        public TMP_Text Waves;

        public void SetWaveView(int ammount)
        {
            Waves.text = $"x {ammount}";
        }
    }
}
