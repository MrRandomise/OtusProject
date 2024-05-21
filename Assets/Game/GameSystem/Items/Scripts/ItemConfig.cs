using OtusProject.Items;
using OtusProject.RecourcesConfig;
using UnityEngine;
using AYellowpaper;

namespace OtusProject.Config.Weapon
{
    [CreateAssetMenu(fileName = "Item", menuName = "Config/Item")]
    public sealed class ItemConfig : ScriptableObject
    {
        public Sprite ItemIcon;
        public InterfaceReference<IItems> Item;
        public ResourceConfig Resource;
        public float Price;
        public int MaxBuy;


    }
}
