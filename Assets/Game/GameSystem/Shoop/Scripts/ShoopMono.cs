using OtusProject.Config.Weapon;
using System.Collections.Generic;
using UnityEngine;
using OtusProject.View;

namespace OtusProject.ShoopSystem
{
    public class ShoopMono : MonoBehaviour
    {
        public List<ItemConfig> sellItem = new List<ItemConfig>();
        public Transform Content;
        public ItemsPanel ContentPrefab;
    }
}

