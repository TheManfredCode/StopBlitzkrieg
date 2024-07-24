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
            StartCoroutine(CreateCoroutine(() =>
            {
                Debug.Log("DONE!!");
            }, 2f));
        }

        private void Update()
        {
            // if(_isDissolving)
            // {
            //     _dissolveValue = Mathf.Clamp01(_dissolveValue + Time.deltaTime);
            //     _material.SetFloat("_DissolveValue", _dissolveValue);
            // }
        }
        
        private IEnumerator CreateCoroutine(Action callback, float seconds)
        {
            float elapsedTime = 0;

            while (elapsedTime < seconds)
            {
                elapsedTime += Time.deltaTime;
                Debug.Log(elapsedTime);
                yield return null;
            }
            
            callback?.Invoke();
        }
    }
}