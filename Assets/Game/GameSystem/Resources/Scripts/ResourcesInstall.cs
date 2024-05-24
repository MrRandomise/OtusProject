using OtusProject.View;
using UnityEngine;
using Zenject;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesInstall : MonoBehaviour
    {
        [SerializeField] private ResourceConfig _resources;
        [SerializeField] private int _ammount = 1;
        [SerializeField] private CoinView _view;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _resources.SetCountResources(_ammount);
                UpdateView();
                Destroy(gameObject);
            }
        }

        private void UpdateView()
        {
            _view.Value.text = $"{_resources.GetCountResources()} x";
        }
    }
}
