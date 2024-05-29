using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesInstall : MonoBehaviour
    {
        [SerializeField] private ResourceConfig _resources;
        [SerializeField] private int _howGet = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _resources.SetCountResources(_howGet);
                Destroy(gameObject);
            }
        }
    }
}
