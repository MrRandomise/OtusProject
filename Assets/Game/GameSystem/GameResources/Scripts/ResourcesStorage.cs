using OtusProject.Player;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesStorage : MonoBehaviour
    {
        [SerializeField] private List<ResourcesInstaler> List = new List<ResourcesInstaler>();
        private Dictionary<int, int> Resources = new Dictionary<int, int>();
        private GetResources _getResources;

        [Inject]
        private void Construct(CharacterInstaller characterInstaller)
        {
            _getResources = characterInstaller.GetComponent<GetResources>();
            _getResources.onGetResources += SetAmmountResources;
            InitialStorage();
        }

        public void SetAmmountResources(ResourcesInstaler key)
        {
            Resources[key.ID] += key.HowGet;
        }

        public int GetAmmountResources(ResourcesInstaler key)
        {
            return Resources[key.ID];
        }

        private void InitialStorage()
        {
            foreach (var item in List) 
            {
                var ammount = item.Resources.InitAmmount;
                Resources.Add(item.ID, ammount);
            }
        }

        private void OnDisable()
        {
            _getResources.onGetResources -= SetAmmountResources;
        }

        
    }
}