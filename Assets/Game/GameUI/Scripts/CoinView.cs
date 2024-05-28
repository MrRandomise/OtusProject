using TMPro;
using UnityEngine;
using OtusProject.RecourcesConfig;

namespace OtusProject.View
{
    public sealed  class CoinView : MonoBehaviour
    {
        public TMP_Text Value;
        [SerializeField] private ResourceConfig _config;

        private void Awake()
        {
            UpdateView(_config.GetCountResources());
            _config.OnTakeResources += UpdateView;
        }

        private void UpdateView(int ammount)
        {
            Value.text = $"{ammount} x";
        }

        private void OnDisable()
        {
            _config.OnTakeResources -= UpdateView;
        }
    }
}