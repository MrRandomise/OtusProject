using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OtusProject.ModulesUI
{
    public sealed class BuyButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [Space]
        [SerializeField]
        private Image _buttonBackground;

        [SerializeField]
        private Sprite _availableButtonSprite;

        [SerializeField]
        private Sprite _lockedButtonSprite;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _priceText;

        [SerializeField]
        private Image _priceIcon;

        [Space]
        [SerializeField]
        private State _state;

        public void AddListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            _button.onClick.RemoveListener(action);
        }

        public void SetPrice(string price)
        {
            _priceText.text = price;
        }

        public void SetIcon(Sprite icon)
        {
            _priceIcon.sprite = icon;
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? State.AVAILABLE : State.LOCKED;
            SetState(state);
        }

        public void SetState(State state)
        {
            _state = state;

            if (state == State.AVAILABLE)
            {
                _button.interactable = true;
                _buttonBackground.sprite = _availableButtonSprite;
            }
            else if (state == State.LOCKED)
            {
                _button.interactable = false;
                _buttonBackground.sprite = _lockedButtonSprite;
            }
            else
            {
                throw new Exception($"Undefined button state {state}!");
            }
        }

        public enum State
        {
            AVAILABLE,
            LOCKED,
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                SetState(_state);
            }
            catch (Exception)
            {
                // ignored
            }
        }
#endif
    }
}