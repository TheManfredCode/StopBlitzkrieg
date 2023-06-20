using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        public event Action Closed;
        
        private void OnEnable()
        {
            SubscribeButtons();
        }

        private void OnDisable()
        {
            UnsubscribeButtons();
        }

        protected virtual void SubscribeButtons()
        {
            _closeButton?.onClick.AddListener(Close);
        }
        
        protected virtual void UnsubscribeButtons()
        {
            _closeButton?.onClick.RemoveListener(Close);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                Closed?.Invoke();
            }
        }
    }
}