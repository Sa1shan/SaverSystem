using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source
{
    public class ClickableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<float> OnButton;

        private bool _isPressed;
        private float _pressStartTime;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _pressStartTime = Time.time;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            float holdDuration = Time.time - _pressStartTime;
            OnButton?.Invoke(holdDuration);
        }
    }
}