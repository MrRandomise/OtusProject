using TMPro;
using UnityEngine;
using Zenject;

namespace OtusProject.Shoop
{
    public class ShoopNoBuyTimer : ITickable
    {
        private Color _colorNormal = Color.white;
        private TMP_Text _text;
        private float _stopTimer = 2;
        private float _currTimer = 0;
        private bool _startTimer = false;

        public void Start(ref TMP_Text text)
        {
            _text = text;
            _currTimer = 0;
            _startTimer = true;
        }
        private void Stop()
        {
            _text.color =  _colorNormal;
            _startTimer = false;
        }

        public void Tick()
        {
            if (_startTimer)
            {
                _currTimer += Time.deltaTime;
                if (_currTimer >= _stopTimer)
                {
                    Stop();
                }
            }
        }
    }
}
