using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OtusProject.RecourcesConfig
{
    public class ResourcesStorage : MonoBehaviour
    {
        [SerializeField] private List<ResourcesInstaler> _resourceList = new List<ResourcesInstaler>();
        private Dictionary<int, int> _currentResources = new Dictionary<int, int>();
        public event Action<int> OnChangeResources;

        private void Awake()
        {
            InitialStorage();
        }

        public void SetAmmountResources(int id, int newAmmount)
        {
            _currentResources[id] += newAmmount;
            var ammount = GetAmmountResources(id);
            OnChangeResources?.Invoke(ammount);
        }

        public int GetAmmountResources(int key)
        {
            return _currentResources[key];
        }

        private void InitialStorage()
        {
            foreach (var item in _resourceList) 
            {
                var ammount = item.Resources.InitAmmount;
                var id = GetKeyInInstaller(item);
                _currentResources.Add(id, ammount);
            }
        }
        
        private ResourcesInstaler GetInstallerInKey(int id)
        {
            foreach(var item in _resourceList)
            {
                if(item.Resources.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public int GetKeyInInstaller(ResourcesInstaler key) => key.Resources.ID;

    }
}