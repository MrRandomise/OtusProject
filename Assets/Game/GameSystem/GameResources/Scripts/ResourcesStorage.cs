using System;
using System.Collections.Generic;
using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesStorage : MonoBehaviour
    {
        [SerializeField] private List<ResourceConfig> _resourceConfigs = new List<ResourceConfig>();
        private Dictionary<string, ResourceConfig> _resources = new Dictionary<string, ResourceConfig>();
        public event Action<int> OnChangeResources;

        private void Awake()
        {
            InitialRes();
        }

        public void SetAmmountResources(string id, int newAmmount)
        {
            _resources[id].Ammount += newAmmount;
            var ammount = GetAmmountResources(id);
            OnChangeResources?.Invoke(ammount);
        }

        public int GetAmmountResources(string key)
        {
            return _resources[key].Ammount;
        }

        private void InitialRes()
        {
            foreach(var resource in _resourceConfigs)
            {
                _resources.Add(resource.NameResources, resource);
            }
        }
    }
}