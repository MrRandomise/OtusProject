using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesInstall : MonoBehaviour
    {
        [SerializeField] private ResourceConfig _resources;

        private void OnTriggerEnter(Collider other)
        {
            var _count = _resources.GetCountResources() + 1;
            _resources.SetCountResources(_count);
            Destroy(gameObject);
        }
    }
}
