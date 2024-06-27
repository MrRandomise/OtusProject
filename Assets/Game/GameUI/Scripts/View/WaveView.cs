using System;
using TMPro;
using UnityEngine;

namespace OtusProject.View
{
    public sealed class WaveView : MonoBehaviour
    {
        public TMP_Text Waves;
        public TMP_Text Messages;
        public TMP_Text Timer;
        public void SetWaveView(int ammount)
        {
            Waves.text = $"x {ammount}";
        }

        public void SetMessagesView(string text)
        {
            Messages.text = text;
        }

        public void ClearMessage()
        {
            Messages.text = "";
            Timer.text = "";
        }

        public void SetTimerView(float ammount)
        {
            Timer.text = $"До начало волны: {Math.Round(ammount)}";
        }
    }
}
