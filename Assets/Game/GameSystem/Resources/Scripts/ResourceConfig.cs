using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    [CreateAssetMenu(fileName = "New resource", menuName = "Config/New resource")]
    public sealed class ResourceConfig : ScriptableObject
    {
        public Sprite Icon;
        [SerializeField] private int _ammount;
        [SerializeField] private string _nameResources;
        public int GetCountResources()
        {
            return _ammount;
        }

        public void SetCountResources(int count)
        {
            _ammount = count;
            Resources.UnloadUnusedAssets();
        }

        public string GetNameResources()
        {
            return _nameResources;
        }

        
    }
}

