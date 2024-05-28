using UnityEngine;
using System;

namespace OtusProject.RecourcesConfig
{
    [CreateAssetMenu(fileName = "New resource", menuName = "Config/New resource")]
    public sealed class ResourceConfig : ScriptableObject
    {
        public Sprite Icon;
        public event Action<int> OnTakeResources;
        [SerializeField] private int _ammount;
        [SerializeField] private string _nameResources;

        private int _currAmoutn;

        public int GetCountResources()
        {
            return _currAmoutn;
        }

        public void SetCountResources(int count)
        {
            _currAmoutn += count;
            OnTakeResources?.Invoke(_currAmoutn);
        }

        public string GetNameResources()
        {
            return _nameResources;
        }

        private void OnDisable()
        {
            _currAmoutn = _ammount;
        }

    }
}

