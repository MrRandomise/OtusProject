using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    [CreateAssetMenu(fileName = "New resource", menuName = "Config/New resource")]
    public sealed class ResourceConfig : ScriptableObject
    {
        public Sprite Icon;
        public int Ammount;
        public string NameResources;
        public int InitAmmount;
        public float LifeTime = 5f;

        private void OnDisable()
        {
            Ammount = InitAmmount;
        }
    }
}

