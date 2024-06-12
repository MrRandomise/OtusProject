using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OtusProject.View
{
    public class WeaponPanel : MonoBehaviour
    {
        public Image ItemIcon;
        public TMP_Text ItemCount;
        public TMP_Text ItemMaxCount;
        public TMP_Text Key;

        public void ShowItems()
        {
            ItemIcon.color = new Color(1f, 1f, 1f, 1f);
            ItemCount.color = new Color(1f, 1f, 1f, 1f);
            ItemMaxCount.color = new Color(1f, 1f, 1f, 1f);
            Key.color = new Color(1f, 1f, 1f, 1f);
        }

        public void OpacityItems()
        {
            ItemIcon.color = new Color(1f, 1f, 1f, 0.5f);
            ItemCount.color = new Color(1f, 1f, 1f, 0.5f);
            ItemMaxCount.color = new Color(1f, 1f, 1f, 0.5f);
            Key.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}