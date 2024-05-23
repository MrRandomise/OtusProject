using System;
using UnityEngine;
using Zenject;

namespace OtusProject.ItemSystem
{
    [Serializable]
    public sealed class Items
    {
        [SerializeField] private string name;

        [SerializeReference] public IItems Components;

        public Items(
            string name,
            IItems components
        )
        {
            this.name = name;
            Components = components;
        }

        public string Name => name;

        [Inject]
        private void Construct()
        {
            Debug.Log("test");
        }
    }
}
