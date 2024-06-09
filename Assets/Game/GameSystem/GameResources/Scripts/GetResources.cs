using System;
using UnityEngine;


namespace OtusProject.RecourcesConfig
{
    public class GetResources : MonoBehaviour
    {
        public event Action<ResourcesInstaler> onGetResources;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Resources") && other.TryGetComponent(out ResourcesInstaler entity))
            {
                onGetResources?.Invoke(entity);
            }
        }
    }
}
