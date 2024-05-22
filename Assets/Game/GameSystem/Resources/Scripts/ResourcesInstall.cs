using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesInstall : MonoBehaviour
    {
        [SerializeField] private ResourceConfig _resources;
        [SerializeField] private int _ammount = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _resources.SetCountResources(_ammount);
                Destroy(gameObject);
            }
        }
    }
}
