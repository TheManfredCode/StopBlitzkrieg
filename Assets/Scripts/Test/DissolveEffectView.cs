using System;
using System.Collections;
using UnityEngine;

namespace Test
{
    public class DissolveEffectView : MonoBehaviour
    {
        [SerializeField] private Material _material;

        private float _dissolveValue;
        private bool _isDissolving;

        private void OnEnable()
        {
            _isDissolving = true;
        }

        private void Update()
        {
            if(_isDissolving)
            {
                _dissolveValue = Mathf.Clamp01(_dissolveValue + Time.deltaTime);
                _material.SetFloat("_DissolveValue", _dissolveValue);
            }
        }
        
        // private IEnumerator CreateCoroutine(Action callback, float milliseconds)
        // {
        //     var timeSeconds = milliseconds / 1000;
        //     
        //     
        //     
        //     yield return new WaitForSeconds(timeSeconds);
        //     callback?.Invoke();
        // }
    }
}