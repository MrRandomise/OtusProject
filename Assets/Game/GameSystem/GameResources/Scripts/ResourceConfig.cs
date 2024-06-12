using UnityEngine;

namespace OtusProject.RecourcesConfig
{
    [CreateAssetMenu(fileName = "New resource", menuName = "Config/New resource")]
    public sealed class ResourceConfig : ScriptableObject
    {
        public int ID = 1;
        public Sprite Icon;
        public string NameResources;
        public int InitAmmount;
        public float LifeTime = 5f;

    }
}

